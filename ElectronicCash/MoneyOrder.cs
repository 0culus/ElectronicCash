using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicCash
{
    /// <summary>
    /// holds the data for a money order
    /// </summary>
    [Serializable]
    public class MoneyOrder
    {
        public string Amount { get; set; }
        public byte[] UniquenessString { get; set; }
        public List<IdentityStringPair<Byte[]>> NIdPairs { get; set; }

        public MoneyOrder(string _amount,
            byte[] uniquenessString,
            List<IdentityStringPair<byte[]>> nIdPairs)
        {
            Amount = _amount;
            UniquenessString = uniquenessString;
            NIdPairs = nIdPairs;
        }
    }
}
