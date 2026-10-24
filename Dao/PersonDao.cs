using Entity_library;

namespace Dao_library
{
    public class PersonDao
    {
        public Person CreatePerson(Person person)
        {
            person.Id = MockDatabase.Persons.Count + 1;
            MockDatabase.Persons.Add(person);
            return person;
        }

        public Person? ReadPersonById(long id)
        {
            return MockDatabase.Persons.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdatePerson(Person person)
        {
            var existingPerson = MockDatabase.Persons.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                existingPerson.Name = person.Name;
                existingPerson.Age = person.Age;
                existingPerson.Dni = person.Dni;
                return true;
            }
            return false;
        }

        public bool DeletePersonById(long id)
        {
            var existingPerson = MockDatabase.Persons.FirstOrDefault(p => p.Id == id);
            if (existingPerson != null)
            {
                MockDatabase.Persons.Remove(existingPerson);
                return true;
            }
            return false;
        }

        public List<Person> GetAllPersons()
        {
            return MockDatabase.Persons;
        }
    }
}
