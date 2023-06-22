using Microsoft.AspNetCore.Http.HttpResults;
using SalasDeEnsayo.DTOs;

namespace SalasDeEnsayo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public ReservaController(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("")]
        public IActionResult GetList()
        {
            var entidad = _context.reserva

                .Include(i => i.salaDeEnsayo)
                .Include(i => i.salaDeEnsayo.tipo)
                .OrderBy(o => o.id)
                .Select(s => s).ToList();
            var res = _mapper.Map<List<reservasGetDTO>>(entidad);
            return Ok(res);

        }

        [HttpGet("id")]
        public IActionResult GetId(int id)
        {
            var entidad = _context.reserva
                .Where(w => w.id == id)
                .Select(s => s).FirstOrDefault();
            var dto = _mapper.Map<reservasGetDTO>(entidad);
            return Ok(dto);
        }
        [HttpPost]
        public IActionResult Post([FromBody] reservasCreateDTO dto)
        {
            reserva entidad = new();
            var cant = _context.saladeensayo.Where(w => w.id == dto.salaDeEnsayoId).Count();
            if (cant == 0) return NotFound($"El tipo de sala no fue encontrado" + dto.salaDeEnsayoId);

            if (dto.fechaDesde < DateTime.Now.AddDays(1)) return NotFound($"La fecha 'desde' debe ser mayor a la fecha de 'hoy + 1 dÃ­a' {dto.fechaDesde}");
            if (dto.fechaHasta > new DateTime(2026, 01, 01)) return NotFound($"La fecha 'hasta' no debe ser mayor a la fecha de '01/01/2026' {dto.fechaDesde}");
            if (dto.fechaHasta < dto.fechaDesde.AddHours(2)) return BadRequest("La fecha hasta debe tener una diferencia horaria de por lo menos 2 horas con la fecha desde");

            //Mapers
            entidad = _mapper.Map<reserva>(dto);

            //Campos predeterminados
            entidad.confirmado = false;
            _context.reserva.Add(entidad);
            _context.SaveChanges();
            return Ok(entidad.id);
        }
        [HttpPut("id")]
        public IActionResult Put([FromBody] reservasUpdateDTO dto, int id)
        {
            if (id != dto.id) return BadRequest();

            var entidad = _context.reserva
                .Where(w => w.id == id)
                .FirstOrDefault();
            if (entidad == null) return NotFound(dto);
            _mapper.Map<reservasUpdateDTO, reserva>(dto, entidad);


            _context.SaveChanges();
            return Ok(entidad.id);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var entity = _context.reserva.Where(w => w.id == id).Select(s => s).FirstOrDefault();

            if (entity == null) return NotFound(id);

            if (entity.confirmado) return BadRequest("No se puede eliminar una reserva confirmada");
            if (entity.fechaInicio < DateTime.Now.AddHours(4)) return BadRequest("No se puede eliminar una reserva con una diferencia horaria de menos de 4 horas");

            _context.reserva.Remove(entity);
            _context.SaveChanges();

            return Ok(entity.id);

        }
        [HttpPatch("id")]
        public IActionResult Confirmacion(int id)
        {
            var entity = _context.reserva
                .Where(w => w.id == id)
                .FirstOrDefault();
            if (id != entity.id) return BadRequest();

            if (entity.fechaDeConfirmacion < entity.fechaInicio.AddHours(2)) return BadRequest("La fecha de confirmacion debe tener una diferencia horaria de por lo menos 2 horas con la fecha de inicio");

            entity.fechaDeConfirmacion = DateTime.Now;
            entity.confirmado = true;
            _context.SaveChanges();
            return Ok(entity.confirmado);
        }
    }
}
