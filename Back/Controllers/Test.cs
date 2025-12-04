using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{

    //Kevin Jahdiel De la Cruz Vargas
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hola Mundo");
        }
    }
}
