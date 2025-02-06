using InterviewMinuteAPI.DTO;
using InterviewMinuteAPI.Repository.Interface;
using InterviewMinuteAPI.Service.Interface;

namespace InterviewMinuteAPI.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public List<QuestionDTO> GetQuestions()
        {
            var questions = _questionRepository.GetQuestions();
            return questions.Select(q => new QuestionDTO
            {
                QuestionId = q.QuestionId,
                Text = q.Text,
                Answers = q.Answers.Select(a => new AnswerDTO
                {
                    AnswerId = a.AnswerId,
                    Text = a.Text,
                    DisplayOrder = a.DisplayOrder
                }).ToList()
            }).ToList();
        }

        public QuestionDTO? GetRandomQuestion()
        {
            var questions = _questionRepository.GetQuestions();
            if(questions.Count == 0)
            {
                return null;
            }
            var random = new Random();
            var index = random.Next(questions.Count);
            var question = questions[index];
            return new QuestionDTO
            {
                QuestionId = question.QuestionId,
                Text = question.Text,
                Answers = question.Answers.Select(a => new AnswerDTO
                {
                    AnswerId = a.AnswerId,
                    Text = a.Text,
                    DisplayOrder = a.DisplayOrder
                }).ToList()
            };
        }
    }
}
