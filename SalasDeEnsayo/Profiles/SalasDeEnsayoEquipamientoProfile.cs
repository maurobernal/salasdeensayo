namespace SalasDeEnsayo.Profiles
{
    public class SalasDeEnsayoEquipamientoProfile: Profile
    {
        public SalasDeEnsayoEquipamientoProfile()
        {
            CreateMap<SalaDeEnsayoEquipamientoCreateDTO, saladeensayoequipamiento>();
            CreateMap<SalaDeEnsayoEquipamientoUpdateDTO, saladeensayoequipamiento>();
            CreateMap<SalaDeEnsayoEquipamientoGetDTO, saladeensayoequipamiento>().ReverseMap();
        }
    }
}
