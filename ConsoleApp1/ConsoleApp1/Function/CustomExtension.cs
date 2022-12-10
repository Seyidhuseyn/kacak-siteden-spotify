using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Function
{
    internal static class CustomExtension
    {
        public static bool CheckUsername(this string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length<6 || username.Length>12)
            {
                Console.Clear();
                Console.WriteLine("Username has to contain at least 6 and maximum 12 characters");
                return false;
            }
            if (username[0]=='.' || username[username.Length-1]=='.')
            {
                return false;
            }
            for (int i = 0; i < username.Length; i++)
            {
                if (!char.IsLetterOrDigit(username[i]) && username[i] !='_' && username[i] !='.')
                {
                    Console.Clear();
                    Console.WriteLine("Username has to contain letters/digits/./_");
                    return false;
                }
            }
            User existed = username.FindUser();
            if (existed != null)
            {
                Console.Clear();
                Console.WriteLine("User with username is already exists");
            }
            return true;
        }
        public static bool CheckPassword(this string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6 || password.Length > 12)
            {
                return false;
            }
            bool digit = false;
            bool upper = false;
            bool lower = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    digit = true;
                }
                if (char.IsUpper(password[i]))
                {
                    upper = true;
                }
                if (char.IsLower(password[i]))
                {
                    lower = true;
                }
            }
            if (upper && lower && digit) return true;
            Console.Clear();
            Console.WriteLine("Password has to contain at least 6 and maximum 12 characters");
            return false;

        }
        public static string Capitalize(this string name)
        {
            name = name.Trim().ToLower();
            StringBuilder builder = new StringBuilder();
            builder.Append(char.ToUpper(name[0]));
            for (int i = 0; i < name.Length; i++)
            {
                builder.Append(name[0]);
            }
            return name;
        }
        public static User FindUser(this string username)
        {
            return User._allUsers.Find(u => u.Username == username);
        }
    }
}