using System;
using Newtonsoft.Json;

namespace ElectronicCash
{
    /// <summary>
    /// Store the components of the customer's name
    /// </summary>
    internal struct Name
    {
        private readonly string _firstName;
        private readonly string _middleName;
        private readonly string _lastName;
        private readonly string _title;

        public Name(string firstName, string middleName, string lastName, string title)
        {
            _firstName = firstName;
            _middleName = middleName;
            _lastName = lastName;
            _title = title;
        }

        public string FirstName => _firstName;
        public string MiddleName => _middleName;
        public string LastName => _lastName;
        public string Title => _title;
    }

    /// <summary>
    /// Store the components of the customer's street address
    /// </summary>
    internal struct StreetAddress
    {
        private readonly string _road;
        private readonly string _cityState;
        private readonly string _zipCode;
        private readonly string _apartmentNumber;

        public StreetAddress(string road, string cityState, string zipCode)
        {
            _apartmentNumber = null;
            _cityState = cityState;
            _road = road;
            _zipCode = zipCode;
        }

        public StreetAddress(string road, string cityState, string zipCode, string apartmentNumber)
        {
            _apartmentNumber = apartmentNumber;
            _cityState = cityState;
            _road = road;
            _zipCode = zipCode;
        }

        public string Road => _road;
        public string CityState => _cityState;
        public string ZipCode => _zipCode;
        public string ApartmentNumber => _apartmentNumber;
    }

    /// <summary>
    /// Deal with customer data for serialization to JSON
    /// </summary>
    internal class CustomerData
    {
        public Name CustomerName { get; set; } 
        public string Email { get; set; }
        public StreetAddress CustomerStreetAddress { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid CustomerGuid { get; set; }
        public string CustomerDataJson { get; set; }

        public CustomerData(Name customerName, string email, StreetAddress customerStreetStreetAddress,
            DateTime createdDateTime, Guid customerGuid)
        {
            CustomerName = customerName;
            Email = email;
            CustomerStreetAddress = customerStreetStreetAddress;
            CreatedDateTime = createdDateTime;
            CustomerGuid = customerGuid;
        }

        /// <summary>
        /// Return pretty-printed JSON serialized form of the instance of CustomerData passed in
        /// </summary>
        /// <param name="toSerialize"></param>
        /// <returns></returns>
        public string GetCustomerDataJson(CustomerData toSerialize)
        {
            return JsonConvert.SerializeObject(toSerialize, Formatting.Indented);
        }
    }
}
