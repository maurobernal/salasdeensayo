namespace front.Services
{
    public partial class SalaDeEnsayoAPI : ISalaDeEnsayosAPI
    {
        private HttpClient _client;
        public SalaDeEnsayoAPI(IHttpClientFactory httpClientFactory)
        => _client = httpClientFactory.CreateClient("ApiSalaDeEnsayo");


        public async Task<int> TiposDeSalaDeletById(int id)
        {
            var peticion = await _client.DeleteAsync($"TiposDeSala/{id}");
            var res = await peticion.Content.ReadFromJsonAsync<int>();
            return res;
        }

        public async Task<TiposDeSalaDTO> TiposDeSalaGetByIdAsync(int id)
        {
            var peticion = await _client.GetAsync($"TiposDeSala/{id}");
            var res = await peticion.Content.ReadFromJsonAsync<TiposDeSalaDTO>();
            return res;
        }

        public async Task<List<TiposDeSalaDTO>> TiposDeSalaGetListAsync()
        {
            var peticion = await _client.GetAsync("TiposDeSala");
            var res = await peticion.Content.ReadFromJsonAsync<List<TiposDeSalaDTO>>();
            return res;
        }

        public async Task<int> TiposDeSalaPostAsync(TiposDeSalaDTO entity)
        {
            var peticion = await _client.PostAsJsonAsync("TiposDeSala", entity);
            var res = await peticion.Content.ReadFromJsonAsync<int>();
            return res;
        }

        public async Task<int> TiposDeSalaUpdateById(TiposDeSalaDTO entity)
        {
            var peticion = await _client.PutAsJsonAsync($"TiposDeSala/{entity.Id}", entity);
            var res = await peticion.Content.ReadFromJsonAsync<int>();
            return res;
        }
    }
}
