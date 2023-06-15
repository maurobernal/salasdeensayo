namespace SalasDeEnsayo.Profiles
{
    public class InstrumentoProfile : Profile
    {
        public InstrumentoProfile()
        {
            CreateMap<InstrumentoCreateDTO, instrumento>();
            CreateMap<InstrumentoUpdateDTO, instrumento>()
                            .ForMember(f => f.creado, otp => otp.Ignore())
                            .ForMember(f => f.habilitado, otp => otp.Ignore());

            CreateMap<InstrumentoGetDTO, instrumento>().ReverseMap();
        }
    }
}
