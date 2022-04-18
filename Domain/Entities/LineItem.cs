using StockManagment.Domain.Common;
using System.Collections.Generic;

namespace StockManagment.Domain.Entities
{
    public class LineItem : EntityCommon
    {       
        public float UnitAmount { get; set; }
        public float Quantity { get; set; }
        public float TaxableAmount { get; set; }
        public string TaxType { get; set; } = "VAT";
        public float TaxAmount { get; set; }   
        public string ElementCode { get; set; }
        public string VoucherCode { get; set; }
    }
}
