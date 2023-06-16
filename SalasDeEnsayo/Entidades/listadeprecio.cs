namespace SalasDeEnsayo.Entidades;

public class listadeprecio
{
    public int id { get; set; }
    public int tiposalaid { get; set; }
    public virtual tipodesala tiposala { get; set; }
    public int dia { get; set; }
    public double precioxhora  { get; set;}
}
