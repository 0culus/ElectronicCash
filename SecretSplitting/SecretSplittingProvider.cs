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
        public bool IsSecretMessageProtected = false;
        public bool IsRProtected = false;
        public bool IsSProtected = false;

        private const int PaddingForMemoryProtect = 16;

        List<byte[]> ListRandomBytes { get; set; }
        public byte[] R { get; set; }
        public byte[] S { get; set;  }
        public byte[] SecretMessage { get; }
        

        /// <summary>
        /// Secret splitting between an aribtrary number of actors. Not currently implemented.
        /// </summary>
        /// <param name="secretMessage"></param>
        /// <param name="randMessagesBytes"></param>
        public SecretSplittingProvider(byte[] secretMessage, 
            IEnumerable<byte[]> randMessagesBytes)
        {
            //SecretMessage = secretMessage;
            //IsSecretMessageProtected = false;
            //ListRandomBytes = new List<byte[]>(randMessagesBytes);
            throw new NotImplementedException();
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

            SecretMessage = PadArrayToMultipleOf(SecretMessage, PaddingForMemoryProtect);
            R = PadArrayToMultipleOf(R, PaddingForMemoryProtect);

            ToggleMemoryProtect(SecretMessage, ref IsSecretMessageProtected);
            ToggleMemoryProtect(R, ref IsRProtected);
        }

        /// <summary>
        /// Here we actually do the split. R goes to one actor; S goes to the other. Both actors,
        /// then, must XOR their pieces to recover SecretMessage (M).
        /// </summary>
        public void SplitSecretBetweenTwoPeople()
        {
            if (!IsSecretMessageProtected && !IsRProtected)
            {
                S = ExclusiveOr(SecretMessage, R);
                S = PadArrayToMultipleOf(S, PaddingForMemoryProtect);
                ToggleMemoryProtect(S, ref IsSProtected);
            }
            else
            {
                ToggleMemoryProtect(SecretMessage, ref IsSecretMessageProtected);
                ToggleMemoryProtect(R, ref IsRProtected);

                S = ExclusiveOr(SecretMessage, R);
                ToggleMemoryProtect(S, ref IsSProtected);
                ToggleMemoryProtect(SecretMessage, ref IsSecretMessageProtected);
                ToggleMemoryProtect(R, ref IsRProtected);
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
        /// Provides toggling of memory protection for the byte[] passed in
        /// </summary>
        /// <param name="toProtectBytes"></param>
        /// <param name="flag"></param>
        private static void ToggleMemoryProtect(byte[] toProtectBytes, ref bool flag)
        {
            if (!flag)
            {
                try
                {
                    ProtectedMemory.Protect(toProtectBytes, MemoryProtectionScope.SameProcess);
                    flag = true;
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
                    ProtectedMemory.Unprotect(toProtectBytes, MemoryProtectionScope.SameProcess);
                    flag = false;
                }
                catch (CryptographicException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        /// <summary>
        /// Pad an array to the given multiple for use with crypto methods. See:
        /// http://stackoverflow.com/a/1144881
        /// This one doesn't use pass-by-reference, unlike the version in the Helpers class.
        /// Since the <c>ProtectedMemory</c> methods require that the arrays be multiples of 16, we need to multiple. 
        /// This is also convenient for other byte array operations.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="multiple"></param>
        private static byte[] PadArrayToMultipleOf(byte[] source, int multiple)
        {
            var len = (source.Length + multiple - 1) / multiple * multiple;
            Array.Resize(ref source, len);

            return source;
        }
    }
}
