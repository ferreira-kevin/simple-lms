namespace lms.Domain;

public class StudentCourseModel
{
    public Guid Id { get; set; }

    // Id do estudante associado ao curso
    public Guid StudentId { get; set; }

    // Id do curso ao qual o estudante est� inscrito
    public Guid CourseId { get; set; }

    // Data de inscri��o do estudante no curso
    public DateTime EnrollmentDate { get; set; }

    // Status da inscri��o do estudante (ativo, conclu�do, etc.)
    public string Status { get; set; }

    // Nota final do estudante no curso
    public double? FinalGrade { get; set; }

    // Pontua��o acumulada durante o curso
    public double? CurrentScore { get; set; }

    // Indica se o aluno completou o curso
    public bool IsCompleted { get; set; }
}

