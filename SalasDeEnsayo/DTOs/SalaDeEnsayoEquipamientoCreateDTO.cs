namespace SalasDeEnsayo.DTOs
{
    public class SalaDeEnsayoEquipamientoCreateDTO
    {
        public int instrumentoid { get; set; }
    }
    public class SalaDeEnsayoEquipamientoGetDTO
    {
        public int id { get; set; }
        public SalaDeEnsayoGetDTO salasdeensayo { get; set; }
        public int instrumentoid { get; set; }
        public InstrumentoGetDTO instrumento { get; set; }

    }

}
