using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.Identity
{
    public class AuthenticationResponse
    {
        public DateTime ExpireOn { get; set; }
        public string Token { get; set; } = string.Empty;
    }

}
