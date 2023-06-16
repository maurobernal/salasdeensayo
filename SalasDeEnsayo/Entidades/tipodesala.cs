namespace SalasDeEnsayo.Entidades;

public class tipodesala : entidadbase
{
    public virtual List<saladeensayo> saladeensayos { get; set; }
    public virtual List<listadeprecio> listadeprecios { get; set; }
}
