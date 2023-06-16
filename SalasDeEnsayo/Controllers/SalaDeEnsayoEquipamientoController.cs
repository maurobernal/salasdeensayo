using SalasDeEnsayo.Entidades;

namespace SalasDeEnsayo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaDeEnsayoEquipamientoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _context;

        public SalaDeEnsayoEquipamientoController(IMapper mapper, IAppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("saladeensayo/{saladeensayoid}")]
        public IActionResult Post([FromBody] SalaDeEnsayoEquipamientoCreateDTO dto, int saladeensayoid)
        {
            var instrumento = _context.instrumento.Select(s => s).Where(w => w.id == dto.instrumentoid).FirstOrDefault();
            if (instrumento == null) return NotFound($"El registro instrumento con ID: {dto.instrumentoid} no se encuentra");

            //Validator
            saladeensayoequipamiento validator = _context.saladeensayoequipamiento
                .Include(i => i.instrumento).Include(i => i.salasdeensayo)
                .Where(w => w.instrumentoid == dto.instrumentoid).Select(s => s).FirstOrDefault();
            if (validator.instrumento != null) return NotFound($"El instrumento con ID: {dto.instrumentoid} ya se encuentra asignado a una sala");


            var salaDeEnsayo = _context.saladeensayo.Select(s => s).Where(w => w.id == saladeensayoid).FirstOrDefault();
            if (salaDeEnsayo == null) return NotFound($"El registro sala de ensayo con ID: {saladeensayoid} no se encuentra");

            //Mapers
            saladeensayoequipamiento entidad = new();
            entidad = _mapper.Map<saladeensayoequipamiento>(dto);
            entidad.salasdeensayoid = saladeensayoid;

            _context.saladeensayoequipamiento.Add(entidad);
            _context.SaveChanges();
            return Ok(entidad.id);
        }

        [HttpGet("saladeensayo/{saladeensayoid}/equipamiento/{id}")]
        public IActionResult Get(int saladeensayoid, int id)
        {
            saladeensayoequipamiento entidad = _context.saladeensayoequipamiento
                .Include(i => i.instrumento).Include(i => i.salasdeensayo)
                .Where(w => w.id == id).Select(s => s).FirstOrDefault();
            if (entidad == null) return NotFound($"El registro con ID: {id} no se encuentra");


            var dto = _mapper.Map<SalaDeEnsayoEquipamientoGetDTO>(entidad);
            return Ok(dto);
        }

        [HttpGet("saladeensayo/{saladeensayoid}/equipamiento")]
        public IActionResult GetAll()
        {
            var entidad = _context.saladeensayoequipamiento
                .Include(i => i.instrumento)
                .Include(i => i.salasdeensayo.tipo)
                .OrderBy(o => o.id)
                .Select(s => s).ToList();

            if (entidad == null || entidad.Count() == 0) return NotFound($"No se encontraron registros de Equipamiento");


            var dto = _mapper.Map<List<SalaDeEnsayoEquipamientoGetDTO>>(entidad);
            return Ok(dto);
        }

        [HttpDelete("saladeensayo/{saladeensayoid}/equipamient/{id}")]
        public IActionResult Delete(int saladeensayoid, int id)
        {
            saladeensayoequipamiento entidad = _context.saladeensayoequipamiento.Where(w => w.id == id).FirstOrDefault();
            if (entidad == null) return NotFound($"El registro con ID: {id} no se encuentra");

            _context.saladeensayoequipamiento.Remove(entidad);
            _context.SaveChanges();
            return Ok(entidad.id);
        }
    }
}
