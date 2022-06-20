using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ResourceRole
    {
        public Guid ResourceId { get; set; }
        public Guid RoleId { get; set; }
    }
}
