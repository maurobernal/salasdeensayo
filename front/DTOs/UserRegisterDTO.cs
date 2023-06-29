using System.ComponentModel.DataAnnotations;

namespace front.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        [RegularExpression("/^[A-Za-z0-9]+$/g")]
        public string Password { get; set; }
    }
}
