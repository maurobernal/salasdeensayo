using System.ComponentModel.DataAnnotations;

namespace front.DTOs
{
    public class InstrumentoDTO: BaseDTO
    {
        [Required]
        [MaxLength(50)]
        [MinLength(3, ErrorMessage ="El campo 'Marca' no cumple la longitud mínima")]
        public string Marca { get; set; }
    }
}
