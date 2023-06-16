namespace SalasDeEnsayo.Entidades
{
    public class instrumento
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string descripcion { get; set; }
        public DateTime fechacompra { get; set; }
        public bool habilitado { get; set; }
        public virtual List<saladeensayoequipamiento> Equipamiento { get; set; }

    }
}
