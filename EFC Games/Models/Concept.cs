using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Games.Models
{
    public class Concept
    {
        public int ConceptId { get; set; }


       // public int ProductId { get; set; }
        public virtual Product Product { get; set; }

       // public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public SaleItem SaleItem { get; set; }

    }
}
