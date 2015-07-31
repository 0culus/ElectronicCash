using System;
using System.Security.Cryptography;
using SecretSplitting;

namespace ElectronicCash
{
    /// <summary>
    /// Contains all our helper methods to help keep our classes cleaner,
    /// and make unit testing possible
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// stackoverflow.com/questions/472906/converting-a-string-to-byte-array-without-using-an-encoding-byte-by-byte
        /// </summary>
        /// <param name="str"></param>
        /// <returns />
        public static byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// stackoverflow.com/questions/472906/converting-a-string-to-byte-array-without-using-an-encoding-byte-by-byte
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns />
        public static string GetString(byte[] bytes)
        {
            var chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        /// <summary>
        /// A simple way to concatenate byte arrays. See http://stackoverflow.com/a/415396. Used for
        /// bit commitment.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static byte[] ConcatByteArrays(byte[] left, byte[] right)
        {
            var concatenated = new byte[left.Length + right.Length];
            Buffer.BlockCopy(left, 0, concatenated, 0, left.Length);
            Buffer.BlockCopy(right, 0, concatenated, left.Length, right.Length);

            return concatenated;
        }

        /// <summary>
        /// Return a specific number of random bytes, in a byte array
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] GetRandomBytes(int length)
        {
            var rnd = new RNGCryptoServiceProvider();

            var data = new byte[length];
            rnd.GetBytes(data);

            return data;
        }

        /// <summary>
        /// Compute XOR of two byte arrays
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public static byte[] ExclusiveOr(byte[] arr1, byte[] arr2)
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
        /// Provide toggling of memory protection for instances of SecretSplittingProvider
        /// </summary>
        /// <param name="instance"></param>
        public static void ToggleMemoryProtection(SecretSplittingProvider instance)
        {
            if (!instance.IsSecretMessageProtected)
            {
                try
                {
                    ProtectedMemory.Protect(instance.SecretMessage, MemoryProtectionScope.SameProcess);
                    ProtectedMemory.Protect(instance.R, MemoryProtectionScope.SameProcess);
                    ProtectedMemory.Protect(instance.S, MemoryProtectionScope.SameProcess);

                    instance.IsSecretMessageProtected = true;
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
                    ProtectedMemory.Unprotect(instance.SecretMessage, MemoryProtectionScope.SameProcess);
                    ProtectedMemory.Unprotect(instance.R, MemoryProtectionScope.SameProcess);
                    ProtectedMemory.Unprotect(instance.S, MemoryProtectionScope.SameProcess);

                    instance.IsSecretMessageProtected = false;
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
        /// </summary>
        /// <param name="source"></param>
        /// <param name="multiple"></param>
        public static void PadArrayToMultipleOf(ref byte[] source, int multiple)
        {
            var len = (source.Length + multiple - 1) / multiple * multiple;
            Array.Resize(ref source, len);
        }
    }
}
