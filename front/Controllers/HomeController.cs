using Microsoft.AspNetCore.Mvc;
namespace front.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISalaDeEnsayosAPI _service;

        public HomeController(ISalaDeEnsayosAPI service) =>
            _service = service;

        public IActionResult Index() => View();



        public IActionResult Error()
        {
            return View();
        }
    }
}
