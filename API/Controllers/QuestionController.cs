using InterviewMinuteAPI.Model;
using InterviewMinuteAPI.Repository;
using InterviewMinuteAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InterviewMinuteAPI.Controllers
{
    [ApiController]
    [Route("questions")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public IActionResult GetQuestions()
        {
            try
            {
                return Ok(_questionService.GetQuestions());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("random")]
        public IActionResult GetRandomQuestion()
        {
            try
            {
                var question = _questionService.GetRandomQuestion();
                if (question == null)
                {
                    return NotFound("No questions found");
                }
                return Ok(question);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
