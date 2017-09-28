using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Contract;
using DataLayer.Contract.Models;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace DataLayer.Repositories
{
    public class AlbumsRepository : IAlbumsRepository
    {
        private HttpClient _client;
        private const string RESOURCE = "albums";
        private const int PAGE_SIZE = 5;

        public AlbumsRepository(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Album> FindAlbum(string albumId)
        {
            if (string.IsNullOrEmpty(albumId))
                throw new ArgumentNullException(nameof(albumId));

            var req = Constants.FakeDataHost + RESOURCE + "/" + albumId;
            return await GetOne(req);
        }

        public async Task<IEnumerable<Album>> GetAlbums(int page)
        {
            // well, the service does not support paging or navigation, so we have to retrieve everything
            // I don't see any reason why I should implement any optimisations here like caching or something similar, as it is not a programming problem I need to solve, but data storage

            var req = Constants.FakeDataHost + RESOURCE;
            return await GetMany(req, page);
        }

        public async Task<IEnumerable<Album>> GetAlbumsForUser(string userId, int page)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));

            // not nice situation here: we want to work only with albums here, but have to work with users too
            // the reason why it is here and not in users repo is that any developer that would want to look at how we retrieve albums for user will probably look at this repo first

            string usersResource = "users";
            var req = Constants.FakeDataHost + usersResource + "/" + userId + "/" + RESOURCE;

            return await GetMany(req, page);
        }

        private async Task<IEnumerable<Album>> GetMany(string req, int page)
        {
            var resp = await _client.GetStringAsync(req);

            if (string.IsNullOrEmpty(resp))
                return Enumerable.Empty<Album>();

            var deserialized = JsonConvert.DeserializeObject<IEnumerable<Album>>(resp);
            return deserialized.Skip(page * PAGE_SIZE).Take(PAGE_SIZE).ToArray();
        }

        private async Task<Album> GetOne(string req)
        {
            var resp = await _client.GetStringAsync(req);

            if (string.IsNullOrEmpty(resp))
                return null;

            return JsonConvert.DeserializeObject<Album>(resp);
        }
    }
}
