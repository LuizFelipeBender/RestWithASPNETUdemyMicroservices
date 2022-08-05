using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Services.Implementation
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile uint count;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person  person = Mockpersons(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindByID(ulong id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                Gender = "Male",
            };
        }

        public Person Update()
        {
            throw new NotImplementedException();
        }

        public Person Mockpersons(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                Gender = "Male",

            };
        }

        private ulong IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}