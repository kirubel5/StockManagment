using StockManagment.Application.Common.Mappings;
using StockManagment.Domain.Entities;

namespace Application.ObjectTypeLists.Queries.GetObjectTypesQuery
{
    public class ObjectTypeListDto : IMapFrom<ObjectType>
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    }
}
