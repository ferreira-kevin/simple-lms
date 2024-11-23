namespace lms.Domain
{
    public class AssignmentModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int Points { get; set; }
        public string? Description { get; set; }
        public int? MaxAttemptsAllowed { get; set; }
        public int? TimeLimit { get; set; }
        public DateTime OpensAt { get; set; }
        public DateTime ClosesAt { get; set; }
        public List<QuestionModel>? Questions { get; set; }

        public List<AssignmentAttemptModel>? AssignmentAttempts { get; set; }
    }
}
