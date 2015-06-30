using System;
using System.Collections.Generic;

namespace ElectronicCash
{
    /// <summary>
    /// holds the data for a money order
    /// </summary>
    [Serializable]
    public class MoneyOrder
    {
        public decimal Amount { get; set; }
        public byte[] UniquenessString { get; set; }
        public List<IdentityStringPair<byte[]>> NIdPairs { get; set; }

        public MoneyOrder(decimal amount,
            byte[] uniquenessString,
            List<IdentityStringPair<byte[]>> nIdPairs)
        {
            Amount = amount;
            UniquenessString = uniquenessString;
            NIdPairs = nIdPairs;
        }
    }
}
