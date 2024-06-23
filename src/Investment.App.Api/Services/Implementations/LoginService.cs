using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Investment.App.Api.Exceptions;
using Investment.App.Api.Models;
using Investment.App.Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Investment.App.Api.Services.Implementations;

public class LoginService : ILoginService
{
    private readonly string _userLogin;
    private readonly string _userPassword;
    private readonly string _adminLogin;
    private readonly string _adminPassword;
    private readonly string _jwtKey;
    private readonly string _jwtIssuer;
    public LoginService(IConfiguration _configuration)
    {
        const string customerLoginKey = "Users:Customer:Login", customerPasswordKey = "Users:Customer:Password";
        _userLogin = _configuration.GetSection(customerLoginKey).Get<string>() ?? throw new EmptyConfigException(customerLoginKey);
        _userPassword = _configuration.GetSection(customerPasswordKey).Get<string>() ?? throw new EmptyConfigException(customerPasswordKey);

        const string adminLoginKey = "Users:Admin:Login", adminPasswordKey = "Users:Admin:Password";
        _adminLogin = _configuration.GetSection(adminLoginKey).Get<string>() ?? throw new EmptyConfigException(adminLoginKey);
        _adminPassword = _configuration.GetSection(adminPasswordKey).Get<string>() ?? throw new EmptyConfigException(adminPasswordKey);

        const string jwtKey = "Jwt:Key", jwtIssuer = "Jwt:Issuer";
        _jwtKey = _configuration.GetSection(jwtKey).Get<string>() ?? throw new EmptyConfigException(jwtKey);
        _jwtIssuer = _configuration.GetSection(jwtIssuer).Get<string>() ?? throw new EmptyConfigException(jwtIssuer);
    }
    public Login Authenticate(string userName, string password)
    {
        if (userName == _userLogin && password == _userPassword)
            return GenerateToken(false);
        else if (userName == _adminLogin && password == _adminPassword) return GenerateToken(true);
        else
            return new()
            {
                IsValid = false
            };
    }

    private Login GenerateToken(bool isAdmin){

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.Now.AddHours(2);

            var claims = Enumerable.Empty<Claim>();

            claims = claims.Append(new Claim(ClaimTypes.Role, isAdmin ? "Admin" : "User"));

            var Sectoken = new JwtSecurityToken(_jwtIssuer, _jwtIssuer,
              claims,
              expires: expireDate,
              signingCredentials: credentials);

            var token =  new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return new (){
                IsValid = true,
                Token = token,
                ExpiresIn = expireDate.ToUniversalTime()
            };
    }
}
