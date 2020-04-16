using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementattions
{
    public class PersonRepositoryImpl : GenericRepository<Person>, IPersonRepository
    {

        public PersonRepositoryImpl(MySQLContext context) : base(context) { }

        public List<Person> FindByName(string firstName, string lastName)
        {
            //Contains -> Parcial e Equals exatamente igual
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName)) 
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName) &&
                    p.LastName.Contains(lastName)).ToList();
            } else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName)) 
            {
                return _context.Persons.Where(p => p.LastName.Contains(lastName)).ToList();
            } else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName)) 
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName)).ToList();
            } else 
            {
                return _context.Persons.ToList();
            }
        }
    }
}
