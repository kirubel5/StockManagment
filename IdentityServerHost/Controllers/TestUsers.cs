using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerHost.Controllers
{
    public class TestUsers
    {
        public static List<TestUser> Users = new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "818727",
                Username = "alice",
                Password = "alice",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Alice Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Alice"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.Email, "Alice@gmail.com")
                }
            }
        };
    }
}
