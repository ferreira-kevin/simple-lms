using lms.Domain.Enums;

namespace lms.Domain;

public class QuestionModel
{
    public Guid Id { get; set; }
    public Guid AssignmentId { get; set; }
    public required string Statment { get; set; }
    public QuestionType Type { get; set; }
    public List<OptionModel> Options { get; set; } = [];
    public List<QuestionAnswerModel> QuestionAnswers { get; set; } = [];
}
