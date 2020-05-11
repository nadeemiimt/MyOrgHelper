﻿using Common.Contract;

namespace Common.Models
{
    public class Credentials : ICredentials
    {
        public Credentials()
        {

        }

        public Credentials(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
