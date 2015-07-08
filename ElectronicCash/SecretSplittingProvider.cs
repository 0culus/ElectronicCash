using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicCash
{
    /// <summary>
    /// This portion of the protocol is critical...Alice splits her bit committed packets so that
    /// they are not accessible except when the bank requires it. 
    /// </summary>
    class SecretSplittingProvider
    {
        List<byte[]> ListRandomBytes { get; set; }
        byte[] RandomBytes { get; set; }
        private byte[] SecretMessage { get; set; }

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
        /// Splitting between two actors
        /// </summary>
        /// <param name="secretMessage"></param>
        /// <param name="randomBytes</param>
        /// <param name="randomBytesTwo"></param>
        public SecretSplittingProvider(byte[] secretMessage, byte[] randomBytes)
        {
            SecretMessage = secretMessage;
            RandomBytes = randomBytes;
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
    }
}
