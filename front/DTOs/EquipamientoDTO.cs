using System.ComponentModel.DataAnnotations;

namespace front.DTOs
{
    public class EquipamientoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SalaDeEnsayoId { get; set; }

        public SalasDeEnsayoDTO Sala { get; set; }

        //Editar despues con instrumentos... 

        [Required]
        public int TipoDeSalaId { get; set; }
        public TiposDeSalaDTO Tipos { get; set; }
    }
}
