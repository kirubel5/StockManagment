using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObjectTypeLists.Queries.GetObjectTypesQuery
{
    public class ObjectTypeList
    {
        public IList<ObjectTypeListDto> Lists { get; set; } = new List<ObjectTypeListDto>();
    }
}
