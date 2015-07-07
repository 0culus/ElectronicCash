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
        List<byte[]> RandomBytes { get; set; }
        byte[] RandomOne { get; set; }
        byte[] RandomTwo { get; set; }
        private byte[] SecretMessage { get; set; }

        /// <summary>
        /// Splitting between an arbitrary number of actors
        /// </summary>
        /// <param name="secretMessage"></param>
        /// <param name="randMessageBytes"></param>
        public SecretSplittingProvider(byte[] secretMessage, 
            IEnumerable<byte[]> randMessageBytes)
        {
            SecretMessage = secretMessage;
            RandomBytes = new List<byte[]>(randMessageBytes);
        }

        /// <summary>
        /// Splitting between two actors
        /// </summary>
        /// <param name="secretMessage"></param>
        /// <param name="randomBytesOne"></param>
        /// <param name="randomBytesTwo"></param>
        public SecretSplittingProvider(byte[] secretMessage, 
            byte[] randomBytesOne, 
            byte[] randomBytesTwo)
        {
            SecretMessage = secretMessage;
            RandomOne = randomBytesOne;
            RandomTwo = randomBytesTwo;
        }
    }
}
