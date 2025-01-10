using CursoUdemy2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoUdemy2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IPeopleService _peopleService;
        public RandomController([FromKeyedServices("peopleServiceKeyed")]IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
    }
}
