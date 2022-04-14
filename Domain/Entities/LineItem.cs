using StockManagment.Domain.Common;
using System.Collections.Generic;

namespace StockManagment.Domain.Entities
{
    public class LineItem : EntityCommon
    {
       
        public double UnitAmount { get; set; }
        public double Quantity { get; set; }
        public double TaxableAmount { get; set; } 
        public string TaxType { get; set; }
        public double TaxAmount { get; set; }   
        public string ElementCode { get; set; }
        public string VoucherCode { get; set; }
    }
}
