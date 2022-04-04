using StockManagment.Domain.Common;

namespace StockManagment.Domain.Entities
{
    public class Consignee : EntityActivity
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string TradeName { get; set; }
        public string BusinessType { get; set; }
        public string Group { get; set; }
    }
}
