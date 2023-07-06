using System.ComponentModel.DataAnnotations;

namespace front.DTOs
{
    public class ReservaDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo 'Fecha Desde' es requerido")]
        [Display(Name = "Fecha Desde")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El Campo 'Fecha Hasta' es requerido")]
        [Display(Name = "Fecha Hasta")]
        public DateTime FechaFin { get; set; }

        //[UIHint("EditorTipoDeSalaReserva")]
        [Required(ErrorMessage = "El Campo 'Sala' es requerido")]
        public int SalaDeEnsayoId { get; set; }

        public SalasDeEnsayoDTO SalaDeEnsayo { get; set; }
    }

    public class ReservaTipoDTO: ReservaDTO
    {
        public int TipoDeSalaId { get; set; }
    }
    public class ReservaGetDTO : ReservaDTO
    {
        public DateTime fechaDeConfirmacion { get; set; }
        public int TipoDeSalaId { get; set; }
    }
}
