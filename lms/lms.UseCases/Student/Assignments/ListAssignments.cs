using lms.Data.Repositories;
using lms.Domain;

namespace lms.UseCases.Student.Assignments;

public class ListAssignments(IAssignmentRepository _assignmentRepository) : IListAssignments
{
    public async Task<List<AssignmentModel>> Execute()
    {
        var assignments = await _assignmentRepository.GetAllAsync();
        return assignments.ToList();
    }
}

public interface IListAssignments
{
    public Task<List<AssignmentModel>> Execute();
}