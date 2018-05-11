using app.api.Helpers;
using app.service.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace app.api.Controllers
{
    public class JwtAuthController : ApiController
    {
        protected IUserService _userService { set; get; }

        public JwtAuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [Route("api/auth/token")]
        public string Get(string email, string password)
        {
            var user = _userService.GetAuthenticateUser(email, password);
            if (user != null)
            {
                return JwtHelper.GenerateToken(email);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
    }
}
