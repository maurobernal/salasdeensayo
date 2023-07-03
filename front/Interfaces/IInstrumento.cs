namespace front.Interfaces
{
    public interface IInstrumento
    {
        public Task<InstrumentoDTO> InstrumentoGetByIdAsync(int id);
        public Task<List<InstrumentoDTO>> InstrumentoGetListAsync();
        public Task<int> InstrumentoPostAsync(InstrumentoDTO entity);
        public Task<int> InstrumentoUpdateById(InstrumentoDTO entity);
        public Task<int> InstrumentoDeleteById(int id);
    }
}
