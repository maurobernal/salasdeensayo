namespace SalasDeEnsayo.DTOs;

public class SalaDeEnsayoGetDTO
{
    public int id { get; set; }
    public string descripcion { get; set; }
    public int capacidad { get; set; }
    public int tipodesalaid { get; set; }
    public TiposDeSalaGetDTO tipo { get; set; }
}
public class SalaDeEnsayoCreateDTO
{

    public string descripcion { get; set; }
    public int tipodesalaid { get; set; }

}


public class SalaDeEnsayoUpdateDTO
{
    public int id { get; set; }
    public string descripcion { get; set; }
    public int capacidad { get; set; }
}