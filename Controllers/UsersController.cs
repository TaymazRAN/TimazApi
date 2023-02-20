using HomoroApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomoroApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/<UserController>/5
        [HttpGet]
        public ActionResult Get(string id)
        {
            var tt = AppRepository.GetUser(id);
            if (tt.Code == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt.Code == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }

        [HttpGet("GetAllUser")]
        public ActionResult GetAllUser()
        {
            var tt = AppRepository.GetAllUser();
            if (tt[0].Code == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt[0].Code == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }

        [HttpPost("UpdateUser")]
        public ActionResult UpdateUser(eUserModel uu)
        {
            var tt = AppRepository.UpdateUser(uu);
            if (tt == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }
             [HttpPost("InsertUser")]
        public ActionResult InserteUser(eUserModel uu)
        {
            var tt = AppRepository.IsertUser(uu);
            if (tt == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }
             [HttpPost("DeleteUser")]
        public ActionResult DeleteUser(string id)
        {
            var tt = AppRepository.DeleteUser(id);
            if (tt == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }




    }
}
 