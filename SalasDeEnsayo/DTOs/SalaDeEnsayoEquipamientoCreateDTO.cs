namespace SalasDeEnsayo.DTOs
{
    public class SalaDeEnsayoEquipamientoCreateDTO
    {
        public int salasdeensayoid { get; set; }
        public int instrumentoid { get; set; }
    }
    public class SalaDeEnsayoEquipamientoGetDTO
    {
        public int salasdeensayoid { get; set; }
        public saladeensayo saladeensayo { get; set; }
        public int instrumentoid { get; set; }
        public instrumento instrumento { get; set; }
    }

}
