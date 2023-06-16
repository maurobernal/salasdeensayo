using Microsoft.AspNetCore.Mvc;

namespace SalasDeEnsayo.Controllers;
[Route("api/[controller]")]
[ApiController]

public class ListaDePrecioController : ControllerBase
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    public ListaDePrecioController(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpPost]
    public IActionResult PostPecio([FromBody] ListaDePrecioCreateDTO dto)
    {
        var entidad = new listadeprecio();


        var cant = _context.tipodesala.Where(w => w.id == dto.tiposalaid).Count();
        if (cant == 0) return NotFound($"El tipo de sala no fue encontrado" + dto.tiposalaid);


        entidad = _mapper.Map<listadeprecio>(dto);

        _context.listadeprecio.Add(entidad);

        _context.SaveChanges();

        return Ok(entidad.id);
    }

    [HttpGet("{id}")]

    public IActionResult Get(int id)
    {
        var entidad = _context.listadeprecio.Where(w => w.id == id).Include(s => s.tiposala).Select(s => s).FirstOrDefault();
        var dto = _mapper.Map<ListaDePrecioGetDTO>(entidad);

        return Ok(dto);
    }

    [HttpGet()]

    public IActionResult GetList()
    {
        var entidad = _context.listadeprecio.Include(s => s.tiposala).Select(s => s).ToList();
        var dto = _mapper.Map<List<ListaDePrecioGetDTO>>(entidad);

        return Ok(dto);
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ListaDePrecioUpdateDTO dto)
    {
        if (id != dto.id) return NotFound("el id enviado por parametro no coincide con el del cuerpo de la req");
        var entidad = _context.listadeprecio.Where(w => w.id == id).FirstOrDefault();
        if (entidad == null) return NotFound(dto);
        _mapper.Map<ListaDePrecioUpdateDTO, listadeprecio>(dto, entidad);
        _context.SaveChanges();
        return Ok(dto.id);
    }


    [HttpDelete("{id}")]
    public IActionResult EliminarSalaDeEnsayo(int id)
    {

        var entity = _context.listadeprecio.Where(w => w.id == id).Select(s => s).FirstOrDefault();

        if (entity == null) return NotFound(id);

        _context.listadeprecio.Remove(entity);
        _context.SaveChanges();


        return Ok(entity.id);
    }
}
