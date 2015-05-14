using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicCash
{
    /// <summary>
    /// The customer
    /// </summary>
    public class Alice : BaseActor
    {
        public List<MoneyOrder> MoneyOrders { get; private set; }
        public string PersonalData { get; private set; }
        public byte[] PersonalDataBytes { get; private set; }

        public Alice(string _name, Guid _actorGuid, string _personalData)
        {
            Name = _name;
            ActorGuid = _actorGuid;
            Money = 1000;
            PersonalData = _personalData;
            PersonalDataBytes = GetBytes(_personalData);
        }

        /// <summary>
        /// Called every time the customer wants to pay for something
        /// </summary>
        public void CreateMoneyOrders()
        {
            MoneyOrders = new List<MoneyOrder>();

        }

        #region private methods

        /// <summary>
        /// stackoverflow.com/questions/472906/converting-a-string-to-byte-array-without-using-an-encoding-byte-by-byte
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// stackoverflow.com/questions/472906/converting-a-string-to-byte-array-without-using-an-encoding-byte-by-byte
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        #endregion
    }
}
