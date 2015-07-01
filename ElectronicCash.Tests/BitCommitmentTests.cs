using System;
using BitCommitment;
using NUnit.Framework;

namespace ElectronicCash.Tests
{
    [TestFixture]
    class BitCommitmentTests
    {
        readonly string message = "TheseAreRandomByteswithMoreRandomBytesAndBitCommitment";

        [Test]
        public void OnBitCommitment_OutputStringShouldMatchInputConcatenated()
        {
            var r1 = Helpers.GetBytes("TheseAreRandomBytes");
            var r2 = Helpers.GetBytes("withMoreRandomBytes");
            var b = Helpers.GetBytes("AndBitCommitment");

            var committer = new BitCommitmentProvider(r1, r2, b);

            Assert.AreEqual(committer.BitCommitMessage(), Helpers.GetBytes(message));
        }
    }
}