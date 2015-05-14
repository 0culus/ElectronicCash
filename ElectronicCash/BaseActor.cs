using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicCash
{
    public abstract class BaseActor
    {
        public string Name { get; set; }
        public Guid ActorGuid { get; set; }
    }
}
