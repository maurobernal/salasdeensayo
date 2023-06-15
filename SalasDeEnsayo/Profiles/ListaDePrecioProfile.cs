namespace SalasDeEnsayo.Profiles;

public class ListaDePrecioProfile:Profile
{
    public ListaDePrecioProfile()
    {
        CreateMap<ListaDePrecioCreateDTO, listadeprecio>();
        CreateMap<ListaDePrecioGetDTO, listadeprecio>().ReverseMap();
        CreateMap<ListaDePrecioUpdateDTO, listadeprecio>()
            .ForMember(f => f.tiposala, opt => opt.Ignore());
    }
}
