using System.Security.Cryptography;
using BitCommitment;
using NUnit.Framework;

namespace ElectronicCash.Tests
{
    [TestFixture]
    class BitCommitmentTests
    {
        private const string Message = "TheseAreRandomByteswithMoreRandomBytesAndBitCommitment";

        [Test]
        public void OnBitCommitment_OutputHashShouldMatchMessageHash()
        {
            var r1 = Helpers.GetBytes("TheseAreRandomBytes");
            var r2 = Helpers.GetBytes("withMoreRandomBytes");
            var b = Helpers.GetBytes("AndBitCommitment");
            var hashProvider = SHA256.Create();

            var committer = new BitCommitmentProvider(r1, r2, b);
            var hashed = hashProvider.ComputeHash(Helpers.GetBytes(Message));

            Assert.AreEqual(committer.BitCommitMessage(), hashed);
        }
    }
}