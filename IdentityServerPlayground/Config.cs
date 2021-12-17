// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerPlayground
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("TestApi", "Test API"),
                new ApiScope("profile"),
                new ApiScope("email"),
                new ApiScope("read"),
                new ApiScope("write"),
                new ApiScope("identity-server-demo-api")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource
                {
                    Name = "identity-server-demo-api",
                    DisplayName = "Identity Server Demo API",
                    Scopes = new List<string>
                    {
                        "write",
                        "read"
                    }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes = { "TestApi" }
                },
                new Client
                {
                    ClientId="identity-server-demo-web",
                    AllowedGrantTypes = new List<string>{GrantType.AuthorizationCode},
                    RequireClientSecret=false,
                    RequireConsent=false,
                    RedirectUris= new List<string>{ "http://localhost:3006/signin-callback.html" },
                    PostLogoutRedirectUris= new List<string>{ "http://localhost:3006/" },
                    AllowedScopes = { "identity-server-demo-api", "write", "read", "openid", "profile", "email" },
                    AllowedCorsOrigins= new List<string>{ "http://localhost:3006" },
                    AccessTokenLifetime = 86400
                }
            };
    }
}