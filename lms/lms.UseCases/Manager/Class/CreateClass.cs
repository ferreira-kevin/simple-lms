using lms.Data.Repositories;
using lms.Domain;

namespace lms.UseCases.Manager.Class;

public interface ICreateClass
{
    Task<string?> Execute(ClassModel @class);
}

public class CreateClass(IClassRepository classRepository) : ICreateClass
{
    public async Task<string?> Execute(ClassModel @class)
    {
        try
        {
            await classRepository.AddAsync(@class);
        }
        catch (Exception ex)
        {
            return "O serviço está indisponível no momento, se o erro persistir entre em contato com suporte.";
        }

        return default;
    }
}