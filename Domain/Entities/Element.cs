using StockManagment.Domain.Common;

namespace StockManagment.Domain.Entities
{
    public class Element : EntityActivity
    {
        public string Description { get; set; }
        public string UOM { get; set; }
        public string Group { get; set; }
        public string Type { get; set; }
    }
}
