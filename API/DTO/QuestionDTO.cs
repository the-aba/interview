namespace InterviewMinuteAPI.DTO
{
    public class QuestionDTO
    {
        public long QuestionId { get; set; }

        public string? Text { get; set; }

        public List<AnswerDTO> Answers { get; set; } = new List<AnswerDTO>();
    }
}
