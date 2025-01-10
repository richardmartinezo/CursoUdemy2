using AutoMapper;
using CursoUdemy2.Models;

namespace CursoUdemy2.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PeopleDto, People>();
           
        }
    }
}
