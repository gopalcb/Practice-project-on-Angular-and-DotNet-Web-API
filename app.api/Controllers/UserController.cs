using app.api.Authentication;
using app.service.Services.UserService;
using StrataSpot.Api.Helpers;
using System.Web.Http;

namespace app.api.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        protected IUserService _userService { set; get; }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[JwtAuthorize]
        [Authorize]
        [Route("userdata")]
        [HttpGet]
        public IHttpActionResult UserData()
        {
            var currentUserId = AppHelper.IdentityUser().Id;
            var result = _userService.GetUserById(currentUserId);
            return Ok(result);
        }
    }
}
