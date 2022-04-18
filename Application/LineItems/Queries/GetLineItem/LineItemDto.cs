using StockManagment.Application.Common.Mappings;
using StockManagment.Domain.Entities;

namespace StockManagment.Application.LineItems.Queries.GetLineItem
{
    public class LineItemDto : IMapFrom<LineItem>
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public float UnitAmount { get; set; }
        public float Quantity { get; set; }
        public float TaxableAmount { get; set; }
        public string TaxType { get; set; } = "VAT";
        public float TaxAmount { get; set; }
        public string ElementCode { get; set; }
        public string VoucherCode { get; set; }
    }
}
