namespace CursoUdemy2.Models
{
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
