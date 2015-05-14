using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ElectronicCash.Tests
{
    [TestFixture]
    internal class HelperTests
    {
        [Test]
        public void DummyTest()
        {
            Assert.True(true);
        }

        [Test]
        public void GetBytesGivenString_ShouldYieldNonNullByteArray()
        {
            string test = "ThisIsAnAwesomeString";
            byte[] result = Helpers.GetBytes(test);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetStringGivenBytes_ShouldYieldNonNullString()
        {
            var rnd = new Random();
            var testBytes = new byte[10];
            string result = Helpers.GetString(testBytes);

            Assert.IsNotNull(result);
        }

        [STAThread]
        private static void Main()
        {
        }
    }
}
