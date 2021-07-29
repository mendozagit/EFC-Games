using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Games.Models
{
    public class MoralPerson
    {
        public int MoralPersonId { get; set; }

        public string Name { get; set; }

        public virtual Entity Entity { get; set; }
    }
}
