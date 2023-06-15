namespace SalasDeEnsayo.Entidades
{
    public class saladeensayoequipamiento
    {
        public int id { get; set; }
        public virtual saladeensayo SalaDeEnsayo { get; set; }
        public int idsaladeensayo { get; set; }
        public virtual List<instrumento> Instrumentos { get; set; }
        public int idinstrumento { get; set; }

    }
}
