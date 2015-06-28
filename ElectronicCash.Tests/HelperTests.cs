using System;
using NUnit.Framework;

namespace ElectronicCash.Tests
{
    [TestFixture]
    internal class HelperTests
    {
        const string Test = "ThisIsAnAwesomeString";

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

        [STAThread]
        private static void Main()
        {
        }
    }
}
