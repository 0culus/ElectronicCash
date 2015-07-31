using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicCash
{
    /// <summary>
    /// The customer
    /// </summary>
    public class Alice : BaseActor
    {
        public List<MoneyOrder> MoneyOrders { get; private set; }
        public int NumOrders { get; set; }
        public decimal Amount { get; set; }
        public byte[] PersonalDataBytes { get; private set; }

        public Alice(int numOrders, Guid actorGuid, CustomerModel personalModel)
        {
            NumOrders = numOrders;
            ActorGuid = actorGuid;
            Money = 1000m;
            PersonalModel = personalModel;
            PersonalDataBytes = Helpers.GetBytes(personalModel.GetCustomerDataJson(personalModel));
            Ledger = new Dictionary<Guid, List<MoneyOrder>>();
        }

        /// <summary>
        /// Called every time the customer wants to pay for something
        /// </summary>
        public void CreateMoneyOrders(decimal amount)
        {
            Amount = amount;
            MoneyOrders = new List<MoneyOrder>();

            // for testing only
            var rnd = new Random();
            // for testing only

            for (var i = 0; i < NumOrders; i++)
            {
                var testBytes = new byte[10];
                rnd.NextBytes(testBytes);
                var uniquenessString = new Guid();
                //var idPairs = CreateIdStringPairs(PersonalDataBytes);
                // TODO: once done testing, change back to use our personal data
                var idPairs = CreateIdStringPairs(testBytes);
                var currentMoneyOrder = new MoneyOrder(Amount, uniquenessString.ToByteArray(), idPairs);
                MoneyOrders.Add(currentMoneyOrder);
            }

            // store the transaction for later reference with a unique id
            Ledger.Add(new Guid(), MoneyOrders);
        }

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

            // TODO: this loop for testing purposes only
            for (var i = 0; i < NumOrders; i++)
            {
                var reverse = personalDataBytes.Reverse().ToArray();
                var newPair = new IdentityStringPair<byte[]>(personalDataBytes, reverse);
                pairs.Add(newPair);
            }

            return pairs;
        } 
    }
}
