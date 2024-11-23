namespace lms.Domain
{
    public class QuestionModel
    {
        public Guid Id { get; set; }
        public Guid AssignmentId { get; set; }
        public required string Statment { get; set; }
        public required List<OptionModel> Options { get; set; }
    }
}
