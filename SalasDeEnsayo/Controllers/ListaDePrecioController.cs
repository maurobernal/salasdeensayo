using Microsoft.AspNetCore.Mvc;
using SalasDeEnsayo.Entidades;

namespace SalasDeEnsayo.Controllers;
[Route("api/")]
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
    [HttpPost("TiposDeSala/{tipodesalaid}/listadeprecio")]
    public IActionResult PostPecio([FromBody] ListaDePrecioCreateDTO dto, int tipodesalaid)
    {
        var entidad = new listadeprecio();


        var cant = _context.tipodesala.Where(w => w.id == tipodesalaid).Count();
        if (cant == 0) return NotFound($"El tipo de sala no fue encontrado" + tipodesalaid);


        entidad = _mapper.Map<listadeprecio>(dto);
        entidad.tiposalaid = tipodesalaid;
        _context.listadeprecio.Add(entidad);

        _context.SaveChanges();

        return Ok(entidad.id);
    }

    [HttpGet("TiposDeSala/{tipodesalaid}/listadeprecio/{id}")]

    public IActionResult Get(int tipodesalaid, int id)
    {
        var tipodesala = _context.tipodesala.Where(x => x.id == tipodesalaid).Select(x => x).FirstOrDefault();
        if (tipodesala == null) return NotFound();
        var entidad = _context.listadeprecio.Where(w => w.tiposalaid == tipodesalaid).Include(s => s.tiposala).Select(s => s).FirstOrDefault();
        var dto = _mapper.Map<ListaDePrecioGetDTO>(entidad);

        return Ok(dto);
    }

    [HttpGet("TiposDeSala/{tipodesalaid}/listadeprecio")]


    public IActionResult GetList(int tipodesalaid)
    {
        var tipodesala = _context.tipodesala.Where(x => x.id == tipodesalaid).Select(x => x).FirstOrDefault();
        if (tipodesala == null) return NotFound();
        var entidad = _context.listadeprecio.Where(w => w.tiposalaid == tipodesalaid).Include(s => s.tiposala).Select(s => s).ToList();

        var dto = _mapper.Map<List<ListaDePrecioGetDTO>>(entidad);

        return Ok(dto);
    }
    [HttpPut("TiposDeSala/{tipodesalaid}/listadeprecio/{id}")]


    public IActionResult Put(int id, [FromBody] ListaDePrecioUpdateDTO dto,int tipodesalaid)
    {
        var tipodesala = _context.tipodesala.Where(x => x.id == tipodesalaid).Select(x => x).FirstOrDefault();
        if (tipodesala == null) return NotFound("el tipo de sala no existe");
        

        if (id != dto.id) return NotFound("el id enviado por parametro no coincide con el del cuerpo de la req");

        var entidad = _context.listadeprecio.Where(w => w.tiposalaid == tipodesalaid).FirstOrDefault();

        if (entidad == null) return NotFound("no existe esa lista de prcio en este tipo");
        if (entidad.tiposalaid != tipodesalaid) NotFound("el id del tipo de sala no coincide con el de la lista de precio");

        _mapper.Map<ListaDePrecioUpdateDTO, listadeprecio>(dto, entidad);
        _context.SaveChanges();
        return Ok(dto.id);
    }


    [HttpDelete("TiposDeSala/{tipodesalaid}/listadeprecio/{id}")]
    public IActionResult EliminarSalaDeEnsayo(int id,int tipodesalaid)
    {
        var tipodesala = _context.tipodesala.Where(x => x.id == tipodesalaid).Select(x => x).FirstOrDefault();
        if (tipodesala == null) return NotFound("el tipo de sala no existe");

        var entidad = _context.listadeprecio.Where(w => w.tiposalaid == tipodesalaid).FirstOrDefault();
        if (entidad == null) return NotFound("no existe esa lista de prcio en este tipo");
        if (entidad.tiposalaid != tipodesalaid) NotFound("el id del tipo de sala no coincide con el de la lista de precio");

        var entity = _context.listadeprecio.Where(w => w.id == id).Select(s => s).FirstOrDefault();

        if (entity == null) return NotFound(id);

        _context.listadeprecio.Remove(entity);

        _context.SaveChanges();



        return Ok(entity.id);
    }
}
