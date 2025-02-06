using InterviewMinuteAPI.Model;

namespace InterviewMinuteAPI.Repository.Interface
{
    public interface IQuestionRepository
    {
        List<Question> GetQuestions();
    }
}
