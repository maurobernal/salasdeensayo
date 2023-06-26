namespace front.Services;

public partial class SalaDeEnsayoAPI : ISalaDeEnsayosAPI
{
    public int SalaDeEnsayoDeletById(int id)
    {
        throw new NotImplementedException();
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
        _client.DefaultRequestHeaders.Add("Accept", "application/json");
        var res = await peticion.Content.ReadFromJsonAsync<int>();
        return res;
    }

    public int SalaDeEnsayoUpdateById(SalasDeEnsayoDTO entity)
    {
        throw new NotImplementedException();
    }
}
