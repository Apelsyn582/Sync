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
            new User{ Name="Admin", Phone="+380000000000", Password="e4ff319f93e3d2a63fc3dd4bf34666d922725efc536dd1d235455be49439ecda"},
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
                    Password = user.Password

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


        public static bool IfUserExists(string phone, string password)
        {
            return users.Any(u => u.Phone == phone && u.Password == password);
        }



        public static bool IfNameIsBooked(string name)
        {
            return users.Any(u => u.Name == name);
        }

        public static bool IfPhoneIsBooked(string phone)
        {
            return users.Any(u => u.Phone == phone);
        }


        public static void DeleteUser(User user)
        {
            users.Remove(user);
        }

        public static void ChangeName(User user, string name)
        {
            foreach (var item in users)
            {
                if(item.Password == user.Password)
                {
                    item.ChangeName(name);
                }
            }
            
        }

        public static void ChangePhone(User user, string phone)
        {
            foreach (var item in users)
            {
                if (item.Password == user.Password)
                {
                    item.ChangePhone(phone);
                }
            }
        }

    }
}
