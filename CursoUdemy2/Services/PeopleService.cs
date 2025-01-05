using CursoUdemy2.Controllers;
using CursoUdemy2.Models;

namespace CursoUdemy2.Services
{
    public class PeopleService : IPeopleService
    {
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
