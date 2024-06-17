using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class UserRepository
    {

        public static List<User> Users { get; set; } = new List<User>();

        public static void AddUser(User user)
        {
            Users.Add(user);
        }

        public static User GetUser(string username)
        {
            return Users.FirstOrDefault(u => u.Username == username);
        }

        public static void UpdateUser(User user)
        {
            var existingUser = GetUser(user.Username);
            if (existingUser != null)
            {
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;
            }
        }

        public static void DeleteUser(string username)
        {
            var user = GetUser(username);
            if (user != null)
            {
                Users.Remove(user);
            }
        }
    }
}