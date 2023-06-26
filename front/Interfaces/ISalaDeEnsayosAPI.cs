namespace front.Interfaces;

public interface ISalaDeEnsayosAPI
{
    public Task<TiposDeSalaDTO> TiposDeSalaGetByIdAsync(int id);
    public Task<List<TiposDeSalaDTO>> TiposDeSalaGetListAsync();
    public int TiposDeSalaPost(TiposDeSalaDTO entity);
    public int TiposDeSalaUpdateById(TiposDeSalaDTO entity);
    public int TiposDeSalaDeletById(int id);

    public Task<SalasDeEnsayoDTO> SalaDeEnsayoGetByIdAsync(int id);
    public Task<List<SalasDeEnsayoDTO>> SalaDeEnsayoGetListAsync(int tiposalaid);
    public int SalaDeEnsayoPost(SalasDeEnsayoDTO entity);
    public int SalaDeEnsayoUpdateById(SalasDeEnsayoDTO entity);
    public int SalaDeEnsayoDeletById(int id);




}
