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

    public List<SalasDeEnsayoDTO> SalaDeEnsayoGetList(int id)
    {
        throw new NotImplementedException();
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
