using System;
using System.Collections.Generic;
using System.Text;
using JwtAuthenticationApi.Contract.DTO;

namespace JwtAuthenticationApi.Application.Interfaces.Services.Api
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
