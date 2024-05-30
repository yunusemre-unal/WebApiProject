using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Extensions;
using Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        IConfiguration Configuration { get; }
        TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }
        public AccessToken CreateToken(User user, List<OperationClaimDto> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions,user,operationClaims,signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken() {Token=token,Expiration=_accessTokenExpiration };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,List<OperationClaimDto> operationClaims,SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer:tokenOptions.Issuer,
                audience:tokenOptions.Audience,
                expires:_accessTokenExpiration,
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials,
                claims:SetClaims(user,operationClaims)                
                
                );
            return jwt;
           
        }

        private IEnumerable<Claim> SetClaims(User user,List<OperationClaimDto> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddName($"{user.FirstName}  {user.LastName}");
            claims.AddNameId(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(x=>x.Name).ToArray()); 
            return claims;

        }
    }
}
