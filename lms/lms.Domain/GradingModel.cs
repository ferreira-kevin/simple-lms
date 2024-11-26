namespace lms.Domain;

public record GradingModel(Guid Id, Guid AssignmentId, Guid StudentId, decimal Value, DateTime CreatedAt)
{
    public AssignmentAttemptModel? AssignmentAttempt { get; set; }
};