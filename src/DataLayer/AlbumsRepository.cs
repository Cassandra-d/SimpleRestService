using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Contract;
using DataLayer.Contract.Models;

namespace DataLayer
{
    public class AlbumsRepository : IAlbumsRepository
    {
        public Task<Album> FindAlbum(string id)
        {
            throw new System.NotImplementedException();
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
