using lms.Data.Repositories;

namespace lms.UseCases.Student.Grades
{
    public class ListGrades(IGradeRepository _gradeRepository, IAssignmentRepository _assignmentRepository) : IListGrades
    {
        public async Task<List<StudentAssignmentGradeViewModel>> Execute()
        {
            var grades = await _gradeRepository.GetAllAsync();
            var assignments = await _assignmentRepository.GetAllAsync();
            var assignmentGrades = (from grade in grades
                join assignment in assignments on grade.AssignmentId equals assignment.Id
                select new StudentAssignmentGradeViewModel
                {
                    AssignmentId = assignment.Id,
                    AssignmentName = assignment.Name,
                    GradeValue = grade.Value,
                    GradedAt = grade.CreatedAt
                }).ToList();
            return assignmentGrades.ToList();
        }
    }

    public interface IListGrades
    {
        public Task<List<StudentAssignmentGradeViewModel>> Execute();
    }

    public class StudentAssignmentGradeViewModel
    {
        public Guid AssignmentId { get; set; }
        public string AssignmentName { get; set; } = string.Empty;
        public decimal GradeValue { get; set; }
        public DateTime GradedAt { get; set; }
    }
}
