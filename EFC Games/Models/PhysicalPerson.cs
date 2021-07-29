using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Games.Models
{
    public class PhysicalPerson
    {
        public int PhysicalPersonId { get; set; }

        public string Name { get; set; }

        public virtual Entity Entity { get; set; }
    }
}
