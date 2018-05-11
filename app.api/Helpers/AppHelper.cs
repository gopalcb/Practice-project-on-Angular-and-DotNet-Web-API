using app.data.Domains;
using app.service.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace StrataSpot.Api.Helpers
{
    public static class AppHelper
    {
        //** This method extract http request header from HttpActionContext **//
        public static string GetRequestHeaderValue(this HttpActionContext actionContext, string headerName)
        {
            IEnumerable<string> vals;
            var req = actionContext.Request.Headers.TryGetValues(headerName, out vals);
            string header = vals?.FirstOrDefault();
            return header;
        }

        //** This method extract http request header from HttpRequestMessage **//
        public static string GetRequestHeaderValue(this HttpRequestMessage request, string headerName)
        {
            IEnumerable<string> vals;
            var req = request.Headers.TryGetValues(headerName, out vals);
            var header = vals.FirstOrDefault();
            return header;
        }

        //** This method extract current logged in user from claim identity **//
        public static User IdentityUser()
        {
            var userService = DependencyResolver.Current.GetService<IUserService>();

            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var name = identity.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).FirstOrDefault();
            var email = identity.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).FirstOrDefault();
            var sid = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).FirstOrDefault();

            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            var user = userService.GetUserById(new Guid(sid));
            return user;
        }
    }
}