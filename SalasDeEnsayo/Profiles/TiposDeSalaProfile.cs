namespace SalasDeEnsayo.Profiles;
public class TiposDeSalaProfile : Profile
{
    public TiposDeSalaProfile()
    {
        CreateMap<TiposDeSalaCreateDTO, tipodesala>();
        CreateMap<TiposDeSalaUpdateDTO, tipodesala>();
        CreateMap<tipodesala, TiposDeSalaGetDTO>().ReverseMap();
    }
}
