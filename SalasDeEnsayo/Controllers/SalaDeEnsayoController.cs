

namespace SalasDeEnsayo.Controllers
{
    [Route("api/saladeensayo")]
    [ApiController]
    public class SalasDeEnsayoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _context;


        public SalasDeEnsayoController(IMapper mapper, IAppDbContext context)
        {
            _mapper = mapper;
            _context = context;

        }


        [HttpGet("{id}")]
        public IActionResult RecuperarSalaDeEnsayo(int id)
        {
            var entidad = _context.saladeensayo.Include(i => i.tipo).Where(w => w.id == id).Select(s => s).FirstOrDefault();
            var dto = _mapper.Map<SalaDeEnsayoGetDTO>(entidad);
            return Ok(dto);
        }


        [HttpGet]
        public IActionResult RecuperarSalasDeEnsayos(int tipo)
        {
            var entidad = _context.saladeensayo
                .Include(i => i.tipo)
                .Include(i => i.reservas)
                .Where(w => tipo == 0 || w.tipodesalaid == tipo)
                .OrderBy(o => o.id).Select(s => s).ToList();
            var dto = _mapper.Map<List<SalaDeEnsayoGetDTO>>(entidad);
            return Ok(dto);
        }



        [HttpPost]
        public IActionResult Crearsaladeensayo([FromBody] SalaDeEnsayoCreateDTO dto)
        {

            var entidad = new saladeensayo();

            if (dto.descripcion.Length < 0 || dto.descripcion.Length > 100) return BadRequest(dto.descripcion);
            var cant = _context.tipodesala.Where(w => w.id == dto.tipodesalaid).Count();
            if (cant == 0) return NotFound($"El tipo de sala no fue encontrado" + dto.tipodesalaid);


            entidad = _mapper.Map<saladeensayo>(dto);

            entidad.creado = DateTime.Now;
            entidad.habilitado = true;
            _context.saladeensayo.Add(entidad);
            _context.SaveChanges();
            return Ok(entidad.id);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarSalaDeEnsayo([FromBody] SalaDeEnsayoUpdateDTO dto, int id)
        {
            if (id != dto.id) return BadRequest();
            if (dto.descripcion.Length < 0 || dto.descripcion.Length > 100) return BadRequest(dto.descripcion);

            var entidad = _context.saladeensayo.Where(w => w.id == id).FirstOrDefault();
            if (entidad == null) return NotFound(dto);
            _mapper.Map<SalaDeEnsayoUpdateDTO, saladeensayo>(dto, entidad);


            _context.SaveChanges();
            return Ok(entidad.id);
        }


        [HttpDelete("{id}")]
        public IActionResult EliminarSalaDeEnsayo(int id)
        {

            var entity = _context.saladeensayo.Where(w => w.id == id).Select(s => s).FirstOrDefault();

            if (entity == null) return NotFound(id);

            _context.saladeensayo.Remove(entity);
            _context.SaveChanges();


            return Ok(entity.id);
        }
    }
}