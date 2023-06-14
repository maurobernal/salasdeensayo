using System.ComponentModel.DataAnnotations;

namespace SalasDeEnsayo.Entidades;

public abstract class entidadbase
{
    public int id { get; set; }
    public string descripcion { get; set; }

    public bool habilitado { get; set; }
    public DateTime creado { get; set; }

}
