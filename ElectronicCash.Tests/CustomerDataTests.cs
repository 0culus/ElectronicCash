﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace ElectronicCash.Tests
{
    [TestFixture]
    class CustomerDataTests
    {
        //private static DateTime _dateTime = new DateTime();
        private static readonly Name CustomerName = new Name("Elmer", "T.", "Fudd", "Mr.");
        private static readonly StreetAddress CustomerAddress = new StreetAddress("20 Bunny Rd.", "Rabbits, Rabbitville", "12345");
        private readonly CustomerData _customerData = new CustomerData(CustomerName, "fudd@bunny.xyz", 
            CustomerAddress, DateTime.UtcNow, new Guid());

        [Test]
        public void OnConstruction_NameShouldNotBeNull()
        {
            Assert.IsNotNull(CustomerName);
        }

        [Test]
        public void OnConstruction_NamePropertiesShouldNotBeNull()
        {
            Assert.IsNotNull(CustomerName.FirstName);
            Assert.IsNotNull(CustomerName.MiddleName);
            Assert.IsNotNull(CustomerName.LastName);
            Assert.IsNotNull(CustomerName.Title);
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
            Assert.IsNotNull(_customerData.CustomerName);
            Assert.IsNotNull(_customerData.CustomerStreetAddress);
            Assert.IsNotNull(_customerData.Email);
            Assert.IsNotNull(_customerData.CreatedDateTime);
        }

        [Test]
        public void OnSerialization_OutputShouldBeValidJson()
        {
            var serialized = _customerData.GetCustomerDataJson(_customerData);

            var testRead = 
        }
    }
}