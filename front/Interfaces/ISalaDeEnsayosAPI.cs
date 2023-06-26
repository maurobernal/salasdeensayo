namespace front.Interfaces;

public interface ISalaDeEnsayosAPI
{
    public TiposDeSalaDTO TiposDeSalaGetById(int id);
    public List<TiposDeSalaDTO> TiposDeSalaGetList();
    public int TiposDeSalaPost(TiposDeSalaDTO entity);
    public int TiposDeSalaUpdateById(TiposDeSalaDTO entity);
    public int TiposDeSalaDeletById(int id);

    public SalasDeEnsayoDTO SalaDeEnsayoGetById(int id);
    public List<SalasDeEnsayoDTO> SalaDeEnsayoGetList(int tiposalaid);
    public int SalaDeEnsayoPost(SalasDeEnsayoDTO entity);
    public int SalaDeEnsayoUpdateById(SalasDeEnsayoDTO entity);
    public int SalaDeEnsayoDeletById(int id);




}
