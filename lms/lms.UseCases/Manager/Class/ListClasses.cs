using lms.Data.Repositories;
using lms.Domain;

namespace lms.UseCases.Manager.Class;

public interface IListClasses
{
    Task<IEnumerable<ClassModel>> Execute();
}

public class ListClasses(IClassRepository _classRepository) : IListClasses
{
    public async Task<IEnumerable<ClassModel>> Execute()
    {
        return await _classRepository.GetAllAsync();
    }
}
