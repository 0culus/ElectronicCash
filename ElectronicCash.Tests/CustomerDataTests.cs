using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace ElectronicCash.Tests
{
    [TestFixture]
    class CustomerDataTests
    {
        //private static DateTime _dateTime = new DateTime();
        private static readonly ActorName CustomerActorName = new ActorName("Elmer", "T.", "Fudd", "Mr.");
        private static readonly ActorName StoreActorName = new ActorName("Fudd's Bunny Shop");
        private static readonly StreetAddress CustomerAddress = new StreetAddress("20 Bunny Rd.", "Rabbits, Rabbitville", "12345");
        private readonly CustomerData _customerData = new CustomerData(CustomerActorName, "fudd@bunny.xyz", 
            CustomerAddress, DateTime.UtcNow, new Guid());

        [Test]
        public void OnNameConstruction_NameShouldNotBeNull()
        {
            Assert.IsNotNull(CustomerActorName);
        }

        [Test]
        public void OnPersonNameConstruction_NamePropertiesShouldNotBeNull()
        {
            Assert.IsNotNull(CustomerActorName.FirstName);
            Assert.IsNotNull(CustomerActorName.MiddleName);
            Assert.IsNotNull(CustomerActorName.LastName);
            Assert.IsNotNull(CustomerActorName.Title);
        }

        [Test]
        public void OnEntityNameConstruction_EntityNameShouldNotBeNull()
        {
            Assert.IsNotNull(StoreActorName.EntityName);
        }

        [Test]
        public void OnConstruction_CustomerAddressShouldNotBeNull()
        {
            Assert.IsNotNull(CustomerAddress);
        }

        [Test]
        public void OnConstruction_CustomerAddressWithoutAptPropertiesShouldNotBeNull()
        {
            Assert.IsNotNull(CustomerAddress.CityState);
            Assert.IsNotNull(CustomerAddress.Road);
            Assert.IsNotNull(CustomerAddress.ZipCode);
        }

        [Test]
        public void OnConstruction_CustomerDataObjectShouldNotBeNull()
        {
            Assert.IsNotNull(_customerData);
        }

        [Test]
        public void OnConstruction_CustomerDataPropertiesShouldNotBeNull()
        {
            Assert.IsNotNull(_customerData.CreatedDateTime);
            Assert.IsNotNull(_customerData.CustomerGuid);
            Assert.IsNotNull(_customerData.CustomerActorName);
            Assert.IsNotNull(_customerData.CustomerStreetAddress);
            Assert.IsNotNull(_customerData.Email);
            Assert.IsNotNull(_customerData.CreatedDateTime);
        }

        [Test]
        public void OnSerialization_OutputShouldBeValidJson()
        {
            var serialized = _customerData.GetCustomerDataJson(_customerData);
            var isThereException = false;

            try
            {
                var testRead = JToken.Parse(serialized);
            }
            catch (JsonReaderException e)
            {
                Console.WriteLine(e.Message);
                isThereException = true;
            }

            Assert.IsFalse(isThereException);
        }

        // TODO: override Equals for CustomerData so that this test can work
        //[Test]
        //public void OnDeserialization_ObjectPropertiesShouldMatchOriginalObjectProperties()
        //{
        //    var serialized = _customerData.GetCustomerDataJson(_customerData);
        //    var deserialized = _customerData.GetCustomerDataObject(serialized);

        //    Assert.AreEqual(_customerData.CustomerActorName, deserialized.CustomerActorName);
        //    Assert.AreEqual(_customerData.Email, deserialized.Email);
        //    Assert.AreEqual(_customerData.CreatedDateTime, deserialized.CreatedDateTime);
        //    Assert.AreEqual(_customerData.CustomerGuid, deserialized.CustomerGuid);
        //    Assert.AreEqual(_customerData.CustomerStreetAddress, deserialized.CustomerStreetAddress);
        //}
    }
}
