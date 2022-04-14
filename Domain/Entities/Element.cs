using StockManagment.Domain.Common;

namespace StockManagment.Domain.Entities
{
    public class Element : EntityActivity
    {
        public string Name { get; set; }
        public string UOM { get; set; }
    }
}
