namespace SalasDeEnsayo.DTOs;

public class ListaDePrecioCreateDTO
{
    public int tiposalaid { get; set; }
    public long precioxhora { get; set;}
    public string dia { get; set; }
}

public class ListaDePrecioGetDTO
{
    public TiposDeSalaGetDTO tiposala { get; set; }
    public long precioxhora { get; set; }
    public string dia { get; set; }
}

public class ListaDePrecioUpdateDTO
{
    public int id { get; set; }
    public long precioxhora { get; set; }
    public string dia { get; set; }
}
