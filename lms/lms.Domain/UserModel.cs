using System.Security.Claims;

namespace lms.Domain;

public class UserModel
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Identity { get; set; }
    public string HashedPassword { get; set; }
    public List<Role> Roles { get; set; } = new();
    public DateOnly BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public AddressModel Address { get; set; }
    public TeacherModel Teacher { get; set; }
    public StudentModel Student { get; set; }

    public UserModel()
    {

    }

    public UserModel(Guid id, string name, string phone, string hashedPassword, List<Role> roles, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        FullName = name;
        Phone = phone;
        HashedPassword = hashedPassword;
        Roles = roles;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public override string ToString()
    {
        return $"{FullName} ({Phone})";
    }


    public ClaimsPrincipal ToClaimsPrincipal() => new(new ClaimsIdentity(new Claim[]
    {
        new (ClaimTypes.Name, FullName),
        new (ClaimTypes.Hash, HashedPassword),
    }.Concat(Roles.Select(r => new Claim(ClaimTypes.Role, r.ToString())).ToArray()), "Plataforma Educacional"));

    //public static UserModel FromClaimsPrincipal(ClaimsPrincipal principal) => new()
    //{
    //    Name = principal.FindFirst(ClaimTypes.Name)?.Value ?? "",
    //    HashedPassword = principal.FindFirst(ClaimTypes.Hash)?.Value ?? "",
    //    Roles = principal.FindAll(ClaimTypes.Role).Select(c => (Role)Enum.Parse(typeof(Role), c.Value)).ToList()
    //};
}
