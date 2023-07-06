using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace front.Services;

public partial class SalaDeEnsayoAPI : ISalaDeEnsayosAPI
{

    public async Task<int> EquipamientoPostAsync(EquipamientoDTO entity)
    {
        var peticion = await _client.PostAsJsonAsync($"saladeensayo/{entity.SalaDeEnsayoId}/equipamiento", entity);
        if (!peticion.IsSuccessStatusCode)
        {
            return 404;
        }
        var res = await peticion.Content.ReadFromJsonAsync<int>();
        return res;
    }

    public async Task<int> EquipamientoDeletById(EquipamientoDTO entity)
    {
        var peticion = await _client.DeleteAsync($"saladeensayo/{entity.SalaDeEnsayoId}/equipamiento/{entity.Id}");
        var res = await peticion.Content.ReadFromJsonAsync<int>();
        return res;

    }

    public async Task<List<EquipamientoDTO>> EquipamientoGetListAsync(int idsala)
    {
        var peticion = await _client.GetAsync($"saladeensayo/{idsala}/equipamiento");
        var res = await peticion.Content.ReadFromJsonAsync<List<EquipamientoDTO>>();       
        return res;
    }

    //public async Task<EquipamientoDTO> EquipamientoGetByIdAsync(int id, int SalaDeEnsayoId)
    //{
    //    var peticion = await _client.GetAsync($"saladeensayo/{SalaDeEnsayoId}/equipamiento/{id}");
    //    var res = await peticion.Content.ReadFromJsonAsync<EquipamientoDTO>();
    //    return res;
    //}
}
