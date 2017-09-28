using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Contract;
using DataLayer.Contract.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace DataLayer.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private HttpClient _client;
        private readonly string _fakeDataHost;
        private const string RESOURCE = "users";
        private const int PAGE_SIZE = 5;

        public UsersRepository(HttpClient client, string fakeDataHost)
        {
            if (string.IsNullOrEmpty(fakeDataHost))
                throw new ArgumentNullException(nameof(fakeDataHost));

            _client = client ?? throw new ArgumentNullException(nameof(client));
            _fakeDataHost = fakeDataHost;
        }

        public async Task<User> FindUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));

            var req = _fakeDataHost + RESOURCE + "/" + userId;
            return await GetOne(req);
        }

        public async Task<IEnumerable<User>> GetUsers(int page)
        {
            var req = _fakeDataHost + RESOURCE;
            return await GetMany(req, page);
        }

        private async Task<IEnumerable<User>> GetMany(string req, int page)
        {
            var resp = await _client.GetStringAsync(req);

            var deserialized = JsonConvert.DeserializeObject<IEnumerable<User>>(resp);
            return deserialized.Skip(page * PAGE_SIZE).Take(PAGE_SIZE);
        }

        private async Task<User> GetOne(string req)
        {
            var resp = await _client.GetStringAsync(req);
            return JsonConvert.DeserializeObject<User>(resp);
        }
    }
}
