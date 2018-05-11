using app.data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.service.Services.UserService
{
    public interface IUserService
    {
        User GetAuthenticateUser(string email, string password);
        User GetUserById(Guid id);
    }
}