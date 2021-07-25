using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Games.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Taxes { get; set; }
        public decimal Total { get; set; }


        public virtual List<SaleItem> SaleItems { get; set; }
        public virtual List<SaleTax> SaleTaxes { get; set; }
    }
}
