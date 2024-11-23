using lms.Data.Repositories;

namespace lms.UseCases.Student.Assignment;

public class SelectOption(IQuestionAnswerRepository _questionAnswerRepository) : ISelectOption
{
    public void Execute(Guid assignmnetAttemptId, Guid questionId, Guid optionId)
    {
        _questionAnswerRepository.SetQuestionAsync(assignmnetAttemptId, questionId, optionId);
    }
}

public interface ISelectOption
{
    public void Execute(Guid assignmnetAttemptId, Guid questionId, Guid optionId);
}