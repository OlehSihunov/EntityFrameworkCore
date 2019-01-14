using System;
using System.Collections.Generic;

namespace NationalGames
{
    public partial class Game
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public void ShowItem()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nID: {this.Id}\nCountryID: {this.CountryId}\nName: {this.Name}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
