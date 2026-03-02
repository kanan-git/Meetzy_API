using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Entities.Auth;
using Entities.DTOs.Auth;
using System.Text;
using System.Security.Claims;

namespace WebAPI.Controllers.Auth;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly Entities.Auth.TokenOptions _tokenOptions;

    public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;
        _configuration = configuration;
        _tokenOptions = _configuration.GetSection("TokenOptions").Get<Entities.Auth.TokenOptions>();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto register)
    {
        var user = _mapper.Map<AppUser>(register);
        var addeduser = await _userManager.CreateAsync(user, register.Password);
        if(!addeduser.Succeeded)
        {
            return BadRequest(new
            {
                Errors = addeduser.Errors,
                Code = 400
            });
        }
        if(!await _roleManager.RoleExistsAsync("User"))
        {
            await _roleManager.CreateAsync(new IdentityRole("User"));
        }
        await _userManager.AddToRoleAsync(user, "User");
        return Ok("Successfully registered");
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto login)
    {
        var user = await _userManager.FindByNameAsync(login.UserName);
        if(user is null)
        {
            return NotFound();
        }
        if(!await _userManager.CheckPasswordAsync(user, login.Password))
        {
            return Unauthorized();
        }
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
        SigningCredentials signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
        JwtHeader header = new JwtHeader(signingCredentials);
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("FullName", user.FirstName + user.LastName)
        };
        foreach (var role in await _userManager.GetRolesAsync(user))
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        JwtPayload payload = new JwtPayload(issuer: _tokenOptions.Issuer, audience: _tokenOptions.Audience, claims: claims, notBefore: DateTime.UtcNow, expires: DateTime.Now.AddHours(_tokenOptions.AccessTokenExpiration));
        JwtSecurityToken securityToken = new JwtSecurityToken(header, payload);
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        string mytoken = handler.WriteToken(securityToken);
        return Ok(new
        {
            Token=mytoken,
            Expires=DateTime.Now.AddHours(_tokenOptions.AccessTokenExpiration)
        });
    }
}
