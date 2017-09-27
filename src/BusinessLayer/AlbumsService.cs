using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Contract;
using BusinessLayer.Contract.Models;
using DataLayer.Contract;
using System.Linq;

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
            var dalAlbum = await _albumsRepo.FindAlbum(id);
            var album = AutoMapper.Mapper.Instance.Map<Album>(dalAlbum);

            return album;
        }

        public async Task<IEnumerable<Album>> GetAlbums(int page)
        {
            var dalAlbums = await _albumsRepo.GetAlbums(page);
            var albums = dalAlbums.Select(_ => AutoMapper.Mapper.Instance.Map<Album>(_)).ToArray();

            return albums;
        }

        public async Task<IEnumerable<Album>> GetAlbumsForUser(string userId, int page)
        {
            var dalAlbums = await _albumsRepo.GetAlbumsForUser(userId, page);
            var albums = dalAlbums.Select(_ => AutoMapper.Mapper.Instance.Map<Album>(_)).ToArray();

            return albums;
        }
    }
}
