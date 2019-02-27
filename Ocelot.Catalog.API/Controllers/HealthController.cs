using Microsoft.AspNetCore.Mvc;

namespace Ocelot.Catalog.API.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// Health check
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}