namespace front.Services
{
    public class Instrumento : IInstrumento
    {
        private HttpClient _client;
        public Instrumento(IHttpClientFactory httpClientFactory)
        => _client = httpClientFactory.CreateClient("ApiSalaDeEnsayo");

        public async Task<InstrumentoDTO> InstrumentoGetByIdAsync(int id)
        {
            var peticion = await _client.GetAsync($"Instrumento/{id}");
            var res = await peticion.Content.ReadFromJsonAsync<InstrumentoDTO>();
            return res;
        } 

        public async Task<List<InstrumentoDTO>> InstrumentoGetListAsync()
        {
            var peticion = await _client.GetAsync("Instrumento");
            var res = await peticion.Content.ReadFromJsonAsync<List<InstrumentoDTO>>();
            return res;
        }

        public async Task<int> InstrumentoPostAsync(InstrumentoDTO entity)
        {
            var peticion = await _client.PostAsJsonAsync("Instrumento", entity);
            var res = await peticion.Content.ReadFromJsonAsync<int>();
            return res;
        }

        public async Task<int> InstrumentoUpdateById(InstrumentoDTO entity)
        {
            var peticion = await _client.PutAsJsonAsync($"Instrumento/{entity.Id}", entity);
            var res = await peticion.Content.ReadFromJsonAsync<int>();
            return res;
        }

        public async Task<int> InstrumentoDeleteById(int id)
        {
            var peticion = await _client.DeleteAsync($"Instrumento/{id}");
            var res = await peticion.Content.ReadFromJsonAsync<int>();
            return res;
        }
    }
}
