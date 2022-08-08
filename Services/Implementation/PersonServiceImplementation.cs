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

        public List<Person> FindAll()
        {
            List<Person> peoples = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person  person = Mockpeoples(i);
                peoples.Add(person);
            }
            return peoples;
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


        public Person Mockpeoples(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"John{+ i}",
                LastName = $"Doe{+ i}",
                Address = $"123 Main St{+ i}",
                Gender = $"Male{+ i}",

            };
        }

        private ulong IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Update(Person person)
        {
            return person;
        }

        public void Delete(ulong id)
        {
            throw new NotImplementedException();
        }
    }
}