using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicCash
{
    /// <summary>
    /// The base actor abstracts all common properties of our actors (mainly Bank, Merchant, Customer)
    /// </summary>
    public abstract class BaseActor
    {
        public string Name { get; set; }
        public Guid ActorGuid { get; set; }
        public Int32 Money { get; set; }
        public Dictionary<Guid, List<MoneyOrder>> Ledger { get; protected set; }
    }
}
