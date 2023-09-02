
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using event_planning_test_api.Data.Entities;
using event_planning_test_api.Data.Options;
using event_planning_test_api.Domain.Commands;
using event_planning_test_api.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace event_planning_test_api.Domain.Services;

public class JWTManagerServices : IJWTManager
{
    private readonly UserManager<UserEntity> userManager;
    private readonly IOptions<JwtOptions> jwtOptions;

    public JWTManagerServices(
        UserManager<UserEntity> userManager,
        IOptions<JwtOptions> jwtOptions)
    {
        this.userManager = userManager;
        this.jwtOptions = jwtOptions;
    }

    public async Task<UserTokenData> GenerateToken(string userEmail)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(
            jwtOptions.Value
                .Key);
        var roles = (await userManager.GetRolesAsync(
            await userManager.FindByEmailAsync(userEmail)))
                .ToList();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.Now.AddMinutes(3),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, userEmail),
        };
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        tokenDescriptor.Subject = new ClaimsIdentity(claims);
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new UserTokenData
        {
            AccessToken = tokenHandler.WriteToken(token),
        };
    }
}
