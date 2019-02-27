using Microsoft.AspNetCore.Mvc;

namespace Ocelot.Identity.API.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Route("/")]
        public RedirectResult Get()
        {
           return Redirect($"{this.Request.Scheme}://{this.Request.Host.Value}/.well-known/openid-configuration");
        }
    }
}
