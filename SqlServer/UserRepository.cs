using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2024.SqlServer
{
    public class UserRepository
    {
        public List<User> users = new()
        {
            new User{ Name="Admin", Phone="Admin@gmail.com", Password="16aefdb4e6feedb53469c0210c8deecc650e822550f743c409e00b9a4fea1393"},
        };

        public List<User> GetUsers() => users;

        public User GetUserByPhone(string phone)
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
        public void AddUser(User user)
        {
            users.Add(user);
        }


        public bool IfUserExists(string phone, string password)
        {
            return users.Any(u => u.Phone == phone && u.Password == password);
        }

        public bool IfNameIsBooked(string name)
        {
            return users.Any(u => u.Name == name);
        }

        public bool IfPhoneIsBooked(string phone)
        {
            return users.Any(u => u.Phone == phone);
        }

        public void DeleteUser(User user)
        {
            users.Remove(user);
        }

    }
}
