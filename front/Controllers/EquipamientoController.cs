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
        public async Task<IActionResult> GuardarEquipamiento(int lbx_salasdeensayo, int lbx_tipodesala)
        {
            EquipamientoDTO entidad = new()
            {
                SalaDeEnsayoId = lbx_salasdeensayo,
                //cambiar despues con instrumentos
                TipoDeSalaId = lbx_tipodesala
            };
            var res = await _service.EquipamientoPostAsync(entidad);
            return View(res);
        }

        [HttpGet]
        [Authorize(Roles = "Supervisor")]
        public IActionResult Index() => View();
        public async Task<IActionResult> GetList() {
            
            return Json(await _service.EquipamientoGetListAsync());
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteEquipamiento([DataSourceRequest] DataSourceRequest request, EquipamientoDTO entity)
        {
            var res = await _service.EquipamientoDeletById(entity.Id, entity.SalaDeEnsayoId);
            if (res == 0) throw new Exception("No eliminado");
            return Json(new[] { entity }.ToDataSourceResult(request));
        }


    }
}
