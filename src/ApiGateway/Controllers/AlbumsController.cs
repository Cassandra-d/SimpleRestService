using ApiGateway.Contract.Models;
using BusinessLayer.Contract;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiGateway.Controllers
{
    [RoutePrefix("albums")]
    public class AlbumsController : ApiController
    {
        private readonly IAlbumsService _albumsService;
        private static MemoryCache _cache = new MemoryCache(nameof(AlbumsController)); // todo init with IoC

        public AlbumsController(IAlbumsService albumsService)
        {
            _albumsService = albumsService ?? throw new System.ArgumentNullException(nameof(albumsService));
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> AllAlbums(int page = 0)
        {
            var res = new GenericCollectionResult<Album>();
            var cacheKey = "page" + page.ToString();

            if (!_cache.Contains(cacheKey))
            {
                var internalAlbums = await _albumsService.GetAlbums(page);
                var mapped = internalAlbums.Select(_ => AutoMapper.Mapper.Instance.Map<Album>(_)).ToArray();

                _cache.Add(cacheKey, mapped, GetCachePolicy());
            }

            res.Data = (Album[]) _cache[cacheKey];

            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> AlbumById(string id)
        {
            var cacheKey = "album" + id;

            if (!_cache.Contains(cacheKey))
            {
                var internalAlbum = await _albumsService.FindAlbum(id);
                var mapped = AutoMapper.Mapper.Instance.Map<Album>(internalAlbum);

                _cache.Add(cacheKey, mapped, GetCachePolicy());
            }

            var album = (Album) _cache[cacheKey];

            return Ok(album);
        }

        private CacheItemPolicy GetCachePolicy()
        {
            // todo object pool pattern
            return new CacheItemPolicy() { AbsoluteExpiration = new System.DateTimeOffset(System.DateTime.Now.AddSeconds(15)) }; // todo cache interval to app.config
        }
    }
}
