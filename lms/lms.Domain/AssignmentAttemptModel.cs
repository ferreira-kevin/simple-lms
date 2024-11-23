namespace lms.Domain;

public class AssignmentAttemptModel
{
    public Guid Id { get; set; }
    public Guid AssignmentId { get; set; }
    public Guid StudentId { get; set; }
    public int Attempt { get; set; }
    public bool Open { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual AssignmentModel Assignment { get; set; }
    public virtual List<QuestionAnswerModel> QuestionAnswers { get; set; } = new List<QuestionAnswerModel>();

    public AssignmentAttemptModel() { }

    public AssignmentAttemptModel(Guid assignmentId, Guid studentId, int attempt, bool open)
    {
        AssignmentId = assignmentId;
        StudentId = studentId;
        Attempt = attempt;
        Open = open;
        CreatedAt = DateTime.UtcNow;
    }
}
