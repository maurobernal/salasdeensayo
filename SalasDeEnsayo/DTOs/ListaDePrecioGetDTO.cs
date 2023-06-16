namespace SalasDeEnsayo.DTOs;

public class ListaDePrecioGetDTO
{
    public int id { get; set; }
    public int dia { get; set; }
    public double precioxhora { get; set; }
    public TiposDeSalaGetDTO tiposala { get; set; }
}
