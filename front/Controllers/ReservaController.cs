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

		[HttpPost]
		public async Task<IActionResult> GuardarReserva([DataSourceRequest] DataSourceRequest request, DateTime fechadesde, DateTime fechahasta, int SalaDeEnsayoId)
		{
			ReservaDTO reserva = new();
			Console.WriteLine(fechadesde.Hour); 
			if (ModelState.IsValid)
			{
				ModelStateDictionary modelState = ValidationsFechas(fechadesde, fechahasta);
				if (!modelState.IsValid)
				{
					var errors = ModelState.Values.SelectMany(v => v.Errors)
							.Select(e => e.ErrorMessage).ToList();
					return View("Index");
				}

				reserva.FechaDesde = fechadesde;
				reserva.FechaHasta = fechahasta;
				reserva.SalaDeEnsayoId = SalaDeEnsayoId;
                var res = await _service.ReservaPostAsync(reserva);
				//return Json(new[] { reserva }.ToDataSourceResult(request, ModelState));
                return View("Index");
                //return View(res);
            }
			else {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).ToList();
                return View("Index");
            }

        }

        //public DateTime ConvertFechas(TimeOnly fecha, TimeOnly hora)
        //{
        //    string[] hoursString = hora.Split(':');
        //    DateTime resultado = DateTime.Parse(fecha);
        //    resultado = resultado.AddHours(Int32.Parse(hoursString[0]));
        //    resultado = resultado.AddMinutes(Int32.Parse(hoursString[1]));
        //    return resultado;
        //}

        public ModelStateDictionary ValidationsFechas(DateTime desde, DateTime hasta)
		{
			if (desde < DateTime.Now.AddDays(1))
			{
                ModelState.AddModelError("FechaDesde", "La fecha 'desde' debe ser mayor a la fecha de 'hoy + 1 dí­a'");
			}

			if (hasta > new DateTime(2026, 01, 01))
			{
                ModelState.AddModelError("FechaHasta", "La fecha 'hasta' no debe ser mayor a la fecha de '01/01/2026' {hasta}");
			}

			if (hasta < desde.AddHours(2))
			{
                ModelState.AddModelError("HoraHasta", "Debe existir una diferencia horaria de por lo menos 2 horas con la hora desde");
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
