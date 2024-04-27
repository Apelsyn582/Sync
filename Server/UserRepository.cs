using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Project2024.Server
{
    public static class UserRepository
    {
        public static List<User> users = new()
        {
            new User{ Name="Admin", Phone="+380000000000", Password="55D2B4A12C17A237D83B4097368EB6E828B304BCEC7387AEDB84056BADF9D98B", Salt="8B5A8C129CFE4F02CFEB96E4841F1AAA14430C9834B9F19F5B2BDC4B9FAC6DF3"},
        };

        public static List<User> GetUsers() => users;

        public static User GetUserByPhone(string phone)
        {
            var user = users.FirstOrDefault(x => x.Phone == phone);

            if (user != null)
            {
                return new User
                {

                    Name = user.Name,
                    Phone = user.Phone,
                    Password = user.Password,
                    Salt = user.Salt
                };
            }
            else
            {
                return new User()
                {

                    Name = "ErrorName",
                    Phone = "ErrorPhone",
                    Password = "ErrorPassword"

                }; ;
            }

        }
        public static void AddUser(User user)
        {
            users.Add(user);
        }

        public static bool IfNameIsBooked(string name)
        {
            return users.Any(u => u.Name == name);
        }
        public static bool IfUserExists(string phone)
        {
            return users.Any(u => u.Phone == phone);
        }    

        public static void DeleteUser(User user)
        {
            users.Remove(user);
        }

    }
}
