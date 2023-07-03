using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace front.Controllers
{
    public class ReservaController : Controller
    {

        private readonly IReserva _service;

        public ReservaController(IReserva reserva) => _service = reserva;

        public IActionResult CrearInstrumento() => View();

        [HttpPost]
        public async Task<IActionResult> ReservaInstrumento(ReservaDTO entidad)
        {

            //if (!validations(entidad))
            //{
            //    return View("Index");
            //}

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
        public async Task<IActionResult> RemoveReserva([DataSourceRequest] DataSourceRequest request, ReservaDTO entidad)
        {
            var res = await _service.ReservaDeleteById(entidad.Id);
            if (res == 0) throw new Exception("No eliminado");
            return Json(new[] { entidad }.ToDataSourceResult(request));
        }

        //private bool missingData(string marca, string descripcion)
        //{
        //    if (descripcion == null || marca == null) return false;
        //    else return true;
        //}

        //private bool validations(ReservaDTO entidad)
        //{
        //    if (!missingData(entidad.Descripcion, entidad.Marca))
        //    {
        //        ViewData["missingData"] = "Campo (*) obligatorio.";
        //        return false;
        //    }

        //    if (!ModelState.IsValid)
        //    { 
        //        var keys = ModelState.Values;
        //        int i = 0;
        //        foreach (var key in keys)
        //        {
        //            if (key.Errors.Count != 0)
        //            {
        //                ViewData["marca"] = key.Errors[i].ErrorMessage.Contains("Marca") ? key.Errors[i].ErrorMessage: null;
        //                ViewData["descripcion"] = key.Errors[i].ErrorMessage.Contains("Descripcion") ? key.Errors[i].ErrorMessage : null;
        //                i++;
        //            }
        //        }
        //        return false;
        //    }

        //    return true;
        //}
    }
}
