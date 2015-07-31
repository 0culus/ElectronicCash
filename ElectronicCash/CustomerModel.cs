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
        public ActorName CustomerActorName { get; set; } 
        public string Email { get; set; }
        public StreetAddress CustomerStreetAddress { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid CustomerGuid { get; set; }
        //public string CustomerDataJson { get; set; }

        public CustomerModel(ActorName customerActorName, string email, StreetAddress customerStreetStreetAddress,
            DateTime createdDateTime, Guid customerGuid)
        {
            CustomerActorName = customerActorName;
            Email = email;
            CustomerStreetAddress = customerStreetStreetAddress;
            CreatedDateTime = createdDateTime;
            CustomerGuid = customerGuid;
        }

        /// <summary>
        /// Return pretty-printed JSON serialized form of the instance of CustomerModel passed in
        /// </summary>
        /// <param name="toSerialize"></param>
        /// <returns></returns>
        public string GetCustomerDataJson(CustomerModel toSerialize)
        {
            string serialized = null;

            try
            {
                serialized = JsonConvert.SerializeObject(toSerialize, Formatting.Indented);
            }
            catch (JsonSerializationException e)
            {

                Console.WriteLine(e.Message);
                return null;
            }

            return serialized;
        }

        /// <summary>
        /// Return deserialized CustomerModel object from JSON
        /// </summary>
        /// <param name="jsonCustomerDataObject"></param>
        /// <returns></returns>
        public CustomerModel GetCustomerDataObject(string jsonCustomerDataObject)
        {
            try
            {
                var obj = JToken.Parse(jsonCustomerDataObject);
            }
            catch (JsonReaderException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            return JsonConvert.DeserializeObject<CustomerModel>(jsonCustomerDataObject);
        }
    }
}
