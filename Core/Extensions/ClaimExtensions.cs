﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims,string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email,email));
        }

        public static void AddName(this ICollection<Claim> claims,string name) 
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Name,name));
        }

        public static void AddNameId(this ICollection<Claim> claims,string id) 
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.NameId,id)); 
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] role) 
        {
            role.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
