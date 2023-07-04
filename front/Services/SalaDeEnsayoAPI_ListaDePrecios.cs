namespace front.Services;

public partial class SalaDeEnsayoAPI :ISalaDeEnsayosAPI
{
    public async Task<int> ListaDePrecioPostAsync(ListaDePrecioDTO entity,int id)
    {
        var peticion = await _client.PostAsJsonAsync($"TiposDeSala/{id}/listadeprecio", entity);
        var res = await peticion.Content.ReadFromJsonAsync<int>();
        return res;
    }

    public async Task<List<ListaDePrecioDTO>> ListaDePrecioGetListAsync(int idSala2)
    {
        var peticion = await _client.GetAsync($"TiposDeSala/{idSala2}/listadeprecio");
        var res = await peticion.Content.ReadFromJsonAsync<List<ListaDePrecioDTO>>();
        return res;
    }

}
