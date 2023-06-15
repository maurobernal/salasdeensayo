namespace SalasDeEnsayo.Entidades;

public class listadeprecio
{
    public int id { get; set; }
    public virtual tipodesala tiposala { get; set; }
    public int tiposalaid { get; set; }
    public string dia { get; set; }
    public long precioxhora  { get; set;}
}
