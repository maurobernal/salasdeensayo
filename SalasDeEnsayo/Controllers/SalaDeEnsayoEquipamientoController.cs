namespace SalasDeEnsayo.Controllers;

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

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var entidad = _context.saladeensayoequipamiento
            .Include(i => i.SalaDeEnsayo)
            .Include(i => i.Instrumentos).Where(w => w.id == id).Select(s => s).FirstOrDefault();
        var dto = _mapper.Map<SalaDeEnsayoEquipamientoGetDTO>(entidad);
        return Ok(dto);
    }

    [HttpGet()]
    public IActionResult GetEquipamientoSalas()
    {
        var entidad = _context.saladeensayoequipamiento
            .Include(i => i.SalaDeEnsayo)
            .Include(i => i.Instrumentos)
            .OrderBy(o => o.id).Select(s => s).ToList();
        var dto = _mapper.Map<List<SalaDeEnsayoGetDTO>>(entidad);
        return Ok(dto);
    }

    [HttpPost]
    public IActionResult PostEquipamientoSala([FromBody] SalaDeEnsayoEquipamientoCreateDTO dto, int id)
    {
        var entidad = new saladeensayoequipamiento();

        var entity = _context.saladeensayoequipamiento.Where(w => w.id == dto.id).Count();
        if (entity == null) return NotFound(id);

        entidad = _mapper.Map<saladeensayoequipamiento>(dto);

        _context.saladeensayoequipamiento.Add(entidad);
        _context.SaveChanges();
        return Ok(entidad.id);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEquipamientoSala(int id)
    {
        var entity = _context.saladeensayoequipamiento.Where(w => w.id == id).Select(s => s).FirstOrDefault();

        if (entity == null) return NotFound(id);

        _context.saladeensayoequipamiento.Remove(entity);
        _context.SaveChanges();

        return Ok(entity.id);
    }
}
