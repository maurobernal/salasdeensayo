using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;
using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace front.Controllers
{
    public class ReservaController : Controller
    {

        private readonly IReserva _service;

        public ReservaController(IReserva reserva) => _service = reserva;

        public IActionResult CrearReserva() => View();
        public IActionResult Index() => View();
        public IActionResult GrillaReservas() => View();

        [HttpPost]
        public async Task<IActionResult> GuardarReserva([DataSourceRequest] DataSourceRequest request, DateTime fechainicio, DateTime fechafin, int SalaDeEnsayoId)
        {
            ReservaDTO reserva = new();
            Console.WriteLine(fechainicio.Hour);
            if (ModelState.IsValid)
            {
                ModelStateDictionary modelState = ValidationsFechas(fechainicio, fechafin);
                if (!modelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage).ToList();
                    return View("Index");
                }

                reserva.FechaInicio = fechainicio;
                reserva.FechaFin = fechafin;
                reserva.SalaDeEnsayoId = SalaDeEnsayoId;
                var res = await _service.ReservaPostAsync(reserva);
                //return Json(new[] { reserva }.ToDataSourceResult(request, ModelState));
                ViewData["exito"] = "Success";
                return View("Index");
                //return View(res);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).ToList();
                return View("Index");
            }

        }

        public ModelStateDictionary ValidationsFechas(DateTime desde, DateTime hasta)
        {
            if (desde < DateTime.Now.AddDays(1))
            {
                ModelState.AddModelError("fechainicio", "La fecha 'desde' debe ser mayor a la fecha de 'hoy + 1 dí­a'");
            }

            if (hasta > new DateTime(2026, 01, 01))
            {
                ModelState.AddModelError("fechafin", "La fecha 'hasta' no debe ser mayor a la fecha de '01/01/2026' {hasta}");
            }

            if (hasta < desde.AddHours(2))
            {
                ModelState.AddModelError("fechafin", "Debe existir una diferencia horaria de por lo menos 2 horas con la hora desde");
            }

            return ModelState;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservas([DataSourceRequest] DataSourceRequest request)
        {
            return Json(
                 _service.ReservaGetListAsync().Result
                 .ToDataSourceResult(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReserva([DataSourceRequest] DataSourceRequest request, DateTime fechainicio, DateTime fechafin)
        {
			if (fechainicio.Hour == 0)
			{
				Console.WriteLine(fechainicio.Hour);
			}
			if (ModelState.IsValid)
            {
                
				ReservaDTO reserva = new();
                ModelStateDictionary modelState = ValidationsFechas(fechainicio, fechafin);

                if (!modelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage).ToList();
                    return View("Index");
                }
                reserva.FechaInicio = fechainicio;
                reserva.FechaFin = fechafin;
                var res = await _service.ReservaUpdateById(reserva);
                if (res == 0) throw new Exception("No actualizado");
                return Json(new[] { reserva }.ToDataSourceResult(request, ModelState));
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                       .Select(e => e.ErrorMessage).ToList();
                return Json(new DataSourceResult { Errors = errors });
            }

        }


        [HttpDelete]
        public async Task<IActionResult> RemoveReserva([DataSourceRequest] DataSourceRequest request, ReservaDTO entidad)
        {
            var res = await _service.ReservaDeleteById(entidad.Id);
            if (res == 0) throw new Exception("No eliminado");
            return Json(new[] { entidad }.ToDataSourceResult(request));
        }

    }
}
