using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace front.Controllers
{
    public class SalasController : Controller
    {
        private readonly ISalaDeEnsayosAPI _service;

        public SalasController(ISalaDeEnsayosAPI service) => _service = service;


        [HttpPost]
        public async Task<IActionResult> GuardarSala(int lbx_tiposdesala, string tbx_descripcion)
        {
            SalasDeEnsayoDTO entidad = new()
            {
                Descripcion = tbx_descripcion,
                TipoDeSalaId = lbx_tiposdesala
            };
            var res = await _service.SalaDeEnsayoPostAsync(entidad);
            return View(res);
        }




        [HttpGet]
        [Authorize]
        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> GetSalas([DataSourceRequest] DataSourceRequest request, int tipodesalaid)
        {
            return Json(
                 _service.SalaDeEnsayoGetListAsync(tipodesalaid).Result
                .ToDataSourceResult(request));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSalas([DataSourceRequest] DataSourceRequest request, SalasDeEnsayoDTO entidad)
        {
            var res = await _service.SalaDeEnsayoDeletByIdAsync(entidad.Id);
            if (res == 0) throw new Exception("No eliminado");
            return Json(new[] { entidad }.ToDataSourceResult(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSalas([DataSourceRequest] DataSourceRequest request, SalasDeEnsayoDTO entidad)
        {
            var res = await _service.SalaDeEnsayoUpdateByIdAsync(entidad);
            if (res == 0) throw new Exception("No actualizado");
            return Json(new[] { entidad }.ToDataSourceResult(request));
        }

    }
}
