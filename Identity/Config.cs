using Duende.IdentityServer.Models;

namespace Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                 new IdentityResources.OpenId(),
                 new IdentityResources.Email(),
                 new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                 new Client
                 {
                    RequirePkce = false,
                    ClientId = "mvc",
                    ClientName = "MVC Demo",
                    RequireConsent = false,
                    //AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    //RedirectUris = { "http://localhost:42468/signin-oidc" },
                    RedirectUris = { "https://localhost:44363/signin-oidc" },
                    PostLogoutRedirectUris = {"https://localhost:44363/signout-callback-oidc"},
                    AllowedScopes = { "openid", "profile", "email", "api1"}
                 }
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("api1", "Demo Api")
            };
    }
}