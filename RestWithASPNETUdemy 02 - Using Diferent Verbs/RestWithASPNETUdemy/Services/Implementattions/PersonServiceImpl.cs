using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services.Implementations;

namespace RestWithASPNETUdemy.Services.Implementattions
{

    public class PersonServiceImpl : IPersonService
    {
        // Contador responsável por gerar um fake ID já que não estamos
        // acessando nenhum banco de dados
        private volatile int count;

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Luciano_" + i,
                LastName = "Espindula_" + i,
                Address = "Rua dos Flamingos_" + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        // Metodo responsável por criar uma nova pessoa se tivéssemos um banco de dados esse seria o
        // momento de persistir os dados
        public Person Create(Person person)
        {
            return person;
        }

        // Método responsável por deletar uma pessoa a partir de um ID
        public void Delete(long id)
        {
        }

        // Método responsável por retornar todas as pessoas mais uma vez essas informações são mocks
        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++) {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        // Método responsável por retornar uma pessoa como não acessamos nenhuma base de dados
        // estamos retornando um mock
        public Person FindById(long id)
        {
            return MockPerson(unchecked((int)id));
        }

        public Person Update(Person person)
        {
            return person;
        }


    }
}
