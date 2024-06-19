//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace UserManagement.Models
//{
//    public class UserRepository
//    {

//        public static List<User> Users { get; set; } = new List<User>();

//        //public static void AddUser(User user)
//        //{
//        //    Users.Add(user);
//        //}

//        public static User GetUser(string username)
//        {
//            return Users.FirstOrDefault(u => u.Username == username);
//        }

//        public static void UpdateUser(User user)
//        {
//            var existingUser = GetUser(user.Username);
//            if (existingUser != null)
//            {
//                existingUser.Password = user.Password;
//                existingUser.Email = user.Email;
//            }
//        }

//        public static void DeleteUser(string username)
//        {
//            var user = GetUser(username);
//            if (user != null)
//            {
//                Users.Remove(user);
//            }
//        }
/////////////////////////////////////
//        public static void AddUser(User user)
//        {
//            user.Password = EncryptPassword(user.Password);
//            Users.Add(user);
//        }

//        private static string EncryptPassword(string password)
//        {
//            using (var sha256 = System.Security.Cryptography.SHA256.Create())
//            {
//                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//                var builder = new System.Text.StringBuilder();
//                foreach (var b in bytes)
//                {
//                    builder.Append(b.ToString("x2"));
//                }
//                return builder.ToString();
//            }
//        }

//    }
//}


using System.Collections.Generic;
using System.Linq;

namespace UserManagement.Models
{
    public static class UserRepository
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
