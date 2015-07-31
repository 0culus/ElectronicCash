using System;
using NUnit.Framework;

namespace ElectronicCash.Tests
{
    [TestFixture]
    internal class HelperTests
    {
        const string Test = "ThisIsAnAwesomeString";
        const string BitCommitTest1 = "TheQuickBrownFox";
        const string BitCommitTest2 = "JumpedOverMyCar";
        private const string BitcommitTest3 = "TheQuickBrownFoxJumpedOverMyCar";

        [Test]
        public void GetBytesGivenString_ShouldYieldNonNullByteArray()
        {
            var result = Helpers.GetBytes(Test);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetStringGivenBytes_ShouldYieldNonNullString()
        {
            var rnd = new Random();
            var testBytes = new byte[10];
            var result = Helpers.GetString(testBytes);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetStringGivenBytes_ShouldYieldSameString()
        {
            var result = Helpers.GetBytes(Test);
            var fromBytes = Helpers.GetString(result);

            Assert.AreEqual(fromBytes, Test);
        }

        [Test]
        public void ConcatByteArrays_ShouldYieldSameBytesConcatenated()
        {
            var left = Helpers.GetBytes(BitCommitTest1);
            var right = Helpers.GetBytes(BitCommitTest2);
            var compare = Helpers.GetBytes(BitcommitTest3);
            var result = Helpers.ConcatByteArrays(left, right);

            Assert.AreEqual(result, compare);
        }

        [Test]
        public void ConcatByteArrays_ShouldYieldSameStringsConcatenated()
        {
            var left = Helpers.GetBytes(BitCommitTest1);
            var right = Helpers.GetBytes(BitCommitTest2);
            var compare = Helpers.GetBytes(BitcommitTest3);
            var result = Helpers.ConcatByteArrays(left, right);

            var resultString = Helpers.GetString(result);

            Assert.AreEqual(resultString, BitcommitTest3);
        }

        [Test]
        public void OnPad_ArrayLenShouldBeMultipleOfGivenInt()
        {
            var test = Helpers.GetBytes(BitcommitTest3);
            var testLen = Test.Length;
            var isMultipleOf = false;
            const int multiple = 16;

            Helpers.PadArrayToMultipleOf(ref test, multiple);

            if ((test.Length % multiple) == 0)
            {
                isMultipleOf = true;
            }

            Assert.IsTrue(isMultipleOf);
        }

        [STAThread]
        private static void Main()
        {
        }
    }
}
