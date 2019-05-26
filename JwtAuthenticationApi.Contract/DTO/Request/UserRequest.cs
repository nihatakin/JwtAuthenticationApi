using System;
using System.Collections.Generic;
using System.Text;

namespace JwtAuthenticationApi.Contract.DTO.Request
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
