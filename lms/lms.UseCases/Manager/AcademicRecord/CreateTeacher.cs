using lms.Data.Repositories;
using lms.Domain;
using lms.Domain.Utils;

namespace lms.UseCases.Manager.AcademicRecord;

public interface ICreateTeacher
{
    Task<string?> Execute(NewTeacherForm TeacherForm);
}

public class CreateTeacher(ITeacherRepository TeacherRepository) : ICreateTeacher
{
    public async Task<string?> Execute(NewTeacherForm TeacherForm)
    {
        if (!TeacherForm.IsValid())
            return "Revise o formulário, existem dados inválidos.";
        var password = PasswordGenerator.GenerateStrongPassword(12);
        var Teacher = TeacherForm.ToTeacherModel(password);
        try
        {
            await TeacherRepository.AddAsync(Teacher);
        }
        catch(Exception ex)
        {
            return "O serviço está indisponível no momento, se o erro persistir entre em contato com suporte.";
        }

        return default;
    }
}

public class NewTeacherForm
{
    public string FullName { get; set; }
    public string Identity { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateOnly BirthDate { get; set; }

    public NewTeacherForm()
    {
        FullName = string.Empty;
        Identity = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        var defaultDate = DateTime.UtcNow.AddYears(-18);
        BirthDate = DateOnly.FromDateTime(defaultDate);
    }

    public bool IsValid() => !string.IsNullOrWhiteSpace(FullName) && !string.IsNullOrWhiteSpace(Identity);

    public TeacherModel ToTeacherModel(string temporaryPassword) =>
        new TeacherModel(FullName, Email, Identity, Phone, temporaryPassword, BirthDate);
}
