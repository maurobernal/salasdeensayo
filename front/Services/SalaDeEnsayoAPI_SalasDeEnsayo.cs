namespace front.Services;

public partial class SalaDeEnsayoAPI : ISalaDeEnsayosAPI
{
    public async Task<int> SalaDeEnsayoDeletByIdAsync(int id)
    {
        var peticion = await _client.DeleteAsync($"SalaDeEnsayo/{id}");
        var res = await peticion.Content.ReadFromJsonAsync<int>();
        return res;
    }

    public async Task<SalasDeEnsayoDTO> SalaDeEnsayoGetByIdAsync(int id)
    {

        var peticion = await _client.GetAsync($"SalaDeEnsayo/{id}");
        var res = await peticion.Content.ReadFromJsonAsync<SalasDeEnsayoDTO>();
        return res;

    }

    public async Task<List<SalasDeEnsayoDTO>> SalaDeEnsayoGetListAsync(int tipodesalaid)
    {
        var peticion = await _client.GetAsync($"SalaDeEnsayo?tipo={tipodesalaid}");
        var res = await peticion.Content.ReadFromJsonAsync<List<SalasDeEnsayoDTO>>();
        return res;
    }

    public async Task<int> SalaDeEnsayoPostAsync(SalasDeEnsayoDTO entity)
    {
        var peticion = await _client.PostAsJsonAsync("SalaDeEnsayo", entity);
        var res = await peticion.Content.ReadFromJsonAsync<int>();
        return res;
    }

    public async Task<int> SalaDeEnsayoUpdateByIdAsync(SalasDeEnsayoDTO entity)
    {
        var peticion = await _client.PutAsJsonAsync($"SalaDeEnsayo/{entity.Id}", entity);
        var res = await peticion.Content.ReadFromJsonAsync<int>();
        return res;
    }
}
