using System.ComponentModel.DataAnnotations;

namespace front.DTOs
{
    public class ReservaDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo 'Fecha Desde' es requerido")]
        [Display(Name = "Fecha Desde")]
        public DateTime FechaDesde { get; set; }

        [Required(ErrorMessage = "El Campo 'Fecha Hasta' es requerido")]
        [Display(Name = "Fecha Hasta")]
        public DateTime FechaHasta { get; set; }

        //[UIHint("EditorTipoDeSalaReserva")]
        [Required(ErrorMessage = "El Campo 'Sala' es requerido")]
        public int SalaDeEnsayoId { get; set; }

        public SalasDeEnsayoDTO SalaDeEnsayo { get; set; }
    }

    public class ReservaFechaYHoraDTO: ReservaDTO
    {
        [Required]
        public TimeOnly HoraDesde { get; set; }
        [Required]
        public TimeOnly HoraHasta { get; set; }
    }
}
