using SalasDeEnsayo.DTOs;

namespace front.Interfaces
{
    public interface IInstrumento
    {
        public Task<InstrumentoGetDTO> InstrumentoGetByIdAsync(int id);
        public Task<List<InstrumentoGetDTO>> InstrumentoGetListAsync();
        public Task<int> InstrumentoPostAsync(InstrumentoDTO entity);
        public Task<int> InstrumentoUpdateById(InstrumentoUpdateDTO entity);
        public Task<int> TiposDeSalaDeleteById(int id);
    }
}
