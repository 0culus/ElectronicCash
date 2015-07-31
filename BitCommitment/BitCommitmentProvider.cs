using System.Security.Cryptography;
using ElectronicCash;

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
        /// <para>Returns a byte array containing the one way function computed for the triple
        /// (R_1, R_2, B) where R_1 is AliceRandBytesR1, R_2 is AliceRandBytesR2, and B is the byte(s) 
        /// Alice wants to commit.</para>
        /// 
        /// <para>Commitment by one way function works like this:
        /// <list type="number">
        ///     <item>
        ///         <description>Alice generates two random bit strings, R1, R2</description>
        ///     </item>
        ///     <item>
        ///         <description>Alice then creates a message consisting of her random strings and the "bit" she 
        ///                     wishes to commit, e.g. the triple (R1, R2, b). We use string concatenation.</description>
        ///     </item>
        ///     <item>
        ///         <description>Alice computes the one way function on this message (we use SHA256), and sends the hash as well as R1 to Bob.</description>
        ///     </item>
        ///     <item>
        ///         <description>This transmission is evidence of commitment. Bob cannot invert the hash, so the message is secure.</description>
        ///     </item>
        ///     <item>
        ///         <description>Then, to verify, Alice sends Bob the original message (R1, R2, b).</description>
        ///     </item>
        ///     <item>
        ///         <description>Bob then computes the one way function on the message and compares it and R1 with the hash and random value received from Alice. If they match, the "bit" is valid</description>
        ///     </item>
        /// </list></para>
        /// 
        /// <para>
        ///     Source: 'Applied Cryptography' by Schneier, 2nd edition. See page 87
        /// </para>
        /// </summary>
        /// <returns>The SHA256 hash of the message</returns>
        public byte[] BitCommitMessage()
        {
            var r1 = Helpers.GetString(AliceRandBytesR1);
            var r2 = Helpers.GetString(AliceRandBytesR2);
            var b = Helpers.GetString(AliceBytesToCommitB);
            var hashProvider = SHA256.Create();

            var hashedMessage = hashProvider.ComputeHash(Helpers.GetBytes(r1 + r2 + b));

            return (hashedMessage);
        }
    }
}
