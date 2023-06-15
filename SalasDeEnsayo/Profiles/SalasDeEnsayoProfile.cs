namespace SalasDeEnsayo.Profiles
{
    public class SalasDeEnsayoProfile : Profile
    {
        public SalasDeEnsayoProfile()
        {
            CreateMap<SalaDeEnsayoCreateDTO, saladeensayo>();
            CreateMap<SalaDeEnsayoUpdateDTO, saladeensayo>()
                                .ForMember(f => f.creado, otp => otp.Ignore())
                                .ForMember(f => f.habilitado, otp => otp.Ignore())
                                .ForMember(f => f.tipodesalaid, otp => otp.Ignore());
            CreateMap<SalaDeEnsayoGetDTO, saladeensayo>().ReverseMap();
        }
    }
}
