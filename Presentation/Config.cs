//using IdentityServer4.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Presentation
//{
//    public class Config
//    {
//        public static IEnumerable<Client> GetClients()
//        {
//            return new Client[]
//            {
//                new Client
//                {
//                    ClientId = "mvc",
//                    ClientName = "MVC Demo",
//                    RequireConsent = false,
//                   //AllowedGrantTypes = GrantTypes.Implicit,
//                    AllowedGrantTypes = GrantTypes.Hybrid,
//                    ClientSecrets = { new Secret("secret".Sha256()) },
//                    RedirectUris = { "http://localhost:42468/signin-oidc" },
//                    PostLogoutRedirectUris = {"https://localhost:42468/signout-callback-oidc"},
//                    AllowedScopes = { "openid", "profile", "email", "api1" }
//                }
//            };
//        }

//        public static IEnumerable<IdentityResource> GetIdentityResources()
//        {
//            return new IdentityResource[]
//            {
//                new IdentityResources.OpenId(),
//                new IdentityResources.Email(),
//                new IdentityResources.Profile()
//            };
//        }

//        public static IEnumerable<ApiResource> GetApiResources()
//        {
//            return new ApiResource[] 
//            {
//                new ApiResource("api1", "Demo Api")
//            };
//        }
//    }
//}
