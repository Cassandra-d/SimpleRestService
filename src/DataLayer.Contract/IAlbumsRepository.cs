using DataLayer.Contract.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Contract
{
    public interface IAlbumsRepository
    {
        Task<Album> FindAlbum(string id);
        Task<IEnumerable<Album>> GetAlbums(int page);
        Task<IEnumerable<Album>> GetAlbumsForUser(string userId, int page);
    }
}
