using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend_api.Migrations;
using backend_api.Models;
using Microsoft.IdentityModel.Tokens;
using bcrypt = BCrypt.Net.BCrypt;

namespace backend_api.Repositories;

public class AuthService : IAuthService
{

    private static PostDbContext _context;

    private static IConfiguration _config;

    public AuthService(PostDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public User CreateUser(User user)
    {

        var passwordHash = bcrypt.HashPassword(user.Password);
        user.Password = passwordHash;

        _context.Add(user);
        _context.SaveChanges();
        return user;
    }

    public string SignIn(string UserName, string password)
    {
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == UserName);
            var verified = false;

            if (user != null)
            {
                verified = bcrypt.Verify(password, user.Password);
            }

            if (user == null || !verified)
            {
                return String.Empty;
            }

            // Create & return JWT
            return BuildToken(user);
        }
    }


    private string BuildToken(User user)
    {
        var secret = _config.GetValue<String>("TokenSecret");
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        // Create Signature using secret signing key
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        // Create claims to add to JWT payload
        var claims = new Claim[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
        new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName ?? ""),
        new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName ?? ""),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? ""),
        new Claim(ClaimTypes.PostalCode, user.ZipCode.ToString()),
        new Claim(ClaimTypes.StateOrProvince, user.State ?? ""),
        new Claim(JwtRegisteredClaimNames.Nonce, user.City ?? ""),
        };

        // Create token
        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: signingCredentials);

        // Encode token
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }

}