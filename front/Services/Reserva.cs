using front.Interfaces;

namespace front.Services
{
    public class Reserva : IReserva
    {
        private HttpClient _client;
        public Reserva(IHttpClientFactory httpClientFactory)
        => _client = httpClientFactory.CreateClient("ApiSalaDeEnsayo");

        public async Task<ReservaDTO> ReservaGetByIdAsync(int id)
        {
            var peticion = await _client.GetAsync($"Reserva/{id}");
            var res = await peticion.Content.ReadFromJsonAsync<ReservaDTO>();
            return res;
        } 

        public async Task<List<ReservaDTO>> ReservaGetListAsync()
        {
            var peticion = await _client.GetAsync("Reserva");
            var res = await peticion.Content.ReadFromJsonAsync<List<ReservaDTO>>();
            return res;
        }

        public async Task<int> ReservaPostAsync(ReservaDTO entity)
        {
            var peticion = await _client.PostAsJsonAsync("Reserva", entity);
            var res = await peticion.Content.ReadFromJsonAsync<int>();
            return res;
        }

        public async Task<int> ReservaUpdateById(ReservaDTO entity)
        {
            var peticion = await _client.PutAsJsonAsync($"Reserva/{entity.Id}", entity);
            var res = await peticion.Content.ReadFromJsonAsync<int>();
            return res;
        }

        public async Task<int> ReservaDeleteById(int id)
        {
            var peticion = await _client.DeleteAsync($"Reserva/{id}");
            var res = await peticion.Content.ReadFromJsonAsync<int>();
            return res;
        }
    }
}
