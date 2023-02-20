using HomoroApi.Models;
using HomoroApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomoroApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubMenuController : ControllerBase
    {
        // GET api/<SubMenuController>/5
        [HttpGet]
        public ActionResult Get(string id)
        {
            var tt = SubMenuRepository.GetSubMenu(id);
            if (tt.Code == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt.Code == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }

        [HttpGet("GetAllSubMenu")]
        public ActionResult GetAllSubMenu()
        {
            var tt = SubMenuRepository.GetAllSubMenu();
            if (tt[0].Code == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt[0].Code == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }

        [HttpPost("UpdateSubMenu")]
        public ActionResult UpdateSubMenu(eSubMenuModel uu)
        {
            var tt = SubMenuRepository.UpdateSubMenu(uu);
            if (tt == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }
             [HttpPost("InsertSubMenu")]
        public ActionResult InserteSubMenu(eSubMenuModel uu)
        {
            var tt = SubMenuRepository.IsertSubMenu(uu);
            if (tt == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }
             [HttpPost("DeleteSubMenu")]
        public ActionResult DeleteSubMenu(string id)
        {
            var tt = SubMenuRepository.DeleteSubMenu(id);
            if (tt == StatusCodes.Status200OK)
                return Ok(tt);
            else if (tt == StatusCodes.Status401Unauthorized)
                return Unauthorized();
            else
                return UnprocessableEntity();
        }




    }
}
 