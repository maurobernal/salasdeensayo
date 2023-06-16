namespace SalasDeEnsayo.Entidades;
public class saladeensayo : entidadbase
{
    public virtual tipodesala tipo { get; set; }
    public int tipodesalaid { get; set; }
    public int capacidad { get; set; }
    public virtual List<saladeensayoequipamiento> equipamiento { get; set; }

}
