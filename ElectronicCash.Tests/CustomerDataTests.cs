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
        private readonly CustomerModel _customerModel = new CustomerModel(CustomerActorName, "fudd@bunny.xyz", 
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
            Assert.IsNotNull(_customerModel);
        }

        [Test]
        public void OnConstruction_CustomerDataPropertiesShouldNotBeNull()
        {
            Assert.IsNotNull(_customerModel.CreatedDateTime);
            Assert.IsNotNull(_customerModel.CustomerGuid);
            Assert.IsNotNull(_customerModel.CustomerActorName);
            Assert.IsNotNull(_customerModel.CustomerStreetAddress);
            Assert.IsNotNull(_customerModel.Email);
            Assert.IsNotNull(_customerModel.CreatedDateTime);
        }

        [Test]
        public void OnSerialization_OutputShouldBeValidJson()
        {
            var serialized = _customerModel.GetCustomerDataJson(_customerModel);
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

        // TODO: override Equals for CustomerModel so that this test can work
        //[Test]
        //public void OnDeserialization_ObjectPropertiesShouldMatchOriginalObjectProperties()
        //{
        //    var serialized = _customerModel.GetCustomerDataJson(_customerModel);
        //    var deserialized = _customerModel.GetCustomerDataObject(serialized);

        //    Assert.AreEqual(_customerModel.CustomerActorName, deserialized.CustomerActorName);
        //    Assert.AreEqual(_customerModel.Email, deserialized.Email);
        //    Assert.AreEqual(_customerModel.CreatedDateTime, deserialized.CreatedDateTime);
        //    Assert.AreEqual(_customerModel.CustomerGuid, deserialized.CustomerGuid);
        //    Assert.AreEqual(_customerModel.CustomerStreetAddress, deserialized.CustomerStreetAddress);
        //}
    }
}
