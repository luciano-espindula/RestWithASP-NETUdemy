using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementattions
{
    public class UserRepositoryImpl : IUserRepository
    {

        private MySQLContext _context;

        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        // Método responsável por retornar uma pessoa
        public User FindByUser(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }

       
    }
}
