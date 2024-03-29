﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
//using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace FreeCourse.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes={"catalog_fullpermisson"}},
            new ApiResource("resource_photo_stock"){Scopes={"photo_stock_fullpermisson"}},
            new ApiResource("resource_basket"){Scopes={"basket_fullpermisson"}},
            new ApiResource("resource_discount"){Scopes={"discount_fullpermisson"}},
            new ApiResource("resource_order"){Scopes={"order_fullpermisson"}},
            new ApiResource("resource_payment"){Scopes={"payment_fullpermisson"}},
            new ApiResource("resource_gateway"){Scopes={"gateway_fullpermisson"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName),
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.Email(),
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                        new IdentityResource()
                        {
                            Name="roles",
                            DisplayName="Roles",
                            Description="Kullanıcı rolleri",
                            UserClaims = new[]
                            {
                                "role"
                            }
                        }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermisson","Catalog API için full erişim"),
                new ApiScope("photo_stock_fullpermisson","Photo Stock API için full erişim"),
                new ApiScope("basket_fullpermisson","Basket API için full erişim"),
                new ApiScope("discount_fullpermisson","Discount API için full erişim"),
                new ApiScope("order_fullpermisson","Order API için full erişim"),
                new ApiScope("payment_fullpermisson","Payment API için full erişim"),
                new ApiScope("gateway_fullpermisson","Gateway API için full erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
               new Client
               {
                   ClientName="Asp.Net Core MVC",
                   ClientId="WebMvcClient",
                   ClientSecrets={new Secret("secret".Sha256())},
                   AllowedGrantTypes=GrantTypes.ClientCredentials,
                   AllowedScopes={ "catalog_fullpermisson", "photo_stock_fullpermisson",IdentityServerConstants.LocalApi.ScopeName}
               },
                new Client
               {
                   ClientName="Asp.Net Core MVC",
                   ClientId="WebMvcClientForUser",
                   AllowOfflineAccess=true,
                   ClientSecrets={new Secret("secret".Sha256())},
                   AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                   AllowedScopes={
                        "basket_fullpermisson",
                        "discount_fullpermisson",
                        "order_fullpermisson",
                        "payment_fullpermisson",
                        "gateway_fullpermisson",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,IdentityServerConstants.LocalApi.ScopeName,"roles" },
                   AccessTokenLifetime=1*60*60,
                   RefreshTokenExpiration=TokenExpiration.Absolute,
                   AbsoluteRefreshTokenLifetime=(int)(DateTime.UtcNow.AddDays(60)-DateTime.Now).TotalSeconds,
                   RefreshTokenUsage=TokenUsage.ReUse
                   
               }
            };
    }
}