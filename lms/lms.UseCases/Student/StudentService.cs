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

    // M�todo para buscar alunos pelo nome
    public async Task<List<StudentModel>> SearchStudentsByName(string name)
    {
        // Busca alunos no reposit�rio usando o nome como filtro
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

    // M�todo para adicionar um aluno a um curso espec�fico
    public async Task AddStudentToCourse(Guid courseId, Guid studentId)
    {
        // Obt�m o curso e verifica se ele existe
        var course = await _courseRepository.GetByIdAsync(courseId);
        if (course == null)
        {
            throw new Exception("Course not found");
        }

        // Verifica se o aluno j� est� inscrito
        var student = await _studentRepository.GetByIdAsync(studentId);
        if (student == null)
        {
            throw new Exception("Student not found");
        }

        // Adiciona o aluno ao curso se ele ainda n�o estiver inscrito
        //if (!course.EnrolledStudents.Any(s => s.Id == studentId))
        //{
        //    course.EnrolledStudents.Add(student);
        //    await _courseRepository.UpdateAsync(course);
        //}
    }

    // M�todo para obter todos os alunos inscritos em um curso
    public async Task<List<StudentModel>> GetEnrolledStudents(Guid courseId)
    {
        // Obt�m o curso e retorna a lista de alunos inscritos
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
    // M�todo para buscar alunos pelo nome
    Task<List<StudentModel>> SearchStudentsByName(string name);

    // M�todo para adicionar um aluno a um curso espec�fico
    Task AddStudentToCourse(Guid courseId, Guid studentId);

    // M�todo para obter todos os alunos inscritos em um curso
    Task<List<StudentModel>> GetEnrolledStudents(Guid courseId);
}
