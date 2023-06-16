using Microsoft.AspNetCore.Mvc;

namespace SalasDeEnsayo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _context;

        public InstrumentoController(IMapper mapper, IAppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] InstrumentoCreateDTO dto)
        {
            //Validators
            if (dto.descripcion.Length < 0 || dto.descripcion.Length > 100) BadRequest($"Descripcion Invalida: '{dto.descripcion}'");

            //Mapers
            instrumento entidad = new();
            entidad = _mapper.Map<instrumento>(dto);

            //Campos predeterminados
            entidad.fechacompra = DateTime.Now;
            entidad.habilitado = true;

            _context.instrumento.Add(entidad);
            _context.SaveChanges();
            return Ok(entidad.id);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] InstrumentoUpdateDTO dto, int id)
        {
            //Validators
            if (dto.descripcion.Length < 0 || dto.descripcion.Length > 100) BadRequest($"Descripcion Invalida: '{dto.descripcion}'");
            if (dto.id != id) return BadRequest($"Los id no coinciden. ID Path: {id} | ID Body: {dto.id}");

            var entidad = _context.instrumento.Where(w => w.id == id).FirstOrDefault();
            if (entidad == null) return NotFound($"El registro con ID: {dto.id} no se encuentra");

            //Mapers
            _mapper.Map<InstrumentoUpdateDTO, instrumento>(dto, entidad);

            _context.SaveChanges();
            return Ok(entidad.id);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            instrumento entidad = _context.instrumento.Where(w => w.id == id).Select(s => s).FirstOrDefault();
            if (entidad == null) return NotFound($"El registro con ID: {id} no se encuentra");

            var dto = _mapper.Map<InstrumentoGetDTO>(entidad);
            return Ok(dto);
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var entidad = _context.instrumento.OrderBy(o => o.id).Select(s => s).ToList();
            if (entidad == null || entidad.Count() == 0) return NotFound($"No se encontraron registros de instrumentos");

            var res = _mapper.Map<List<InstrumentoGetDTO>>(entidad);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            instrumento entidad = _context.instrumento.Where(w => w.id == id).FirstOrDefault();
            if (entidad == null) return NotFound($"El registro con ID: {id} no se encuentra");

            _context.instrumento.Remove(entidad);
            _context.SaveChanges();

            return Ok(entidad.id);
        }
    }
}
