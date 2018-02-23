using Microsoft.AspNetCore.Mvc;

namespace ServerLocation.Controllers
{
    [Produces("application/json")]
    [Route("Search/result")]
    public class ResultController : Controller
    {
        // Using default route controller
        [HttpGet]
        public ActionResult Get()
        {
            return LocalRedirect("/City/result");
        }
    }
}