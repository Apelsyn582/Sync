
namespace Project2024.Server
{
    public static class UserRepository
    {
        public static List<User> users = new()
        {
           
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

                };
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
