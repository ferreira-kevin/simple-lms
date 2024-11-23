using lms.Data.Repositories;
using lms.Domain;

namespace lms.UseCases.Student.Assignment
{
    public class StartAssignment(IAssignmentRepository _assignmentRepository) : IStartAssignment
    {
        public async Task<AssignmentModel?> Execute(Guid assignmentId)
        {
            return await _assignmentRepository.GetAssignmentWithQuestionsAsync(assignmentId);
        }
    }

    public interface IStartAssignment
    {
        Task<AssignmentModel?> Execute(Guid assignmentId);
    };
}
