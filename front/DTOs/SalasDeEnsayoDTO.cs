namespace front.DTOs
{
    public class SalasDeEnsayoDTO : BaseDTO
    {
        public int TipoDeSalaId { get; set; }
        public TiposDeSalaDTO TipoDeSala { get; set; }

    }
}
