namespace SalasDeEnsayo.Entidades;

public class instrumento: entidadbase
{
    public virtual saladeensayoequipamiento SalaDeEnsayoEquipamiento { get; set; }
    public string marca { get; set; }
}
