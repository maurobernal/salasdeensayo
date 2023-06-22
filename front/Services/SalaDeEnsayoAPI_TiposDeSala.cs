namespace front.Services
{
    public partial class SalaDeEnsayoAPI : ISalaDeEnsayosAPI
    {
        public int TiposDeSalaDeletById(int id)
        {
            throw new NotImplementedException();
        }

        public TiposDeSalaDTO TiposDeSalaGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TiposDeSalaDTO> TiposDeSalaGetList()
        {
            var list = new List<TiposDeSalaDTO>();
            list.Add(new TiposDeSalaDTO() { Id = 1, Descripcion = "Sala Confort" });
            list.Add(new TiposDeSalaDTO() { Id = 2, Descripcion = "Sala Extra" });
            list.Add(new TiposDeSalaDTO() { Id = 3, Descripcion = "Sala Plus" });
            return list;
        }

        public int TiposDeSalaPost(TiposDeSalaDTO entity)
        {
            throw new NotImplementedException();
        }

        public int TiposDeSalaUpdateById(TiposDeSalaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
