using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SecretSplitting
{
    /// <summary>
    /// This portion of the protocol is critical...Alice splits her bit committed packets so that
    /// they are not accessible except when the bank requires it. Property names reflect
    /// </summary>
    public class SecretSplittingProvider
    {
        private bool _isProtected = false;

        List<byte[]> ListRandomBytes { get; set; }
        public byte[] R { get; set; }
        public byte[] S { get; set; }
        private byte[] SecretMessage { get; }

        /// <summary>
        /// Splitting between an arbitrary number of actors
        /// </summary>
        /// <param name="secretMessage"></param>
        /// <param name="randMessagesBytes"></param>
        public SecretSplittingProvider(byte[] secretMessage, 
            IEnumerable<byte[]> randMessagesBytes)
        {
            SecretMessage = secretMessage;
            ListRandomBytes = new List<byte[]>(randMessagesBytes);
        }

        /// <summary>
        /// Secret splitting between two actors. Page 70 of Applied Cryptography
        /// </summary>
        /// <param name="secretMessage"></param>
        /// <param name="r"></param>
        public SecretSplittingProvider(byte[] secretMessage, byte[] r)
        {
            SecretMessage = secretMessage;
            R = r;
        }

        /// <summary>
        /// Here we actually do the split. R goes to one actor; S goes to the other. Both actors,
        /// then, must XOR their pieces to recover SecretMessage (M).
        /// </summary>
        public void SplitSecretBetweenTwoPeople()
        {
            S = ExclusiveOr(SecretMessage, R);
            if (!_isProtected)
            {
                ToggleMemoryProtect(); 
            }
        }

        /// <summary>
        /// Compute XOR of an arbitrary number of byte arrays
        /// </summary>
        /// <param name="toXor"></param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns></returns>
        private static byte[] ExclusiveOr(List<byte[]> toXor)
        {
            //if (toXor.Any(p => p.Length != toXor.First().Length))
            //{
            //    throw new ArgumentException("Arguments must be the same length");
            //}

            throw new NotImplementedException();
        }

        /// <summary>
        /// Compute XOR of two byte arrays
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        private static byte[] ExclusiveOr(byte[] arr1, byte[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                throw new ArgumentException("arr1 and arr2 must be the same length");
            }

            var result = new byte[arr1.Length];

            for (var i = 0; i < arr1.Length; ++i)
            {
                result[i] = (byte)(arr1[i] ^ arr2[i]);
            }

            return result;
        }

        /// <summary>
        /// Toggles memory protection for the properties in this class
        /// </summary>
        public void ToggleMemoryProtect()
        {
            if (!_isProtected)
            {
                try
                {
                    ProtectedMemory.Protect(SecretMessage, MemoryProtectionScope.SameLogon);
                    ProtectedMemory.Protect(R, MemoryProtectionScope.SameLogon);
                    ProtectedMemory.Protect(S, MemoryProtectionScope.SameLogon);

                    _isProtected = true;
                }
                catch (CryptographicException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            else
            {
                try
                {
                    ProtectedMemory.Unprotect(SecretMessage, MemoryProtectionScope.SameLogon);
                    ProtectedMemory.Unprotect(R, MemoryProtectionScope.SameLogon);
                    ProtectedMemory.Unprotect(S, MemoryProtectionScope.SameLogon);

                    _isProtected = false;
                }
                catch (CryptographicException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
