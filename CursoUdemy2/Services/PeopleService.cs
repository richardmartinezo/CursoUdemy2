using AutoMapper;
using CursoUdemy2.Controllers;
using CursoUdemy2.Models;

namespace CursoUdemy2.Services
{
    public class PeopleService : IPeopleService
    {
        private IMapper _mapper;
        public PeopleService(IMapper mapper) 
        {
            _mapper = mapper;
        }
        public async Task<bool> Add(PeopleDto peopleDto) 
        {
            if (!Validate(_mapper.Map<People>(peopleDto)))
            {
                return false;
            }
            People people = _mapper.Map<People>(peopleDto);
            return true;
        }
        public bool Validate(People people) 
        {
            if (string.IsNullOrEmpty(people.Name)) 
            {
                return false;
            }
            return true;
        }
    }
}
