// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace ECommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                     new IdentityResources.OpenId(),
                     new IdentityResources.Profile(),
                     new IdentityResources.Email()
                   };


        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("catalog_resource")
                {
                    Scopes = { "catalog_fullpermission","catalog_readpermission" }
                },

                new ApiResource("discount_resource")
                {
                    Scopes = { "discount_fullpermission" }
                },

                new ApiResource("basket_resource")
                {
                    Scopes = { "basket_fullpermission" }
                },

                new ApiResource("order_resource")
                {
                    Scopes = { "order_fullpermission" }
                },

                new ApiResource("message_resource")
                {
                    Scopes = { "message_fullpermission" }
                },
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
                

            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission", "Full Permission for Catalog Service"),
                new ApiScope("catalog_readpermission", "Read Permission for Catalog Service"),
                new ApiScope("discount_fullpermission", "Full Permission for Discount Service"),
                new ApiScope("basket_fullpermission", "Full Permission for Basket Service"),
                new ApiScope("order_fullpermission", "Full Permission for Order Service"),
                new ApiScope("message_fullpermission", "Full Permission for Message Service"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName, "Full Permission for Local API")

            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
              //Admin
              new Client
                {
                    ClientId = "ECommerceAdminClient",
                    ClientName = "Admin",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes =
                  {
                                      "catalog_fullpermission",
                                      "discount_fullpermission",
                                      "basket_fullpermission",
                                      "order_fullpermission",
                                      "message_fullpermission",
                                      IdentityServerConstants.StandardScopes.Email,
                                      IdentityServerConstants.StandardScopes.OpenId,
                                      IdentityServerConstants.StandardScopes.Profile,
                                      IdentityServerConstants.LocalApi.ScopeName


                  },
                    AccessTokenLifetime = 600
               },

              //Visitor
              new Client
              {
                        ClientId = "ECommerceVisitorClient",
                        ClientName = "Visitor",
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        AllowedScopes =
                    
                        {
                                        "catalog_readpermission",
                                        IdentityServerConstants.LocalApi.ScopeName
                        }
              }

            };
    }
}