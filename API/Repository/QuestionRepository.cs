using InterviewMinuteAPI.Model;
using InterviewMinuteAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InterviewMinuteAPI.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly InterviewMinuteContext _context;

        public QuestionRepository(InterviewMinuteContext context)
        {
            _context = context;
        }

        public List<Question> GetQuestions()
        {
            return _context.Questions.Include(q => q.Answers).ToList();
        }
    }
}
