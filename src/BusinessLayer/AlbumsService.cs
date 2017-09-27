using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Contract;
using BusinessLayer.Contract.Models;
using DataLayer.Contract;

namespace BusinessLayer
{
    public class AlbumsService : IAlbumsService
    {
        private readonly IAlbumsRepository _albumsRepo;

        public AlbumsService(IAlbumsRepository albumsRepo)
        {
            _albumsRepo = albumsRepo ?? throw new System.ArgumentNullException(nameof(albumsRepo));
        }

        public async Task<Album> FindAlbum(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Album>> GetAlbums(int page)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Album>> GetAlbumsForUser(string id, int page)
        {
            throw new System.NotImplementedException();
        }
    }
}
