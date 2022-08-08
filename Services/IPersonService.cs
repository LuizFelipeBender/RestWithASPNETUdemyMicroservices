using System.Collections.Generic;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Services.Implementation
{
    public interface IPersonService
    {
        Person Create(Person person); 
        Person FindByID(ulong id); 
        Person Update(Person person); 

        List<Person> FindAll();
        void Delete(ulong id);
        }
}