using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Games.Models
{
    public class SaleItemTax
    {
        public int SaleItemTaxId { get; set; }

        public int SaleItemId { get; set; }
        public virtual SaleItem SaleItem { get; set; }
        public string Name { get; set; }
        public string TACode { get; set; }
        public decimal Base { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }

    }
}
