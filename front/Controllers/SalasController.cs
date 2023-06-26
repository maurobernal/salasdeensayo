using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace front.Controllers
{
    public class SalasController : Controller
    {
        private readonly ISalaDeEnsayosAPI _service;

        public SalasController(ISalaDeEnsayosAPI service) => _service = service;


        [HttpPost]
        public IActionResult GuardarSala(int lbx_tiposdesala, string tbx_descripcion)
        {
            SalasDeEnsayoDTO entidad = new()
            {
                Descripcion = tbx_descripcion,
                TipoDeSalaId = lbx_tiposdesala
            };
            var res = _service.SalaDeEnsayoPost(entidad);
            return View(res);
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> GetSalas([DataSourceRequest] DataSourceRequest request, int tipodesalaid)
        {
            return Json(
                 _service.SalaDeEnsayoGetListAsync(tipodesalaid).Result
                .ToDataSourceResult(request));
        }

    }
}
