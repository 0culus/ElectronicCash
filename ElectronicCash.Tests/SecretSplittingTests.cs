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
        private const int Padding = 16;

        [Test]
        public void OnSplit_OriginalMessageShouldBeRecoverable()
        {
            _splitter.SplitSecretBetweenTwoPeople();
            Helpers.ToggleMemoryProtection(_splitter);
            var r = _splitter.R;
            var s = _splitter.S;

            var m = Helpers.ExclusiveOr(r, s);
            var toPad = Message;

            Helpers.PadArrayToMultipleOf(ref toPad, Padding);
            
            Helpers.ToggleMemoryProtection(_splitter);

            Assert.AreEqual(Helpers.GetString(toPad), Helpers.GetString(m));
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
