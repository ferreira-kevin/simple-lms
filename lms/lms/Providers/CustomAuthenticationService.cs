using System.Security.Claims;
using static lms.Domain.Utils.Constants;

namespace lms.Providers;

public class CustomAuthenticationService
{
    public event Action<ClaimsPrincipal>? UserChanged;
    private ClaimsPrincipal? currentUser;

    public ClaimsPrincipal CurrentUser
    {
        get { return currentUser ?? new(); }
        set
        {
            currentUser = value;

            if (UserChanged is not null)
            {
                UserChanged(currentUser);
            }
        }
    }

    public void Logout() => CurrentUser = new ClaimsPrincipal(new ClaimsIdentity());

    public string GetUserRole()
    {
        //return CurrentUser.Identity.Name;
        return CurrentUser.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
    }

    public bool IsAdmin() => CurrentUser.Identity.Name.ToLowerInvariant() == UserRoles.Admin.ToLowerInvariant();
    public bool IsTeacher() => CurrentUser.Identity.Name.ToLowerInvariant() == UserRoles.Teacher.ToLowerInvariant();
    public bool IsStudent() => CurrentUser.Identity.Name.ToLowerInvariant() == UserRoles.Student.ToLowerInvariant();
}