namespace SalasDeEnsayo.Profiles
{
    public class SalasDeEnsayoEquipamientoProfile: Profile
    {
        public SalasDeEnsayoEquipamientoProfile()
        {
            CreateMap<SalaDeEnsayoEquipamientoCreateDTO, saladeensayoequipamiento>();
            CreateMap<SalaDeEnsayoEquipamientoGetDTO, saladeensayoequipamiento>().ReverseMap();
        }
    }
}
