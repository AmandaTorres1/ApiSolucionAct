using Dao;
using Entity_library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dao_library
{
    public class PersonDao
    {
        
            public Person GetStudent(Person person)
            {
                return MockDatabase.Persons.FirstOrDefault(p => p.Id == person.Id);
            }
        public Person PostPerson(Person person)
        {
            if (person != null)
            {
                person.Id = MockDatabase.Persons.Count + 1;
                MockDatabase.Persons.Add(person);
                return person;
            }
            return null;
        }

        public Person PutPerson(Person person)
        {
            var existingPerson = MockDatabase.Persons.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                existingPerson.Name = person.Name;
                existingPerson.Age = person.Age;
                existingPerson.Dni = person.Dni;
                return existingPerson;
            }
            return null;
        }

        public List<Person> GetPerson()
        {
            return MockDatabase.Persons;
        }

        public bool DeletePerson(Person person)
        {
            var existingPerson = MockDatabase.Persons.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                MockDatabase.Persons.Remove(existingPerson);
                return true;
            }
            return false;
        }   
    }
}
