namespace SalasDeEnsayo.Profiles
{
    public class ReservasProfile :Profile
    {
        public ReservasProfile()
        {
            CreateMap<reservasCreateDTO, reserva>();
            CreateMap<reserva, reservasCreateDTO>();

            CreateMap<reservasGetDTO, reserva>();
            CreateMap<reserva, reservasGetDTO>();
            CreateMap<reservasUpdateDTO, reserva>();
            CreateMap<reserva, reservasUpdateDTO>();
        }
    }
}
