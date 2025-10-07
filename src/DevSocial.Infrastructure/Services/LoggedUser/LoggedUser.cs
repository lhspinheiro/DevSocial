using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DevSocial.Domain.Entitie;
using DevSocial.Domain.Security.Tokens;
using DevSocial.Domain.Services.LoggedUser;
using DevSocial.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DevSocial.Infrastructure.Services.LoggedUser;

public class LoggedUser : ILoggedUser
{
    private readonly DevSocialDbContext  _context;
    private readonly ITokenProvider  _tokenProvider;

    public LoggedUser(DevSocialDbContext  context, ITokenProvider tokenProvider)
    {
        _context = context;
        _tokenProvider = tokenProvider;
    }
    
    public async Task<UserEntitie> Get()
    {
        string token = _tokenProvider.TokenOnRequest();
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        return await _context.Users.AsNoTracking().FirstAsync(user => user.UserIdentifier == Guid.Parse(identifier));
    }
}