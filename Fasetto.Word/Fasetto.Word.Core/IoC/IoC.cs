using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fasetto.Word;

namespace Fasetto.Word.Core.IoC
{

    /// <summary>
    /// The IoC container for our application
    /// Inversion of Control
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// The kernel for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// Sets up the IoC Container, binds all information required and is ready for use 
        /// NOTE: Must be called as soon as the application starts up to ensure
        ///       all services can be found.
        /// </summary>
        public static void Setup()
        {
            // binds all required view models
            BindViewModels();
        }

        private static void BindViewModels()
        {
            // bind to a single instance of Application view model:
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        /// <summary>
        /// Get a service from the IoC containr, of the specified type:
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            
            return Kernel.Get<T>();

        }
    }
}
