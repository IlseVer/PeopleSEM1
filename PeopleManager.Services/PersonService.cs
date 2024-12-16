using PeopleManager.Model;
using PeopleManager.Repository;

namespace PeopleManager.Services
{
    public class PersonService
    {
        private readonly PeopleManagerDbContext _dbContext;

        public PersonService(PeopleManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Read (all)
        public IList<Person> Find()
        {
            return _dbContext.People.ToList();
        }

        //Read (one)
        public Person? Get(int id)
        {
            return _dbContext.People
                .FirstOrDefault(p => p.Id == id);
        }

        //Create
        public Person Create(Person person)
        {
            _dbContext.People.Add(person);

            _dbContext.SaveChanges();

            return person;
        }

        //Update
        public Person? Update(int id, Person person)
        {
            //var dbPerson = _dbContext.People.FirstOrDefault(p => p.Id == id);
            var dbPerson = Get(id);
            if (dbPerson is null)
            {
                return null;
            }

            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;
            dbPerson.Email = person.Email;

            _dbContext.SaveChanges();

            return dbPerson;
        }
        
        //Delete
        public void Delete(int id)
        {
            var person = new Person
            {
                Id = id,
                FirstName = string.Empty,
                LastName = string.Empty
            };

            _dbContext.People.Attach(person);

            _dbContext.People.Remove(person);

            _dbContext.SaveChanges();
        }

    }
}
