using StockManagment.Application.Common.Mappings;
using StockManagment.Domain.Entities;

namespace StockManagment.Application.ObjectTypes.Queries.GetObjectType
{
    public class ObjectTypeDto : IMapFrom<ObjectType>
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    }
}
