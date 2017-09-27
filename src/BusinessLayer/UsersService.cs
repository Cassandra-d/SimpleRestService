using BusinessLayer.Contract;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Contract.Models;
using DataLayer.Contract;

namespace BusinessLayer
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepo;

        public UsersService(IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public async Task<User> FindUsers(string id)
        {
            var dalUser = await _usersRepo.FindUser(id);
            var user = AutoMapper.Mapper.Instance.Map<User>(dalUser);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers(int page)
        {
            var dalUsers = await _usersRepo.GetUsers(page);
            var users = dalUsers.Select(_ => AutoMapper.Mapper.Instance.Map<User>(_)).ToArray();

            return users;
        }
    }
}
