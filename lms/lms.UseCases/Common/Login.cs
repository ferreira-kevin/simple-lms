using lms.Domain;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lms.UseCases.Common;

public class Login(IConfiguration _configuration) : ILogin
{
    public List<Role> Execute(string username, string password)
    {
        return IsValidUserCredentials(username, password);
        //if (IsValidUserCredentials(username, password))
        //{
        //    //var token = GenerateJwtToken(password);

        //    //_httpContextAccessor.HttpContext?.Response.Cookies.Append("auth_token", token, new CookieOptions
        //    //{
        //    //    HttpOnly = true,            // Impede acesso por JavaScript (proteção contra XSS)
        //    //    Secure = true,               // Requer HTTPS
        //    //    SameSite = SameSiteMode.Strict, // Evita envio em requisições entre sites (proteção contra CSRF)
        //    //    Expires = DateTimeOffset.UtcNow.AddHours(1) // Expiração do cookie
        //    //});

        //    return true;
        //}

        //return false;
    }

    public async Task<User> GetAuthenticatedUserAsync()
    {
        return null;
        //var token = _httpContextAccessor.HttpContext?.Request.Cookies["auth_token"];
        //if (string.IsNullOrEmpty(token))
        //{
        //    return null; // Retorna null se o token não estiver presente
        //}

        //// Valida e decodifica o token usando um serviço de validação de token
        //var claimsPrincipal = _tokenValidator.ValidateToken(token);
        //if (claimsPrincipal == null)
        //{
        //    return null; // Retorna null se o token for inválido
        //}

        //// Extrai as informações do usuário a partir dos claims do token
        //var username = claimsPrincipal.FindFirst(ClaimTypes.Name)?.Value;
        //var roles = claimsPrincipal.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

        //// Retorna as informações do usuário autenticado
        //return new User
        //{
        //    Username = username,
        //    Roles = roles
        //};
    }

    private string GenerateJwtToken(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, username)
                // Você pode adicionar mais claims aqui, como ClaimTypes.Role
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private List<Role> IsValidUserCredentials(string username, string password)
    {
        var users = new List<UserModel>
        {
            new(Guid.NewGuid(), "Admin", "", "123", [Role.Administrator], DateTime.Now, DateTime.Now),
            new(Guid.NewGuid(), "Teacher", "", "123", [Role.Teacher], DateTime.Now, DateTime.Now),
            new(Guid.NewGuid(), "Student", "", "123", [Role.Student], DateTime.Now, DateTime.Now),
        };

        return users.FirstOrDefault(u => u.FullName.Equals(username, StringComparison.OrdinalIgnoreCase) && u.HashedPassword == password).Roles ?? [];
        //return users.Exists(u => u.Name.Equals(username, StringComparison.OrdinalIgnoreCase) && u.HashedPassword == password);
    }
}

public interface ILogin
{
    List<Role> Execute(string username, string password);
    Task<User> GetAuthenticatedUserAsync();
}

public class User
{
    public string Username { get; set; }
    public List<string> Roles { get; set; }
}


//public class AuthenticationService
//{
//    private readonly List<User> _users;

//    public AuthenticationService()
//    {
//        _users = new List<User>
//        {
//            new User { Id = Guid.NewGuid(), Username = "admin", Password = "admin123", Role = Role.Administrator },
//            new User { Id = Guid.NewGuid(), Username = "teacher", Password = "teacher123", Role = Role.Teacher },
//            new User { Id = Guid.NewGuid(), Username = "student", Password = "student123", Role = Role.Student }
//        };
//    }

//    public User? Login(string username, string password)
//    {
//        return _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);
//    }
//}
