using System.ComponentModel.DataAnnotations;

namespace front.DTOs
{
    public class ReservaDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime FechaDesde { get; set; }
        [Required]
        public DateTime FechaHasta { get; set; }
    }
}
