namespace SalasDeEnsayo.DTOs
{
    public class reservasGetDTO
    {
        public int userId { get; set; }
        public int salaDeEnsayoId { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
    }
}
