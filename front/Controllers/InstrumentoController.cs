﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalasDeEnsayo.DTOs;

namespace front.Controllers
{
    public class InstrumentoController : Controller
    {

        private readonly IInstrumento _service;

        public InstrumentoController(IInstrumento instrumento) => _service = instrumento;

        [HttpPost]
        public async Task<IActionResult> GuardarInstrumento(string lbx_marca, string lbx_descripcion)
        {
            InstrumentoDTO entidad = new()
            {
                Marca = lbx_marca,
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
                return false;
            }

            return true;
        }
    }
}
