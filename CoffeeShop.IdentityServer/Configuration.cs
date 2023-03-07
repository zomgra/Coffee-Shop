using IdentityServer4.Models;

namespace CoffeeShop.IdentityServer
{
    public class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("CoffeeService", "Coffee API")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            yield return new Client()
            {
                ClientId = "react-client-id",
                ClientName = "My React App",
                AllowedGrantTypes = GrantTypes.Implicit,
                // don't require client to send secret to token endpoint
                RequireClientSecret = false,
                RedirectUris =
                {
                    // can redirect here after login                     
                    "http://localhost:3000/signin-oidc",
                    "http://localhost:3000/silent-renew",
                },
                // can redirect here after logout
                PostLogoutRedirectUris = { "http://localhost:3000/signout-oidc",  },
                // builds CORS policy for javascript clients
                AllowedCorsOrigins = { "http://localhost:3000" },
                AccessTokenLifetime = 36000,
                AllowOfflineAccess = true,
                // client is allowed to receive tokens via browser
                AllowAccessTokensViaBrowser = true,
                AllowedScopes = { "openid", "profile", "CoffeeService", "offline_access" },
            };
        }
        public static IEnumerable<ApiScope> GetScopes()
        {
            yield return new ApiScope("CoffeeService", "Cofee API");
        }
    }
}
