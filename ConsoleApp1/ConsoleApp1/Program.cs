using ConsoleApp1.Models;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Music music = new Music("Breed", "Nirvana", 300);
            //Console.WriteLine(music.Id);

            User user = new User("seyid", "huseyn");
            //user.Playlist.Add(music);
            User.RegisterUser();
            User.LoginUser();
        }
    }
}