using lms.Data.Repositories;
using lms.Domain;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;

    public StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
    }

    // Método para buscar alunos pelo nome
    public async Task<List<StudentModel>> SearchStudentsByName(string name)
    {
        // Busca alunos no repositório usando o nome como filtro
        //return await _studentRepository.GetStudentsByNameAsync(name);
        return [
            new() {
                //FullName = "Aluno 1",
                Id = Guid.NewGuid(),
                User = new(){
                    FullName = "Aluno 1"
                }
            },
             new() {
                //FullName = "Aluno 2",
                Id = Guid.NewGuid(),
                User = new(){
                    FullName = "Aluno 2"
                }
            },
             new() {
                //FullName = "Aluno 3",
                Id = Guid.NewGuid(),
                User = new(){
                    FullName = "Aluno 3"
                }
            }
            ];
    }

    // Método para adicionar um aluno a um curso específico
    public async Task AddStudentToCourse(Guid courseId, Guid studentId)
    {
        // Obtém o curso e verifica se ele existe
        var course = await _courseRepository.GetByIdAsync(courseId);
        if (course == null)
        {
            throw new Exception("Course not found");
        }

        // Verifica se o aluno já está inscrito
        var student = await _studentRepository.GetByIdAsync(studentId);
        if (student == null)
        {
            throw new Exception("Student not found");
        }

        // Adiciona o aluno ao curso se ele ainda não estiver inscrito
        //if (!course.EnrolledStudents.Any(s => s.Id == studentId))
        //{
        //    course.EnrolledStudents.Add(student);
        //    await _courseRepository.UpdateAsync(course);
        //}
    }

    // Método para obter todos os alunos inscritos em um curso
    public async Task<List<StudentModel>> GetEnrolledStudents(Guid courseId)
    {
        // Obtém o curso e retorna a lista de alunos inscritos
        var course = await _courseRepository.GetByIdAsync(courseId);
        //return course?.EnrolledStudents.ToList() ?? new List<StudentModel>();
        return [
             new() {
                //FullName = "Aluno 1",
                Id = Guid.NewGuid()
            }
            ];
    }
}

public interface IStudentService
{
    // Método para buscar alunos pelo nome
    Task<List<StudentModel>> SearchStudentsByName(string name);

    // Método para adicionar um aluno a um curso específico
    Task AddStudentToCourse(Guid courseId, Guid studentId);

    // Método para obter todos os alunos inscritos em um curso
    Task<List<StudentModel>> GetEnrolledStudents(Guid courseId);
}
