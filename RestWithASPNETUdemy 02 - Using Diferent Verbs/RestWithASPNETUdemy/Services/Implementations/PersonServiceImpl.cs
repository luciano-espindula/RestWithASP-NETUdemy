using System;
using System.Collections.Generic;
using System.Threading;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{

    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        Person IPersonService.Create(Person person) {
            return person;
        }

        void IPersonService.Delete(long id) {
        }

        List<Person> IPersonService.FindAll() {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++) {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i) {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Luciano_" + i,
                LastName = "Espindula_" + i,
                Address = "Rua dos Flamingos_" + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet() {
            return Interlocked.Increment(ref count);
        }

        Person IPersonService.FindById(long id) {
            return MockPerson(1);
            //    new Person
            //{
            //    Id = 1,
            //    FirstName = "Luciano",
            //    LastName = "Espindula",
            //    Address = "Rua dos Flamingos",
            //    Gender = "Male"
            //};
        }

        Person IPersonService.Update(Person person) {
            return person;
        }
    }
}
