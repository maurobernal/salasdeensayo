namespace SalasDeEnsayo.Profiles
{
    public class SalaDeEnsayoEquipamientoProfile: Profile
    {
        public SalaDeEnsayoEquipamientoProfile()
        {
            CreateMap<SalaDeEnsayoEquipamientoCreateDTO, saladeensayoequipamiento>();
            CreateMap<SalaDeEnsayoEquipamientoGetDTO, saladeensayoequipamiento>().ReverseMap();
        }
    }
}
