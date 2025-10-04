using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DevSocial.Domain.Entitie;
using DevSocial.Domain.Security.Tokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace DevSocial.Infrastructure.Security.Tokens;

public class JwtTokenGenerator : IAcessTokenGenerator
{

    private readonly uint _expirationTime;
    private readonly string _signingKey;


    public JwtTokenGenerator(uint expirationTime, string signingKey)
    {
        _expirationTime = expirationTime;
        _signingKey = signingKey;
    }
    
    
    public string GenerateToken(UserEntitie user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Sid, user.UserIdentifier.ToString()),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(_expirationTime),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(securityToken);
    }
    
    private SymmetricSecurityKey SecurityKey()
    {
        var key = Encoding.UTF8.GetBytes(_signingKey);
        
        return new SymmetricSecurityKey(key);
    }
}