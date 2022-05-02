using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using TaskPlanner2.Models.DataBase;
using TaskPlanner2.Services.Abstract;

namespace TaskPlanner2.Services
{
    public class Authentication : IAuthentication
    {
        private IHttpContextAccessor HttpContextAccessor { get; set; }
        public Authentication(IHttpContextAccessor context)
        {
            HttpContextAccessor = context;
        }

        public async void Authenticate(User userToAuthenticate)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userToAuthenticate.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userToAuthenticate.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(
                claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
            );

            await HttpContextAccessor.HttpContext
                .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async void Logout()
        {
            await HttpContextAccessor.HttpContext
                .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
