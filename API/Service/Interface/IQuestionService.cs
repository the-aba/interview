using InterviewMinuteAPI.DTO;

namespace InterviewMinuteAPI.Service.Interface
{
    public interface IQuestionService
    {
        List<QuestionDTO> GetQuestions();
        QuestionDTO? GetRandomQuestion();
    }
}
