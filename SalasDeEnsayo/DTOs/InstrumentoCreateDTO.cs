namespace SalasDeEnsayo.DTOs
{
    public class InstrumentoCreateDTO
    {
        public string marca { get; set; }
        public string descripcion { get; set; }

    }
    public class InstrumentoUpdateDTO
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string descripcion { get; set; }

    }
    public class InstrumentoGetDTO
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string descripcion { get; set; }
    }
}
