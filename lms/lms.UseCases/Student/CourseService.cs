using lms.Data.Repositories;
using lms.Domain;

namespace lms.UseCases.Student;

public class CourseService(ICourseRepository _courseRepository) : ICourseService
{
    public async Task<CourseModel> GetCourseByIdAsync(Guid id)
    {
        return await _courseRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<CourseModel>> GetAllCoursesAsync()
    {
        return await _courseRepository.GetAllAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _courseRepository.DeleteAsync(id);
    }

    public async Task SaveCourseAsync(CourseModel course)
    {
        await _courseRepository.UpdateAsync(course);
    }

    //public async Task<IEnumerable<CourseModel>> GetCoursesByUserAsync()
    //{

    //}
}

public interface ICourseService
{
    Task<IEnumerable<CourseModel>> GetAllCoursesAsync();
    Task DeleteAsync(Guid id);
    Task SaveCourseAsync(CourseModel course);
    Task<CourseModel> GetCourseByIdAsync(Guid id);
}
