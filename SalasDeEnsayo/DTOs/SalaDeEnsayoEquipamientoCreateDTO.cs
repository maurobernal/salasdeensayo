namespace SalasDeEnsayo.DTOs
{
    public class SalaDeEnsayoEquipamientoCreateDTO
    {
        public int instrumentoid { get; set; }
    }
    public class SalaDeEnsayoEquipamientoGetDTO
    {
        public SalaDeEnsayoGetDTO salasdeensayo { get; set; }
        public int instrumentoid { get; set; }
        public InstrumentoGetDTO instrumento { get; set; }
    }

}
