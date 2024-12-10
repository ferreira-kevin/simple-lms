using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace lms.Domain;

[Index(nameof(Email), nameof(Identity), IsUnique = true)]
public class UserModel
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Identity { get; set; }
    [Required]
    [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
    public string HashedPassword { get; set; }
    public List<Role> Roles { get; set; } = new();
    public DateOnly BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public AddressModel Address { get; set; }
    public TeacherModel? Teacher { get; set; }
    public StudentModel? Student { get; set; }

    public UserModel() { }

    public UserModel(Guid id)
    {
        Id = id;
    }

    public UserModel(Guid id, string fullName, string email, string identity, string phone, string hashedPassword, List<Role> roles, DateOnly birthDate, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        Identity = identity;
        Phone = phone;
        HashedPassword = hashedPassword;
        BirthDate = birthDate;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Roles = roles;
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
}
