using NUnit.Framework;

namespace ElectronicCash.Tests
{
    [TestFixture]
    class SecretSplittingTests
    {
        private static readonly byte[] _message = Helpers.GetBytes("Supersecretmessage");
        private static readonly byte[] _randBytes = Helpers.GetRandomBytes(Helpers.GetString(_message).Length * sizeof(char));
        private readonly SecretSplittingProvider _splitter = new SecretSplittingProvider(_message, _randBytes);

        [Test]
        public void OnSplit_OriginalMessageShouldBeRecoverable()
        {
            _splitter.SplitSecretBetweenTwoPeople();

            var r = _splitter.R;
            var s = _splitter.S;

            var m = Helpers.ExclusiveOr(r, s);

            Assert.AreEqual(Helpers.GetString(m), Helpers.GetString(_message));
        }
    }
}
