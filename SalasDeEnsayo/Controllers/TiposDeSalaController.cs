namespace SalasDeEnsayo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("ConcurrencyMinPolicy")]
    public class TiposDeSalaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IValidator<TiposDeSalaUpdateDTO> _validator;

        public TiposDeSalaController(IMapper mapper, IValidator<TiposDeSalaUpdateDTO> validator)
        {
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] TiposDeSalaCreateDTO dto)
        {
            //Validators
            if (dto.descripcion.Length < 0 || dto.descripcion.Length > 100) BadRequest(dto.descripcion);
            AppDbContext ctx = new AppDbContext();



            //Mapers
            tipodesala entidad = new();
            entidad = _mapper.Map<tipodesala>(dto);

            //Campos predeterminados
            entidad.creado = DateTime.Now;
            entidad.habilitado = true;

            ctx.Add(entidad);
            ctx.SaveChanges();
            return Ok(entidad.id);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] TiposDeSalaUpdateDTO dto, int id)
        {

            //Validators
            if (id != dto.Id) return BadRequest();
            if (dto.descripcion.Length < 0 || dto.descripcion.Length > 100) return BadRequest(dto.descripcion);

            AppDbContext ctx = new AppDbContext();

            tipodesala entidad = ctx.tipodesala.Single(w => w.id == id);

            if (entidad == null) return NotFound(dto);
            _mapper.Map<TiposDeSalaUpdateDTO, tipodesala>(dto, entidad);

            ctx.SaveChanges();
            return Ok(entidad.id);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            AppDbContext ctx = new AppDbContext();
            tipodesala entidad = ctx.tipodesala.Where(w => w.id == 9).Select(x => x).FirstOrDefault();
            if (entidad == null) return NotFound(id);
            ctx.Remove(entidad);
            ctx.SaveChanges();
            return Ok(entidad.id);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            AppDbContext ctx = new AppDbContext();
            tipodesala entidad = ctx.tipodesala.Where(x => x.id == id).Select(x => x).FirstOrDefault();
            var dto = _mapper.Map<TiposDeSalaGetDTO>(entidad);
            return Ok(dto);

        }

        [HttpGet("")]
        public IActionResult GetList()
        {

            AppDbContext ctx = new AppDbContext();
            var entidad = ctx.tipodesala.OrderBy(o => o.id).Select(s => s).ToList();

            var res = _mapper.Map<List<TiposDeSalaGetDTO>>(entidad);

            System.Threading.Thread.Sleep(15000);
            return Ok(res);

        }


    }
}
