using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Fasetto.Word
{
    /// <summary>
    /// A helper function for expressions.
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compile an expression and gets the fuction's return value 
        /// </summary>
        /// <typeparam name="T"> The type of the return value </typeparam>
        /// <param name="lambda"> The expresion to be compiled </param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }


        /// <summary>
        /// Sets the underlying property's value to the given value
        /// from an expression that contains the property:
        /// </summary>
        /// <typeparam name="T"> the type of value to set </typeparam>
        /// <param name="lambda"> the expression </param>
        /// <param name="value"> the value to set the property </param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            // Convert a lambda ()=>some.Property to some.Property
            // meaning it retrieve the some.Property from the lambda expression passed in 
            // as a parameter of the function.
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            // Get the property information so we can set it 
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            // set the property value  
            propertyInfo.SetValue(target, value);
        }
    }
}

