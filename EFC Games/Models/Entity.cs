using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Games.Models
{
    public class Entity
    {
        public int EntityId { get; set; }

        public virtual PhysicalPerson PhysicalPerson { get; set; }
        public virtual MoralPerson MoralPerson { get; set; }
    }
}
