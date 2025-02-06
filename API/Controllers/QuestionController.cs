using Azure;
using InterviewMinuteAPI.Model;
using InterviewMinuteAPI.Repository;
using InterviewMinuteAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

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

        [HttpGet("add-response")]
        public IActionResult AddResponse([FromQuery] int questionId, [FromQuery] int answerId)
        {
            var connection = new SqlConnection((new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build()).GetConnectionString("InterviewMinute"));
            connection.Open();
            var cmd = new SqlCommand("dbo.InsertResponse", connection); //SqlCommand("INSERT INTO dbo.Response (Question,Answer,WhenDidTheResponseHappenAt) VALUES (1,1,'2021-09-01 00:00:00.000')");
            cmd.Parameters.AddWithValue("@Question", questionId);
            cmd.Parameters.AddWithValue("@Answer", answerId);
            cmd.Parameters.AddWithValue("@ResponseTime", DateTime.Now);
            cmd.CommandType = (CommandType)4;
            var reader = cmd.ExecuteReader();
            return Ok();
        }

        [HttpGet("get-responses-route")]
        public IActionResult GetResponses()
        {
            List<object> responses = new List<object>();

            try
            {
                IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();
                var c = configuration.GetConnectionString("InterviewMinute");
                var c2 = new SqlConnection(c);
                c2.Open();
                var cmd = new SqlCommand("dbo.GetResponses", c2);
                cmd.CommandType = (CommandType)4;
                var reader = cmd.ExecuteReader();
                responses = new List<object>();
                while (true)
                {
                    if (!reader.Read())
                    {
                        break;
                    }
                    responses.Add(new
                    {
                        Question = reader["qtext"],
                        Answer = reader["Answer"],
                        ResponseTime = reader["WhenDidTheResponseHappenAt"]
                    });
                }
            }
            catch (Exception e)
            {
            }
            return Ok(responses);
        }
    }
}
