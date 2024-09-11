using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.LinqTasksHW
{
    public class LinqTasks2
    {
        class Actor
        {
            public string ?Name { get; set; }
            public DateTime Birthdate { get; set; }
        }

        abstract class ArtObject
        {
            public string ?Author { get; set; }
            public string ?Name { get; set; }
            public int Year { get; set; }
        }

        class Film : ArtObject
        {
            public int Length { get; set; }
            public IEnumerable<Actor> ?Actors { get; set; }
        }

        class Book : ArtObject
        {
            public int Pages { get; set; }
        }
        public void CompleteTasks()
        {
            var data = new List<object>() {
            "Hello",
            new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
            new List<int>() {4, 6, 8, 2},
            new string[] {"Hello inside array"},
            new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>()
            {
                new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
            }},
            new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>()
            {
                new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
            }},
            new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
            "Leonardo DiCaprio"};
            Console.WriteLine("Task 1");
            Console.WriteLine(string.Join(", ", data.Where(x => x is not ArtObject)));
            Console.WriteLine("Task 2");
            Console.WriteLine(string.Join(", ", data.OfType<Film>().SelectMany(f => f.Actors!).Select(a => a.Name)));
            Console.WriteLine("Task 3");
            Console.WriteLine(string.Join(", ", data.OfType<Film>().SelectMany(f => f.Actors!).Count(actor => actor.Birthdate.Month == 8)));
            Console.WriteLine("Task 4");
            Console.WriteLine(string.Join(", ", data.OfType<Film>().SelectMany(f => f.Actors!).OrderBy(actor => actor.Birthdate).Take(2).Select(a => a.Name)));
            Console.WriteLine("Task 5");
            Console.WriteLine(string.Join(", ", data.OfType<Book>().GroupBy(b => b.Author).Select(g => $"{g.Key}: {g.Count()}")));
            Console.WriteLine("Task 6");
            Console.WriteLine(string.Join(", ", data.OfType<Book>().GroupBy(b => b.Author).Select(g => $"{g.Key} (Books): {g.Count()}").Concat(
                data.OfType<Film>().GroupBy(f => f.Author).Select(g => $"{g.Key} (Films): {g.Count()}"))));
            Console.WriteLine("Task 7");
            Console.WriteLine(data.OfType<Film>().SelectMany(f => f.Actors!).SelectMany(a => a.Name!.ToLower()).Distinct().Except(" ").Count());
            Console.WriteLine("Task 8");
            Console.WriteLine(string.Join(", ", data.OfType<Book>().OrderBy(b => b.Author).ThenBy(b => b.Pages).Select(b => b.Name)));
            Console.WriteLine("Task 9");
            Console.WriteLine(string.Join(", ", data.OfType<Film>().SelectMany(f => f.Actors.Select(a => $"{a.Name}: {string.Join(", ", data.OfType<Film>().Where(film => film.Actors.Any(actor => actor.Name == a.Name)).Select(film => film.Name))}")).Distinct()));
            Console.WriteLine("Task 10");
            Console.WriteLine(data.OfType<Book>().Sum(b => b.Pages) + data.OfType<IEnumerable>().SelectMany(e => e.OfType<int>()).Sum());
            Console.WriteLine("Task 11");
            Console.WriteLine(string.Join(", ", data.OfType<Book>().GroupBy(b => b.Author).ToDictionary(g => g.Key, g => g.Select(b => b.Name).ToList()).Select(kvp => $"{kvp.Key}: [{string.Join(", ", kvp.Value)}]")));
            Console.WriteLine("Task 12");
            Console.WriteLine(string.Join(", ", data.OfType<Film>().Where(f => f.Actors.Any(a => a.Name == "Matt Damon") && !f.Actors.Any(a => data.OfType<string>().Contains(a.Name))).Select(f => f.Name)));



        }
    }
}
