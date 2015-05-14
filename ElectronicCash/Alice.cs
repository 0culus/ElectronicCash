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
        public int NumOrders { get; set; }
        public int Amount { get; set; }
        public string PersonalData { get; private set; }
        public byte[] PersonalDataBytes { get; private set; }

        public Alice(string name, int numOrders, Guid actorGuid, string personalData)
        {
            Name = name;
            NumOrders = numOrders;
            ActorGuid = actorGuid;
            Money = 1000;
            PersonalData = personalData;
            PersonalDataBytes = GetBytes(personalData);
        }

        /// <summary>
        /// Called every time the customer wants to pay for something
        /// </summary>
        public void CreateMoneyOrders(int amount)
        {
            Amount = amount;
            MoneyOrders = new List<MoneyOrder>();
            Guid transactionId = new Guid();

            // for testing only
            Random rnd = new Random();
            // for testing only

            for (int i = 0; i < NumOrders; i++)
            {
                byte[] testBytes = new byte[10];
                rnd.NextBytes(testBytes);
                var uniquenessString = new Guid();
                //var idPairs = CreateIdStringPairs(PersonalDataBytes);
                var idPairs = CreateIdStringPairs(testBytes);
                var currentMoneyOrder = new MoneyOrder(Amount.ToString(), uniquenessString.ToByteArray(), idPairs);
                MoneyOrders.Add(currentMoneyOrder);
            }

            // store the transaction for later reference
            Ledger.Add(transactionId, MoneyOrders);
        }

        #region private methods

        /// <summary>
        /// Create N identity string pairs
        /// Placeholder method for now just creates pairs of random bytes
        /// TODO: implement according to protocol, with secret splitting and bit commitment using the personal data 
        /// </summary>
        /// <param name="personalDataBytes"></param>
        /// <returns></returns>
        private List<IdentityStringPair<byte[]>> CreateIdStringPairs(byte[] personalDataBytes)
        {
            var pairs = new List<IdentityStringPair<byte[]>>();

            // this loop for testing purposes only
            for (int i = 0; i < NumOrders; i++)
            {
                var reverse = personalDataBytes.Reverse().ToArray();
                var newPair = new IdentityStringPair<byte[]>(personalDataBytes, reverse);
                pairs.Add(newPair);
            }

            return pairs;
        } 

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
