using System.ComponentModel.DataAnnotations;

namespace front.DTOs
{
    public abstract class BaseDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
    }
}
