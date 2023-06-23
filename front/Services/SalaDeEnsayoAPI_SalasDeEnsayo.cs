namespace front.Services;

public partial class SalaDeEnsayoAPI : ISalaDeEnsayosAPI
{
    public int SalaDeEnsayoDeletById(int id)
    {
        throw new NotImplementedException();
    }

    public SalasDeEnsayoDTO SalaDeEnsayoGetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<SalasDeEnsayoDTO> SalaDeEnsayoGetList()
    {
        var salas = new List<SalasDeEnsayoDTO>();
        var tipo1 = new TiposDeSalaDTO() { Id = 1, Descripcion = "Confort" };
        var tipo2 = new TiposDeSalaDTO() { Id = 2, Descripcion = "Plus" };
        salas.Add(new SalasDeEnsayoDTO() { Id = 1, Descripcion = "Sala Roja", TipoDeSala = tipo1, TipoDeSalaId = tipo1.Id });
        salas.Add(new SalasDeEnsayoDTO() { Id = 2, Descripcion = "Sala Azul", TipoDeSala = tipo1, TipoDeSalaId = tipo1.Id });
        salas.Add(new SalasDeEnsayoDTO() { Id = 3, Descripcion = "Sala Amarilla", TipoDeSala = tipo1, TipoDeSalaId = tipo1.Id });
        salas.Add(new SalasDeEnsayoDTO() { Id = 4, Descripcion = "Sala Verde", TipoDeSala = tipo1, TipoDeSalaId = tipo1.Id });
        salas.Add(new SalasDeEnsayoDTO() { Id = 5, Descripcion = "Sala Rosa", TipoDeSala = tipo1, TipoDeSalaId = tipo1.Id });
        salas.Add(new SalasDeEnsayoDTO() { Id = 6, Descripcion = "Sala Negra", TipoDeSala = tipo2, TipoDeSalaId = tipo2.Id });
        salas.Add(new SalasDeEnsayoDTO() { Id = 7, Descripcion = "Sala Blanca", TipoDeSala = tipo2, TipoDeSalaId = tipo2.Id });
        salas.Add(new SalasDeEnsayoDTO() { Id = 8, Descripcion = "Sala Fucsia", TipoDeSala = tipo2, TipoDeSalaId = tipo2.Id });
        salas.Add(new SalasDeEnsayoDTO() { Id = 9, Descripcion = "Sala Celeste", TipoDeSala = tipo2, TipoDeSalaId = tipo2.Id });
        salas.Add(new SalasDeEnsayoDTO() { Id = 10, Descripcion = "Sala Gris", TipoDeSala = tipo2, TipoDeSalaId = tipo2.Id });
        return salas;
    }

    public int SalaDeEnsayoPost(SalasDeEnsayoDTO entity)
    {
        return new Random().Next(100);
    }

    public int SalaDeEnsayoUpdateById(SalasDeEnsayoDTO entity)
    {
        throw new NotImplementedException();
    }
}
