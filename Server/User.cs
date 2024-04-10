using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2024.Server
{
    public class User
    {
        public string Name { get; set; } = "User";

        public string Phone { get; set; } = "0000000000000";

        public string Password { get; set; } = "????????";

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangePhone(string phone)
        {
            Phone = phone;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}
