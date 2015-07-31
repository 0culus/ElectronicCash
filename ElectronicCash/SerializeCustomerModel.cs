using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ElectronicCash
{
    public class SerializeCustomerModel
    {
        /// <summary>
        /// Return pretty-printed JSON serialized form of the instance of CustomerModel passed in
        /// </summary>
        /// <param name="toSerialize"></param>
        /// <returns></returns>
        public static string GetCustomerDataJson(CustomerModel toSerialize)
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
        public static CustomerModel GetCustomerDataObject(string jsonCustomerDataObject)
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