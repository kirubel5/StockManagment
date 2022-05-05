using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoleList.Queries.GetRolesQuery
{
    public class RoleList
    {
        public IList<RoleListDto> Lists { get; set; } = new List<RoleListDto>();
    }
}
