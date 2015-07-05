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

        private byte[] SecretMessage { get; set; }

        public SecretSplittingProvider(byte[] secretMessage, IEnumerable<byte[]> randMessageBytes)
        {
            SecretMessage = secretMessage;
            RandomBytes = new List<byte[]>(randMessageBytes);
        }
    }
}
