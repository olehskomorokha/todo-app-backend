using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TodoApp.Interfaces.Interfaces;
using TodoApp.Services.Exceptions;
using TodoApp.Services.Helpers;
using TodoApp.Services.Interfaces;
using TodoApp.Services.Models.User;

namespace TodoApp.Services.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public JwtService(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public async Task<string> Authenticate(LoginUserDto userDto)
    {
        if (string.IsNullOrWhiteSpace(userDto.Email) || string.IsNullOrWhiteSpace(userDto.Password))
        {
            throw new LoginException("login_exception", "user email or password cant be null");
        }

        var userAccount = await _userRepository.GetByEmailAsync(userDto.Email);
        if (userAccount == null || !PasswordHashHelper.VarifyPassword(userDto.Password, userAccount.Password))
        {
            throw new LoginException("login_exception", "incorrect password");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, userDto.Email),
            new Claim(ClaimTypes.NameIdentifier, userAccount.Id.ToString())
        };

        var jwt = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(60),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}