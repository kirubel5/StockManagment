using StockManagment.Application.Common.Mappings;
using StockManagment.Domain.Entities;

namespace StockManagment.Application.Consignees.Queries.GetConsignee
{
    public class ConsigneeDto : IMapFrom<Consignee>
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string TradeName { get; set; }
        public string BusinessType { get; set; }
        public string Group { get; set; }
    }
}
