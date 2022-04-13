using StockManagment.Application.Common.Mappings;
using StockManagment.Domain.Entities;

namespace StockManagment.Application.LineItems.Queries.GetLineItem
{
    public class LineItemDto : IMapFrom<LineItem>
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public string Reference { get; set; }
        public string Element { get; set; }
        public double UnitAmount { get; set; }
        public double Quantity { get; set; }
        public double TaxableAmount { get; set; }
        public string TaxType { get; set; }
        public double TaxAmount { get; set; }
        public double Cost { get; set; }
    }
}
