using app.service.Services.UserService;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace app.api.Providers
{
    public class AuthenticationServiceProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var userService = DependencyResolver.Current.GetService<IUserService>();
            var email = context.UserName.ToLower();
            var user = userService.GetAuthenticateUser(context.UserName.ToLower(), context.Password);
            if (user != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, $"{user.Name}"));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided email and password is incorrect");
                return;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

    }
}