using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Helpers for the <see cref="SecureString"/> class to
    /// handle the password from the user in a secure way.
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// unsecures a <see cref="SecureString"/> to plain text to
        /// be able to do operations with it
        /// </summary>
        /// <param name="secureString"> The secure string </param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {
            // Make sure we have a secure string
            if(secureString == null)
            {
                return string.Empty;
            }

            // Get a pointer for an unsecure string in memory
            var unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally 
            { 
                // Clean up any memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString); 
            }
        }
    }
}
