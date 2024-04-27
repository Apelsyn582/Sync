using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2024.Server
{
    public class User
    {
        private string phone = "0000000000000";
        private string name = "User";
        private string password = "????????";
        private string salt = "";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Salt
        {
            get { return salt; }
            set { salt = value; }
        }
    }

}

