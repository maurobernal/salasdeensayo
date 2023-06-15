namespace SalasDeEnsayo.Profiles
{
    public class TiposDeSalaProfile : Profile
    {
        public TiposDeSalaProfile()
        {
            //DTO a Entity
            CreateMap<TiposDeSalaCreateDTO, tipodesala>();
            CreateMap<TiposDeSalaUpdateDTO, tipodesala>();


            CreateMap<tipodesala, TiposDeSalaGetDTO>().ReverseMap();


            //Entiy a DTO
        }
    }
}
