using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Extensions;

namespace front.Controllers
{
    public class EquipamientoController : Controller
    {
        private readonly ISalaDeEnsayosAPI _service;

        public EquipamientoController(ISalaDeEnsayosAPI service) => _service = service;

        public IActionResult CrearEquipamiento() => View();

        [HttpPost]
        [Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> GuardarEquipamiento(int lbx_salasdeensayo, int lbx_instrumento)
        {
            EquipamientoDTO entidad = new()
            {
                SalaDeEnsayoId = lbx_salasdeensayo,
                InstrumentoId = lbx_instrumento
            };
            if (entidad.InstrumentoId == 0 || entidad.SalaDeEnsayoId == 0)
            {
                ViewData["required"] = "Ambos campos son obligatorios.";
                return View("CrearEquipamiento");
            }
            var res = await _service.EquipamientoPostAsync(entidad);
            if (res == 404)
            {
                ViewData["Error"] = "Instrumento no disponible (ya en uso)";
                return View("CrearEquipamiento");
            }
            return View(res);
        }

        [HttpGet]
        [Authorize(Roles = "Supervisor")]
        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> GetEquipamientos([DataSourceRequest] DataSourceRequest request, int idsala)
        {
            return Json(
                 _service.EquipamientoGetListAsync(idsala).Result
                .ToDataSourceResult(request));
        }

        [HttpDelete]
        [Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> RemoveEquipamiento([DataSourceRequest] DataSourceRequest request, EquipamientoDTO entity)
        {
            var res = await _service.EquipamientoDeletById(entity);
            if (res == 0) throw new Exception("No eliminado");
            return Json(new[] { entity }.ToDataSourceResult(request));
        }


    }
}
