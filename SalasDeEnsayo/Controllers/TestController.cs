using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SalasDeEnsayo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("200")]
        public IActionResult t200() => Ok();

        [HttpGet("500")]
        public IActionResult t500() => throw new Exception("Exception de test");


        [HttpGet("401")]
        public IActionResult t401() => Unauthorized();


        [HttpGet("404")]
        public IActionResult t404() => NotFound();

        [HttpGet("405")]
        public IActionResult t405() => BadRequest();


    }
}
