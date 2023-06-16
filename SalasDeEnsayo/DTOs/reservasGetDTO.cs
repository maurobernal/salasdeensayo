namespace SalasDeEnsayo.DTOs
{
    public class reservasGetDTO
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int salaDeEnsayoId { get; set; }
        public SalaDeEnsayoGetDTO salaDeEnsayo { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public bool confirmado { get; set; }
        public DateTime fechaDeConfirmacion { get; set; }
    }
}
