using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace front.Controllers
{
    public class TipoDeSalaController : Controller
    {
        private ISalaDeEnsayosAPI _service;

        public TipoDeSalaController(ISalaDeEnsayosAPI service) => _service = service;

        [HttpGet]
        public IActionResult GetList() => Json(_service.TiposDeSalaGetList());
    }
}
