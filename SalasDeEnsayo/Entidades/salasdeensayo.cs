namespace SalasDeEnsayo.Entidades;
public class saladeensayo : entidadbase
{
    public virtual List<saladeensayoequipamiento> saladeensayoequipamiento { get; set; }
    public virtual tipodesala tipo { get; set; }
    public int tipodesalaid { get; set; }
    public int capacidad { get; set; }
}
