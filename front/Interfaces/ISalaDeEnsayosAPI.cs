namespace front.Interfaces;

public interface ISalaDeEnsayosAPI
{
    public Task<TiposDeSalaDTO> TiposDeSalaGetByIdAsync(int id);
    public Task<List<TiposDeSalaDTO>> TiposDeSalaGetListAsync();
    public Task<int> TiposDeSalaPostAsync(TiposDeSalaDTO entity);
    public Task<int> TiposDeSalaUpdateById(TiposDeSalaDTO entity);
    public Task<int> TiposDeSalaDeletById(int id);

    public Task<SalasDeEnsayoDTO> SalaDeEnsayoGetByIdAsync(int id);
    public Task<List<SalasDeEnsayoDTO>> SalaDeEnsayoGetListAsync(int tiposalaid);
    public Task<int> SalaDeEnsayoPostAsync(SalasDeEnsayoDTO entity);
    public Task<int> SalaDeEnsayoUpdateByIdAsync(SalasDeEnsayoDTO entity);
    public Task<int> SalaDeEnsayoDeletByIdAsync(int id);

    public Task<int> ListaDePrecioPostAsync (ListaDePrecioDTO entity,int idSala);
    public Task<List<ListaDePrecioDTO>> ListaDePrecioGetListAsync(int idSala);
}
