using Microsoft.AspNetCore.Http.HttpResults;

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

            //Mapers
            entidad = _mapper.Map<reserva>(dto);

            //Campos predeterminados

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

            _context.reserva.Remove(entity);
            _context.SaveChanges();

            return Ok(entity.id);

        }
    }
}
