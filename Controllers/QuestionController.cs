using HomoroApi.Models;
using HomoroApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomoroApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        // GET api/<QuestionController>/5
        [HttpGet]
        public ActionResult Get(string id)
        {
            var tt = QuestionRepository.GetQuestion(id);
            if (tt.Code == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt.Code == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }

        [HttpGet("GetAllQuestion")]
        public ActionResult GetAllQuestion()
        {
            var tt = QuestionRepository.GetAllQuestion();
            if (tt[0].Code == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt[0].Code == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }

        [HttpPost("UpdateQuestion")]
        public ActionResult UpdateQuestion(eQuestionModel uu)
        {
            var tt = QuestionRepository.UpdateQuestion(uu);
            if (tt == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }
             [HttpPost("InsertQuestion")]
        public ActionResult InserteQuestion(eQuestionModel uu)
        {
            var tt = QuestionRepository.IsertQuestion(uu);
            if (tt == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }
             [HttpPost("DeleteQuestion")]
        public ActionResult DeleteQuestion(string id)
        {
            var tt = QuestionRepository.DeleteQuestion(id);
            if (tt == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }




    }
}
 