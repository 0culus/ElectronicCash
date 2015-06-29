using System;

namespace BitCommitment
{
    /// <summary>
    /// A class to perform bit commitment. It does not care what the input is; it's just a 
    /// facility for exchanging bit commitment messages. Based on Bruce Schneier's one-way 
    /// function method for committing bits. See p.87 of `Applied Cryptography`.
    /// </summary>
    public class BitCommitmentProvider
    {
        public byte[] AliceRandBytes1 { get; set; }
        public byte[] AliceRandBytes2 { get; set; }
        public byte[] AliceBytesToCommitBytesToCommit { get; set; }

        public BitCommitmentProvider(byte[] randBytes1, 
            byte[] randBytes2, 
            byte[] bytesToCommit)
        {
            AliceRandBytes1 = randBytes1;
            AliceRandBytes2 = randBytes2;
            AliceBytesToCommitBytesToCommit = bytesToCommit;
        }

        public byte[] BitCommitMessage()
        {
            throw new NotImplementedException();
        }
    }
}
