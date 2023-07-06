using System.ComponentModel.DataAnnotations;

namespace front.DTOs;

public class EquipamientoDTO
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int SalaDeEnsayoId { get; set; }

    public SalasDeEnsayoDTO Sala { get; set; }

    [Required]
    public int InstrumentoId { get; set; }
    public InstrumentoDTO Instrumento { get; set; }
}
