using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        [HttpGet]
        public async Task<IActionResult> GetEquipamiento([DataSourceRequest] DataSourceRequest request, int equipamientoId, int saladeensayoId)
        {
            
        }



    }
}
