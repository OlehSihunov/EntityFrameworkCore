using System;
using System.Collections.Generic;

namespace NationalGames
{
    public partial class Country
    {
        public Country()
        {
            Games = new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        public void ShowItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nID: {this.Id}\nName: {this.Name}\n");
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
