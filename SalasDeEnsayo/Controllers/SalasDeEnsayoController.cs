using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalasDeEnsayo.Entidades;
using SalasDeEnsayo.Infraestructura;

namespace SalasDeEnsayo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasDeEnsayoController : ControllerBase
    {
        [HttpGet]
        public List<tipodesala> RecuperarSalaDeEnsayo()
        {

            AppDbContext context = new AppDbContext();
            return context.tipodesala.ToList();
        }

        [HttpPost]
        public void CrearSalaDeEnsayo()
        {
            AppDbContext context = new AppDbContext();
            var tipodesala1 = new tipodesala();
            tipodesala1.habilitado = true;
            tipodesala1.descripcion = "Sala 1";

            var tipodesala2 = new tipodesala();
            tipodesala2.habilitado = true;
            tipodesala2.descripcion = "Sala 2";




            //var entity = new saladeensayo();
            //entity.descripcion = "Mi primer sala";
            //entity.habilitado = true;

            //var entity2 = new saladeensayo();
            //entity.descripcion = "Mi segunda sala";
            //entity.habilitado = true;

            //context.saladeensayo.Add(entity);
            //context.saladeensayo.Add(entity2);

            context.tipodesala.Add(tipodesala1);
            context.tipodesala.Add(tipodesala2);
            context.SaveChanges();

        }

        [HttpPut]
        public void ActualizarSalaDeEnsayo() => Console.WriteLine();


        [HttpDelete]
        public void EliminarSalaDeEnsayo() => Console.WriteLine();
    }
}
