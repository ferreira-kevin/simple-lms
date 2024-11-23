using lms.Domain;

namespace lms.Data.Repositories;

public interface IQuestionRepository : IRepository<QuestionModel>
{
}

public class QuestionRepository : Repository<QuestionModel>, IQuestionRepository
{
    public QuestionRepository(LmsDbContext context) : base(context) { }
}