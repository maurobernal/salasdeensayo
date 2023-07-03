using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace front.Controllers
{
    public class ReservaController : Controller
    {

        private readonly IReserva _service;

        public ReservaController(IReserva reserva) => _service = reserva;

        public IActionResult CrearReserva() => View();

        [HttpPost]
        public async Task<IActionResult> GuardarReserva(ReservaDTO entidad)
        {

            var res = await _service.ReservaPostAsync(entidad);
            return View(res);
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> GetReservas([DataSourceRequest] DataSourceRequest request)
        {
            return Json(
                 _service.ReservaGetListAsync().Result
                 .ToDataSourceResult(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReservas([DataSourceRequest] DataSourceRequest request, ReservaDTO entidad)
        {
            var res = await _service.ReservaUpdateById(entidad);
            if (res == 0) throw new Exception("No actualizado");
            return Json(new[] { entidad }.ToDataSourceResult(request));
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveReserva([DataSourceRequest] DataSourceRequest request, InstrumentoDTO entidad)
        {
            var res = await _service.ReservaDeleteById(entidad.Id);
            if (res == 0) throw new Exception("No eliminado");
            return Json(new[] { entidad }.ToDataSourceResult(request));
        }

    }
}
