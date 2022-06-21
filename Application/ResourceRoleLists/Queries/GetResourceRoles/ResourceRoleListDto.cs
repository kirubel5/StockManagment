using Application.ResourceRoleLists.Commands.UpdateResourceRoleList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResourceRoleLists.Queries.GetResourceRoles
{
    public class ResourceRoleListDto
    {
        public List<ResourceRoleDto> List { get; set; } = new List<ResourceRoleDto>();
    }
}
