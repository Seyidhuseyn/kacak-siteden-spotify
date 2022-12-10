using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class Music
    {
        private static int _count = 0;
        public static List<Music> _allMusics = new List<Music>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artistname { get; set; }
        public int Second { get; set; }

        public Music(string name, string artistname, int second)
        {
            Name= name;
            Artistname= artistname;
            Second = second;
            Id= ++_count;
        }
    }
}
