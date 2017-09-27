using DataLayer.Contract.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Contract
{
    public interface IUsersRepository
    {
        Task<User> FindUser(string id);
        Task<IEnumerable<User>> GetUsers(int page);
    }
}
