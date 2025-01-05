using Microsoft.AspNetCore.Mvc;

namespace CursoUdemy2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpPost]
        public decimal Add(Numbers number, [FromHeader] string Host,
            [FromHeader(Name = "Content-Length")] string ContentLength)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);
            return number.A + number.B;
        }
    }

    public class Numbers
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
    }
}