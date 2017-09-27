using ApiGateway.Contract.Models;
using BusinessLayer.Contract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiGateway.Controllers
{
    [RoutePrefix("albums")]
    public class AlbumsController : ApiController
    {
        private readonly IAlbumsService _albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            _albumsService = albumsService ?? throw new System.ArgumentNullException(nameof(albumsService));
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> AllAlbums(int page = 0)
        {
            var internalAlbums = await _albumsService.GetAlbums(page); // TODO check cache
            var res = new GenericCollectionResult<Album>();

            res.Data = internalAlbums.Select(_ => AutoMapper.Mapper.Instance.Map<Album>(_)).ToArray();

            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> AlbumById(string id)
        {
            var internalAlbum = await _albumsService.FindAlbum(id); // TODO check cache
            var album = AutoMapper.Mapper.Instance.Map<Album>(internalAlbum);

            return Ok(album);
        }
    }
}
