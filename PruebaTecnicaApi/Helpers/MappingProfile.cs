using AutoMapper;
using PruebaTecnicaApi.DTO;
using PruebaTecnicaApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace PruebaTecnicaApi.Helpers
{
    //==================================================================================================================
    public class MappingProfile : Profile
    {
        //--------------------------------------------------------------------------------------------------------------
        /*CONSTRUCTORS*/

        //--------------------------------------------------------------------------------------------------------------
        public MappingProfile()
        {
            CreateMap<HostentHostEntity, HostdtoHostDto>().ReverseMap();
            CreateMap<HabentHabitacionEntity, HabidtoHabitacionDto>().ReverseMap();
            CreateMap<TiphabentTipoHabitacionEntity, TiphabidtoTipoHabitacionDto>().ReverseMap();
        }

        //--------------------------------------------------------------------------------------------------------------
    }
    //==================================================================================================================
}
/*END-TASK*/
