using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ElectronicCash
{
    /// <summary>
    /// Deal with customer data for serialization to JSON
    /// </summary>
    public class CustomerModel
    {
        private readonly SerializeCustomerModel _serializeCustomerModel;
        public ActorName Name { get; set; } 
        public string Email { get; set; }
        public StreetAddress CustomerStreetAddress { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid Id { get; set; }

        public SerializeCustomerModel SerializeCustomerModel
        {
            get { return _serializeCustomerModel; }
        }

        public CustomerModel(ActorName name, string email, StreetAddress customerStreetStreetAddress,
            DateTime createdDateTime, Guid id)
        {
            Name = name;
            Email = email;
            CustomerStreetAddress = customerStreetStreetAddress;
            CreatedDateTime = createdDateTime;
            Id = id;
            _serializeCustomerModel = new SerializeCustomerModel();
        }
    }
}
