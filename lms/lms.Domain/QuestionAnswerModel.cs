namespace lms.Domain;

public record QuestionAnswerModel(
    Guid Id,
    Guid AssignmentAttemptId,
    Guid QuestionId,
    Guid OptionIdSelected,
    bool Active,
    DateTime CreatedAt,
    DateTime UpdatedAt)
{
    public QuestionAnswerModel Inactivate()
    {
        return this with { Active = false, UpdatedAt = DateTime.UtcNow };
    }
}
