namespace lms.Domain
{
    public class StudentModel
    {
        public Guid Id { get; set; }
        public UserModel User { get; set; } // Informações pessoais do estudante
        public DateTime EnrollmentDate { get; set; } // Data de inscrição
    }
}
