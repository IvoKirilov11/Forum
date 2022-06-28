using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post()
        {
            return this.Ok();
        }
    }
}
