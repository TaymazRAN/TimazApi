using HomoroApi.Models;
using HomoroApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomoroApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        // GET api/<MemberController>/5
        [HttpGet]
        public ActionResult Get(string id)
        {
            var tt = MemberRepository.GetMember(id);
            if (tt.Code == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt.Code == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }

        [HttpGet("GetAllMember")]
        public ActionResult GetAllMember()
        {
            var tt = MemberRepository.GetAllMember();
            if (tt[0].Code == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt[0].Code == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }

        [HttpPost("UpdateMember")]
        public ActionResult UpdateMember(eMemberModel uu)
        {
            var tt = MemberRepository.UpdateMember(uu);
            if (tt == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }
             [HttpPost("InsertMember")]
        public ActionResult InserteMember(eMemberModel uu)
        {
            var tt = MemberRepository.IsertMember(uu);
            if (tt == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }
             [HttpPost("DeleteMember")]
        public ActionResult DeleteMember(string id)
        {
            var tt = MemberRepository.DeleteMember(id);
            if (tt == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }




    }
}
 