using JwtAuthenticationApi.Contract.DTO;
using System.Collections.Generic;

namespace JwtAuthenticationApi.Application.Data.Dummy
{
    public static class UserData
    {
        public static List<User> GetUserList()
        {
            // dummy  user hardcode data store in a db with hashed passwords in production applications
            return new List<User>
            {
                new User { Id = 1, FirstName = "Test User Name", LastName = "Test User Last Name", Username = "test", Password = "test" }
            };
        }
    }
}
