using ApiGateway.Contract.Models;
using BusinessLayer.Contract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiGateway.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly IUsersService _usrService;
        private readonly IAlbumsService _albumsService;

        public UsersController(IUsersService usrService, IAlbumsService albumsService)
        {
            _usrService = usrService ?? throw new System.ArgumentNullException(nameof(usrService));
            _albumsService = albumsService ?? throw new System.ArgumentNullException(nameof(albumsService));
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> AllUsers(int page = 0)
        {
            var usersInternal = await _usrService.GetUsers(page); // TODO check cache
            var res = new GenericCollectionResult<User>();

            res.Data = usersInternal.Select(_ => AutoMapper.Mapper.Instance.Map<User>(_)).ToArray();
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> UserById(string id)
        {
            var userInternal = await _usrService.FindUsers(id); // TODO check cache
            var user = AutoMapper.Mapper.Instance.Map<User>(userInternal);

            return Ok(user);
        }

        [HttpGet]
        [Route("{id}/albums")]
        public async Task<IHttpActionResult> UserAlbums(string id, int page = 0)
        {
            // I will skip checking that user does not exist with throwing meaningfull exception or better with return code
            // but in producation code this would be necessarry

            var res = new GenericCollectionResult<Album>();
            var internalAlbums = await _albumsService.GetAlbumsForUser(id, page); // TODO check cache

            res.Data = internalAlbums.Select(_ => AutoMapper.Mapper.Instance.Map<Album>(_)).ToArray();

            return Ok(res);
        }
    }
}
