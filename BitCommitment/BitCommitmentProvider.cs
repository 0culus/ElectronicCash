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
        public byte[] AliceRandBytesR1 { get; set; }
        public byte[] AliceRandBytesR2 { get; set; }
        public byte[] AliceBytesToCommitB { get; set; }

        public BitCommitmentProvider(byte[] randBytesR1, 
            byte[] randBytesR2, 
            byte[] bytesToCommit)
        {
            AliceRandBytesR1 = randBytesR1;
            AliceRandBytesR2 = randBytesR2;
            AliceBytesToCommitB = bytesToCommit;
        }

        /// <summary>
        /// Returns a byte array containing the one way function computed for the triple
        /// (R_1, R_2, B) where R_1 is AliceRandBytesR1, R_2 is AliceRandBytesR2, and B is the byte(s) 
        /// Alice wants to commit. 
        /// </summary>
        /// <returns></returns>
        public byte[] BitCommitMessage()
        {
            throw new NotImplementedException();
        }
    }
}
