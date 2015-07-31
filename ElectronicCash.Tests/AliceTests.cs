using System;
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
        static readonly CustomerModel Model = new CustomerModel(new ActorName("Elmer", "T.", "Fudd", "Mr"), 
            "fudd@bunny.xyz", new StreetAddress("20 Bunny Rd.", "Rabbits, Rabbitville", "12345"), 
            DateTime.UtcNow, new Guid());
        readonly Alice _testActor = new Alice(4, new Guid(), Model);

        [Test]
        public void OnConstructionNoAlicePropertiesShouldBeNull()
        {
            //Assert.IsNotNull(_testActor.ActorName);
            //Assert.IsNotNull(_testActor.NumOrders); Int32 not nullable so does not fail
            Assert.IsNotNull(_testActor.Amount);
            Assert.IsNotNull(_testActor.ActorGuid);
            Assert.IsNotNull(_testActor.PersonalModel);
            Assert.IsNotNull(_testActor.PersonalDataBytes);
            Assert.IsNotNull(_testActor.Ledger);
        }

        [Test]
        public void CreateMoneyOrders_AmountShouldEqualGivenAmount()
        {
            _testActor.CreateMoneyOrders(500m);

            Assert.AreEqual(500m, _testActor.Amount);
        }
    }
}
