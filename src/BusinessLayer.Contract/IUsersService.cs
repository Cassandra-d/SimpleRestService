using BusinessLayer.Contract.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Contract
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetUsers(int page);
        Task<User> FindUsers(string id);
    }
}
