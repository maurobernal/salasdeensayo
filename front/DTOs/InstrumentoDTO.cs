using System.ComponentModel.DataAnnotations;

namespace SalasDeEnsayo.DTOs
{
    public class InstrumentoDTO: BaseDTO
    {
        [Required]
        [MaxLength(50)]
        public string Marca { get; set; }

    }
    public class InstrumentoUpdateDTO: BaseDTO
    {
        [Required]
        [MaxLength(50)]
        public string Marca { get; set; }

    }
    public class InstrumentoGetDTO : BaseDTO
    {
        [Required]
        [MaxLength(50)]
        public string Marca { get; set; }
    }
}
