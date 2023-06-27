using System.ComponentModel.DataAnnotations;

namespace front.DTOs
{
    public class SalasDeEnsayoDTO : BaseDTO
    {
        [UIHint("EditorTipoDeSala")]
        public int TipoDeSalaId { get; set; }



        public TiposDeSalaDTO Tipo { get; set; }




    }
}
