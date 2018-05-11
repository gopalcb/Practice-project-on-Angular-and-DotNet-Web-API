using app.data.AppContext;
using app.data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.service.Services.UserService
{
    public class UserService : IUserService
    {
        private AppContext context;
        public UserService()
        {
            context = new AppContext();
        }

        public User GetAuthenticateUser(string email, string password)
        {
            var user = context.Users.FirstOrDefault(u=>u.Email.ToLower() == email.ToLower() && u.Password == u.Password);
            return user;
        }

        public User GetUserById(Guid id)
        {
            var user = context.Users.Find(id);
            return user;
        }
    }
}