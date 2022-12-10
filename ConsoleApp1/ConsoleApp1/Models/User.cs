using ConsoleApp1.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class User
    {
        public static List<User> _allUsers = new List<User>();
        private static int _count = 0;
        public int Id { get; }
        public string Username { get; set; }

        public string Password { get; set; }
        public bool IsLogined { get; set; }

        public List<Music> Playlist { get; set; }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Id = ++_count;
            Playlist = new List<Music>();
            IsLogined = true;
        }
        public void AddMusic(Music music)
        {
            //for (int i = 0; i < Playlist.Count; i++)
            //{
            //    if (Playlist[i].Id == music.Id)
            //    {
            //        Console.WriteLine("This music already exists");
            //        return;
            //    }
            //}

            Music existed = Playlist.Find(m=>m.Id == music.Id);
            if (existed != null)
            {
                Playlist.Add(music);
                Console.WriteLine("Music Successufully added");
                return;
            }
            Console.WriteLine("This Music Successufully exists");
        }
        public static void RegisterUser()
        {
            string username;
            do
            {
                Console.WriteLine("Please enter username");
                username = Console.ReadLine().Trim().ToLower();
            } while (!username.CheckUsername());
            string password;
            do
            {
                Console.WriteLine("Please enter password");
                password = Console.ReadLine();
            } while (!password.CheckPassword());
            Console.WriteLine("Register olunub");
            
            User user= new User(username, password);
            User._allUsers.Add(user);
        
        }
        public static void LoginUser()
        {
            string username;
            User existed;
            do
            {
                Console.WriteLine("Enter your username");
                username = Console.ReadLine().Trim();
                existed = username.FindUser();
                if (existed==null)
                {
                    Console.Clear();
                    Console.WriteLine("User with this username does not exist");
                }

            } while (existed == null);
            string password;
            do
            {
                Console.WriteLine("Enter ypur password");
                password = Console.ReadLine();
                if (existed.Password!=password)
                {
                    Console.Clear();
                    Console.WriteLine("password is not correct");
                }
            } while (existed.Password != password);
            existed.IsLogined= true;
            Console.WriteLine($"{existed.Username} welcomee");
        }
    }
}
