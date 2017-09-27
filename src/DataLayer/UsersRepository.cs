using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Contract;
using DataLayer.Contract.Models;

namespace DataLayer
{
    public class UsersRepository : IUsersRepository
    {
        public Task<User> FindUser(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers(int page)
        {
            throw new System.NotImplementedException();
        }
    }
}
