using System.ComponentModel.DataAnnotations;

namespace front.DTOs
{
    public class InstrumentoDTO: BaseDTO
    {
        [Required]
        [MaxLength(50)]
        [MinLength(8)]
        public string Marca { get; set; }

    }
}
