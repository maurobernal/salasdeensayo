using Microsoft.AspNetCore.Mvc;

namespace front.Services;

public partial class SalaDeEnsayoAPI: ISalaDeEnsayosAPI
{
    public async Task<EquipamientoDTO> EquipamientoGetByIdAsync(SalasDeEnsayoDTO entity,int id)
    {
        

    }
    public async Task<List<EquipamientoDTO>> EquipamientoGetListAsync(SalasDeEnsayoDTO entity)
    {
        
    }

    public async Task<int> EquipamientoPostAsync(EquipamientoDTO entity)
    {
        var peticion = await _client.PostAsJsonAsync($"saladeensayo/{entity.SalaDeEnsayoId}/equipamiento", entity);
        if (!peticion.IsSuccessStatusCode)
        {
            
        }
        var res = await peticion.Content.ReadFromJsonAsync<int>();
        return res;
    }

    public async Task<int> EquipamientoDeletById(int id, int SalaDeEnsayoId)
    {
        var peticion = await _client.DeleteAsync($"saladeensayo/{SalaDeEnsayoId}/equipamiento/{id}");
        var res = await peticion.Content.ReadFromJsonAsync<int>();
        return res;

    }

    public async Task<EquipamientoDTO> EquipamientoGetByIdAsync(int id, int SalaDeEnsayoId)
    {
        var peticion = await _client.GetAsync($"saladeensayo/{SalaDeEnsayoId}/equipamiento/{id}");
        var res = await peticion.Content.ReadFromJsonAsync<EquipamientoDTO>();
        return res;
    }

    public async Task<List<EquipamientoDTO>> EquipamientoGetListAsync()
    {
        var peticion = await _client.GetAsync($"saladeensayo/equipamiento");
        var res = await peticion.Content.ReadFromJsonAsync<List<EquipamientoDTO>>();
        return res;
    }

}
