namespace front.Services
{
    public partial class SalaDeEnsayoAPI : ISalaDeEnsayosAPI
    {
        private HttpClient _client;
        public SalaDeEnsayoAPI(IHttpClientFactory httpClientFactory)
        => _client = httpClientFactory.CreateClient("ApiSalaDeEnsayo");


        public int TiposDeSalaDeletById(int id)
        {
            throw new NotImplementedException();
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

        public int TiposDeSalaUpdateById(TiposDeSalaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
