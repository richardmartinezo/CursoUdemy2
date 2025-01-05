using Microsoft.AspNetCore.Mvc;

namespace CursoUdemy2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
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
            if (string.IsNullOrEmpty(people.Name)) 
            { 
                return BadRequest();
            }
            Repository.people.Add(people);
            return Ok();
        }
    }

    public class Repository
    {
        public static List<People> people = new List<People>
        {
            new People { Id = 1, Name = "John", BirthDate = new DateTime(1990, 1, 1) },
            new People { Id = 2, Name = "Mary", BirthDate = new DateTime(1991, 1, 1) },
            new People { Id = 3, Name = "Peter", BirthDate = new DateTime(1992, 1, 1) },
            new People { Id = 4, Name = "Alice", BirthDate = new DateTime(1993, 1, 1) },
            new People { Id = 5, Name = "Bob", BirthDate = new DateTime(1994, 1, 1) },
        };

        public static Dictionary<int, People> peopleDictionary = new Dictionary<int, People>
        {
            { 1, new People { Id = 1, Name = "John", BirthDate = new DateTime(1990, 1, 1) } },
            { 2, new People { Id = 2, Name = "Mary", BirthDate = new DateTime(1991, 1, 1) } },
            { 3, new People { Id = 3, Name = "Peter", BirthDate = new DateTime(1992, 1, 1) } },
            { 4, new People { Id = 4, Name = "Alice", BirthDate = new DateTime(1993, 1, 1) } },
            { 5, new People { Id = 5, Name = "Bob", BirthDate = new DateTime(1994, 1, 1) } },
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}