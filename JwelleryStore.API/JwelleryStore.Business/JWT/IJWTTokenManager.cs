using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwelleryStore.Business.JWT
{
    public interface IJWTTokenManager
    {
        string GenerateTokens(Claim[] claims, DateTime date);
        public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
    }
}
