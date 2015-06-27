using System;
using System.Collections.Generic;

namespace ElectronicCash
{
    /// <summary>
    /// The base actor abstracts all common properties of our actors (mainly Bank, Merchant, Customer)
    /// </summary>
    public abstract class BaseActor
    {
        public string Name { get; protected set; }
        public Guid ActorGuid { get; protected set; }
        public Int32 Money { get; protected set; }
        public Dictionary<Guid, List<MoneyOrder>> Ledger { get; protected set; }
    }
}
