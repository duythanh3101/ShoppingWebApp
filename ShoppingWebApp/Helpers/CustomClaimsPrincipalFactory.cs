﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ShoppingWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoppingWebApp.Helpers
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, AppRole>
    {
        UserManager<AppUser> _userManager;
        public CustomClaimsPrincipalFactory(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            _userManager = userManager;
        }

        public async override Task<ClaimsPrincipal> CreateAsync(AppUser user)
        {
            var principal = await base.CreateAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            (principal.Identity as ClaimsIdentity).AddClaims(new[]
            {
                new Claim("Email",user.Email),
                new Claim("FullName",user.FullName),
                new Claim("Avatar",user.Avatar??string.Empty),
                new Claim("Roles",string.Join(";",roles)),
                new Claim("UserId",user.Id.ToString())
            });

            return principal;
        }
    }
}
