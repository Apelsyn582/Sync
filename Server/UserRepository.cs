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
            new User{ Name="Liuba", Phone="+380676680977", Password="B44757B875F028C06E93A0523CC036B3AB6E4D31723BA7372BBDD58FDA5A9CD8", Salt="608D29D1BF5947B290B9BCCFB7E68D1112721873141935299E8D6CFFF2A6E809"},
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
