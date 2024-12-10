using lms.Data.Repositories;
using lms.Domain;

namespace lms.UseCases.Manager.AcademicRecord;

public interface IUpdateStudent
{
    Task<string?> Execute(StudentModel student);
}

public class UpdateStudent(IStudentRepository studentRepository) : IUpdateStudent
{
    public async Task<string?> Execute(StudentModel student)
    {
        //if (!student.IsValid())
        //    return "Revise o formulário, existem dados inválidos.";
        try
        {
            await studentRepository.UpdateAsync(student);
        }
        catch (Exception ex)
        {
            return "O serviço está indisponível no momento, se o erro persistir entre em contato com suporte.";
        }

        return default;
    }
}
