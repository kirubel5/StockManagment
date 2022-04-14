using StockManagment.Application.Common.Mappings;
using StockManagment.Domain.Entities;

namespace Application.ElementLists.Queries.GetElements
{
    public class ElementListDto : IMapFrom<Element>
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string UOM { get; set; }
    }
}
