using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ElectronicCash.Tests
{
    /// <summary>
    /// Tests for the customer actor (alice)
    /// </summary>
    [TestFixture]
    class AliceTests
    {
        //static readonly Guid actorGuid = new Guid();
        readonly Alice _testActor = new Alice("Jane Doe", 4, new Guid(), "JaneDoe;10Downing");
        [Test]
        public void DummyTest()
        {
            Assert.True(true);
        }

        [Test]
        public void OnConstructionNoAlicePropertiesShouldBeNull()
        {
            Assert.IsNotNull(_testActor.Name);
            Assert.IsNotNull(_testActor.NumOrders);
            Assert.IsNotNull(_testActor.Amount);
            Assert.IsNotNull(_testActor.ActorGuid);
            Assert.IsNotNull(_testActor.PersonalData);
            Assert.IsNotNull(_testActor.PersonalDataBytes);
            Assert.IsNotNull(_testActor.Ledger);
        }

        [Test]
        public void CreateMoneyOrders_AmountShouldEqualGivenAmount()
        {
            _testActor.CreateMoneyOrders(500);

            Assert.AreEqual(500, _testActor.Amount);
        }
    }
}
