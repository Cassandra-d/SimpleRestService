using BusinessLayer.Contract.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Contract
{
    public interface IAlbumsService
    {
        Task<IEnumerable<Album>> GetAlbumsForUser(string id, int page);
        Task<IEnumerable<Album>> GetAlbums(int page);
        Task<Album> FindAlbum(string id);
    }
}
