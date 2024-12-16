using Microsoft.EntityFrameworkCore;
using PeopleManager.Model;

namespace PeopleManager.Repository
{
    public class PeopleManagerDbContext(DbContextOptions<PeopleManagerDbContext> options) : DbContext(options)
    {
        public DbSet<Function> Functions => Set<Function>();
        public DbSet<Person> People => Set<Person>();

        public void Seed()
        {
            var function = new Function { Name = "Manager" };
            Functions.Add(function);

            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Function = function},
                new Person { FirstName = "Jane", LastName = "Smith" }, // Email is omitted
                new Person { FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com" },
                new Person { FirstName = "Emily", LastName = "Davis" }, // Email is omitted
                new Person { FirstName = "Chris", LastName = "Brown", Email = "chris.brown@example.com", Function = function },
                new Person { FirstName = "Jessica", LastName = "Wilson" }, // Email is omitted
                new Person { FirstName = "David", LastName = "Garcia", Email = "david.garcia@example.com" },
                new Person { FirstName = "Sophia", LastName = "Martinez" }, // Email is omitted
                new Person { FirstName = "Daniel", LastName = "Anderson", Email = "daniel.anderson@example.com" },
                new Person { FirstName = "Olivia", LastName = "Taylor", Function = function } // Email is omitted
            };

            People.AddRange(people);

            SaveChanges();
        }
    }
}
