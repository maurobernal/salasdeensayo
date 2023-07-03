using Microsoft.AspNetCore.Mvc;
using SalasDeEnsayo.DTOs;

namespace front.Controllers
{
    public class InstrumentoController : Controller
    {

        private readonly IInstrumento _service;

        public InstrumentoController(IInstrumento instrumento) => _service = instrumento;

        public IActionResult CrearInstrumento() => View();

        [HttpPost]
        public async Task<IActionResult> GuardarInstrumento(string tbx_marca, string lbx_descripcion)
        {
            InstrumentoDTO entidad = new()
            {
                Marca = tbx_marca,
                Descripcion = lbx_descripcion
            };

            validations(entidad);

            var res = await _service.InstrumentoPostAsync(entidad);
            return View(res);
        }

        private bool missingData(string marca, string descripcion)
        {
            if (descripcion == null || marca == null) return false;
            else return true;
        }

        private bool validations(InstrumentoDTO entidad)
        {
            if (!missingData(entidad.Descripcion, entidad.Marca))
            {
                ViewData["missingData"] = "Campo (*) obligatorio.";
                return false;
            }

            if (!ModelState.IsValid)
            {   //TO DO
                //ModelState.Keys
                var errores = ModelState.Keys;
                foreach (var key in errores)
                {
                    Console.WriteLine(key); 
                }
                return false;
            }

            return true;
        }
    }
}
