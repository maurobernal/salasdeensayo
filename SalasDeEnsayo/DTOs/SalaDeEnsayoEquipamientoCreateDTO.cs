namespace SalasDeEnsayo.DTOs
{
    public class SalaDeEnsayoEquipamientoCreateDTO
    {
        public int id { get; set; }
        public int idsaladeensayo { get; set; }
        public int idinstrumento { get; set; }
    }

    public class SalaDeEnsayoEquipamientoGetDTO
    {
        public int id { get; set; }
        public int idsaladeensayo { get; set; }
        public int idinstrumento { get; set; }
        public InstrumentoGetDTO instrumentos { get; set; }
        public SalaDeEnsayoEquipamientoGetDTO sala { get; set; }

    }

    public class SalaDeEnsayoEquipamientoUpdateDTO
    {
        //public int id { get; set; }
        //public string descripcion { get; set; }
        //public int capacidad { get; set; }
    }
}
