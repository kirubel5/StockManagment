using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResourceRoleLists.Commands.UpdateResourceRoleList
{
    public class ResourceRoleListDto
    {
        List<ResourceRoleDto> List { get; set; } = new List<ResourceRoleDto>();
    }
}
