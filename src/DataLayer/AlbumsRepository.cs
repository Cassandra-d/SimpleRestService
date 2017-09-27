using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Contract;
using DataLayer.Contract.Models;
using System.Net.Http;
using System;
using Newtonsoft.Json;

namespace DataLayer
{
    public class AlbumsRepository : IAlbumsRepository
    {
        private static HttpClient _client = new HttpClient(); // TODO use IoC

        public async Task<Album> FindAlbum(string albumId)
        {
            if (string.IsNullOrEmpty(albumId))
                throw new ArgumentNullException(nameof(albumId));

            var req = Constants.FakeDataHost + "albums/" + albumId;
            var resp = await _client.GetStringAsync(req);

            if (string.IsNullOrEmpty(resp))
                return null;

            return JsonConvert.DeserializeObject<Album>(resp);
        }

        public Task<IEnumerable<Album>> GetAlbums(int page)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Album>> GetAlbumsForUser(string userId, int page)
        {
            throw new System.NotImplementedException();
        }
    }
}
