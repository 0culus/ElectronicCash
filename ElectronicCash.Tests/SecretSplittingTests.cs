using NUnit.Framework;
using SecretSplitting;

namespace ElectronicCash.Tests
{
    [TestFixture]
    class SecretSplittingTests
    {
        private static readonly byte[] Message = Helpers.GetBytes("Supersecretmessage");
        private static readonly byte[] RandBytes = Helpers.GetRandomBytes(Helpers.GetString(Message).Length * sizeof(char));
        private readonly SecretSplittingProvider _splitter = new SecretSplittingProvider(Message, RandBytes);

        [Test]
        public void OnSplit_OriginalMessageShouldBeRecoverable()
        {
            _splitter.SplitSecretBetweenTwoPeople();

            var r = _splitter.R;
            var s = _splitter.S;

            var m = Helpers.ExclusiveOr(r, s);

            Assert.AreEqual(Helpers.GetString(m), Helpers.GetString(Message));
        }

        [Test]
        public void OnSecretSplit_FlagsShouldBeTrue()
        {
            var splitter = new SecretSplittingProvider(Message, RandBytes);
            splitter.SplitSecretBetweenTwoPeople();
            
            Assert.IsTrue(splitter.IsRProtected);
            Assert.IsTrue(splitter.IsSProtected);
            Assert.IsTrue(splitter.IsSecretMessageProtected);   
        }
    }
}
