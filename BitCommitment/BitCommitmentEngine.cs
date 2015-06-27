using System;

namespace BitCommitment
{
    /// <summary>
    /// A class to perform bit commitment. It does not care what the input is; it's just a 
    /// facility for exchanging bit commitment messages.
    /// </summary>
    public class BitCommitmentEngine
    {
        #region properties

        public Byte[] BobRandBytesR { get; set; }
        public Byte[] AliceEncryptedMessage { get; set; }

        #endregion
    }
}
