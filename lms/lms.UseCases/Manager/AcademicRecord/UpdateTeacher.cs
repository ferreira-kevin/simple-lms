using lms.Data.Repositories;
using lms.Domain;

namespace lms.UseCases.Manager.AcademicRecord;

public interface IUpdateTeacher
{
    Task<string?> Execute(TeacherModel Teacher);
}

public class UpdateTeacher(ITeacherRepository TeacherRepository) : IUpdateTeacher
{
    public async Task<string?> Execute(TeacherModel Teacher)
    {
        //if (!Teacher.IsValid())
        //    return "Revise o formulário, existem dados inválidos.";
        try
        {
            await TeacherRepository.UpdateAsync(Teacher);
        }
        catch (Exception ex)
        {
            return "O serviço está indisponível no momento, se o erro persistir entre em contato com suporte.";
        }

        return default;
    }
}
