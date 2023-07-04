using Azure.Core;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace front.Controllers
{
    public class ListaDePreciosController : Controller
    {
        private readonly ISalaDeEnsayosAPI _service;

        public ListaDePreciosController(ISalaDeEnsayosAPI service) => _service = service;


        public IActionResult CrearSala() => View();
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> CrearLista(int idSala, int dia, double precioxhora)
        {
            ListaDePrecioDTO entidad = new()
            {
                dia = dia,
                precioxhora = precioxhora
            };
            var res = await _service.ListaDePrecioPostAsync(entidad, idSala);
            return View("Crear");
        }


        [HttpGet]
        public IActionResult Index()=> View();

        [HttpGet]
        public async Task<IActionResult> GetListaDePrecios([DataSourceRequest] DataSourceRequest request, int idSala)
        {
             return Json(
                  _service.ListaDePrecioGetListAsync(idSala).Result
                  .ToDataSourceResult(request));
        }
    }


}
