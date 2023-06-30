using Azure.Core;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace front.Controllers
{
    public class TipoDeSalaController : Controller
    {
        private readonly ISalaDeEnsayosAPI _service;

        public TipoDeSalaController(ISalaDeEnsayosAPI service) => _service = service;


        [HttpGet]
        [Authorize(Roles = "Supervisor")]
        public IActionResult Index() => View();

        [HttpGet]
        [Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> GetList() => Json(await _service.TiposDeSalaGetListAsync());
        public async Task<IActionResult> GetTipoDeSala([DataSourceRequest] DataSourceRequest request) => Json(_service.TiposDeSalaGetListAsync().Result.ToDataSourceResult(request));
        
        [HttpPut]
        public async Task<IActionResult> UpdateTipoDeSala([DataSourceRequest] DataSourceRequest request, TiposDeSalaDTO entidad)
        {
            var res = await _service.TiposDeSalaUpdateById(entidad);
            if (res == 0) throw new Exception("No actualizado");
            return Json(new[] { entidad }.ToDataSourceResult(request));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTipoDeSala([DataSourceRequest] DataSourceRequest request, TiposDeSalaDTO entidad)
        {

            var res = await _service.TiposDeSalaPostAsync(entidad);
            return View(res);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTipoDeSala ([DataSourceRequest] DataSourceRequest request, TiposDeSalaDTO entidad)
        {
            var res = await _service.TiposDeSalaDeletById(entidad.Id);
            if (res == 0) throw new Exception("No eliminado");
            return Json(new[] { entidad }.ToDataSourceResult(request));
        }
}
}
