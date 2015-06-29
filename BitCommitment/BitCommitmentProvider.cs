using System;

namespace BitCommitment
{
    /// <summary>
    /// A class to perform bit commitment. It does not care what the input is; it's just a 
    /// facility for exchanging bit commitment messages. Based on Bruce Schneier's one-way 
    /// function method for committing bits
    /// </summary>
    public class BitCommitmentProvider
    {
        public byte[] AliceRandBytes1 { get; set; }
        public byte[] AliceRandBytes2 { get; set; }
        public byte[] AliceMessageBytesBytes { get; set; }

        public BitCommitmentProvider(byte[] one, byte[] two, byte[] messageBytes)
        {
            AliceRandBytes1 = one;
            AliceRandBytes2 = two;
            AliceMessageBytesBytes = messageBytes;
        }

        public byte[] BitCommitMessage()
        {
            throw new NotImplementedException();
        }
    }
}
