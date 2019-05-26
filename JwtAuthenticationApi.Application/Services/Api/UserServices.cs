using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using JwtAuthenticationApi.Application.Data.Dummy;
using JwtAuthenticationApi.Application.Interfaces.Services.Api;
using JwtAuthenticationApi.Contract.DTO;
using JwtAuthenticationApi.Core.Helpers;
using Microsoft.Extensions.Options;

namespace JwtAuthenticationApi.Application.Services.Api
{
   public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = UserData.GetUserList(); 

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            return user ?? null;
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }
    }
}