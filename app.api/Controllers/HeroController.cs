using app.api.Authentication;
using app.data.Domains;
using app.service.Services.UserService;
using StrataSpot.Api.Helpers;
using System.Collections.Generic;
using System.Web.Http;

namespace app.api.Controllers
{
    [RoutePrefix("api/hero")]
    public class HeroController : ApiController
    {
        protected IUserService _userService { set; get; }

        public HeroController(IUserService userService)
        {
            _userService = userService;
        }

        //[JwtAuthorize]
        //[Authorize]
        [Route("getheroes")]
        [HttpGet]
        public IHttpActionResult GetHeroes()
        {
            var result = new List<Hero> { new Hero { Id = 1, Name = "Superman" }, new Hero { Id = 2, Name = "Batman" } };
            return Ok(result);
        }

        [Route("gethero")]
        [HttpGet]
        public IHttpActionResult GetHero(int id)
        {
            var result = new Hero { Id = 1, Name = "Superman" };
            return Ok(result);
        }
    }
}
