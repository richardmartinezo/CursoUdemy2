using CursoUdemy2.Models;
using CursoUdemy2.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursoUdemy2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;
        public PeopleController()
        {
            _peopleService = new PeopleService();
        }
        [HttpGet("all")]
        public ActionResult<List<People>> GetPeople() => Repository.peopleDictionary.Values.ToList();

        [HttpGet("{id}")]
        public ActionResult<People> GetPerson(int id)
        {
            var people = Repository.people.Where(p => p.Id == id).FirstOrDefault();
            if (people != null)
            {
                return Ok(people);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<People> GetPersonDictionary(int id)
        {
            if (Repository.peopleDictionary.TryGetValue(id, out var person))
            {
                return Ok(person);
            }
            return NotFound();
        }

        [HttpGet("search/{search}")]
        public ActionResult<People> GetPersonDictionarySearch(string search)
        {
            var person = Repository.peopleDictionary.Where(p => p.Value.Name.ToLower().Contains(search.ToLower())).FirstOrDefault();
            if (person.Value != null) 
            {
                return Ok(person.Value);
            } 
            return NotFound();
        }
        [HttpPatch]
        public IActionResult EditPeople([FromBody] People people) 
        {
            if (_peopleService.Validate(people)) 
            {
                return BadRequest();
            }
            Repository.people.Add(people);
            return Ok();

        }
    }

  
}