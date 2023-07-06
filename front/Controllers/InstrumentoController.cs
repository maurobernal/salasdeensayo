using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace front.Controllers
{
    public class InstrumentoController : Controller
    {

        private readonly IInstrumento _service;

        public InstrumentoController(IInstrumento instrumento) => _service = instrumento;

        public IActionResult CrearInstrumento() => View();

        public IActionResult Index() => View();


        public async Task<IActionResult> GuardarInstrumento([DataSourceRequest] DataSourceRequest request,InstrumentoDTO entidad)
        {
            if (ModelState.IsValid)
            {
                var res = await _service.InstrumentoPostAsync(entidad);
                return Json(new[] { entidad }.ToDataSourceResult(request, ModelState));
            }
            else
            {
                // Return model validation errors to the Kendo grid
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();

                return Json(new DataSourceResult { Errors = errors });
            }
        }

        
        public async Task<IActionResult> GetInstrumentos([DataSourceRequest] DataSourceRequest request)
        {
            return Json(
                 _service.InstrumentoGetListAsync().Result
                 .ToDataSourceResult(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetList() => Json(await _service.InstrumentoGetListAsync());

        public async Task<IActionResult> UpdateInstrumentos([DataSourceRequest] DataSourceRequest request, InstrumentoDTO entidad)
        {
            if (ModelState.IsValid)
            {
                var res = await _service.InstrumentoUpdateById(entidad);
                if (res == 0) throw new Exception("No actualizado");
                return Json(new[] { entidad }.ToDataSourceResult(request, ModelState));
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();

                return Json(new DataSourceResult { Errors = errors });
            }
        }

        public async Task<IActionResult> RemoveInstrumento([DataSourceRequest] DataSourceRequest request, InstrumentoDTO entidad)
        {
            var res = await _service.InstrumentoDeleteById(entidad.Id);
            if (res == 0) throw new Exception("No eliminado");
            return Json(new[] { entidad }.ToDataSourceResult(request));
        }

        //private bool missingData(string marca, string descripcion)
        //{
        //    if (descripcion == null || marca == null) return false;
        //    else return true;
        //}

        //private bool validations(InstrumentoDTO entidad)
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
