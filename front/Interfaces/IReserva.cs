namespace front.Interfaces
{
    public interface IReserva
    {
        public Task<ReservaDTO> ReservaGetByIdAsync(int id);
        public Task<List<ReservaDTO>> ReservaGetListAsync();
        public Task<int> ReservaPostAsync(ReservaDTO entity);
        public Task<int> ReservaUpdateById(ReservaDTO entity);
        public Task<int> ReservaDeleteById(int id);
    }
}
