namespace lms.Domain;

public record OptionModel(Guid Id, Guid QuestionId, string Text, bool Correct)
{
    public QuestionModel? Question { get; set; }
};
