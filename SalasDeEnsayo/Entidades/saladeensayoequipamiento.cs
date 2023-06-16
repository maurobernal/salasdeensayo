namespace SalasDeEnsayo.Entidades
{
    public class saladeensayoequipamiento
    {
        public int id { get; set; }
        public virtual saladeensayo salasdeensayo { get; set; }
        public int salasdeensayoid { get; set;}
        public virtual instrumento instrumento { get; set; }
        public int instrumentoid { get; set; }
    }
}
