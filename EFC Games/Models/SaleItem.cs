using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Games.Models
{
    public class SaleItem
    {
        public int SaleItemId { get; set; }

        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }

        public int ConceptId { get; set; }
        public virtual Concept Concept { get; set; }

        public string Desription { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Qty { get; set; }


        public virtual List<SaleItemTax> SaleItemTaxes { get; set; }
    }
}
