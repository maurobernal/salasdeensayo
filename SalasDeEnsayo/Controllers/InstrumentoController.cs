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

        [HttpGet("{id}")]
        public IActionResult GetInstrumento(int id)
        {
            var entidad = _context.instrumento.Where(i => i.id == id).Select(s => s).FirstOrDefault();
            var dto = _mapper.Map<InstrumentoGetDTO>(entidad);
            return Ok(dto);
        }
        [HttpPost("")]
        public IActionResult PostInstrumento([FromBody] InstrumentoCreateDTO dto)
        {
            //Validators
            if (dto.Descripcion.Length < 0 || dto.Descripcion.Length > 100) BadRequest(dto.Descripcion);
            AppDbContext ctx = new AppDbContext();

            //Mapers
            instrumento entidad = new();
            entidad = _mapper.Map<instrumento>(dto);

            //Campos predeterminados
            entidad.creado = DateTime.Now;
            entidad.habilitado = true;

            ctx.Add(entidad);
            ctx.SaveChanges();
            return Ok(entidad.id);
        }

        [HttpPut("")]
        public IActionResult PutInstrumento([FromBody] InstrumentoUpdateDTO dto)
        {
            //Validators
            if (dto.Descripcion.Length < 0 || dto.Descripcion.Length > 100) BadRequest(dto.Descripcion);
            AppDbContext ctx = new AppDbContext();

            //Mapers
            instrumento entidad = new();
            _mapper.Map<InstrumentoUpdateDTO, instrumento>(dto, entidad);

            _context.SaveChanges();
            return Ok(entidad.id);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarSalaDeEnsayo(int id)
        {
            var entity = _context.instrumento.Where(i => i.id == id).Select(s => s).FirstOrDefault();

            if (entity == null) return NotFound(id);

            _context.instrumento.Remove(entity);
            _context.SaveChanges();

            return Ok(entity.id);
        }
    }
}
