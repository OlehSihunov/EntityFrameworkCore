using System;
using System.Collections.Generic;

namespace NationalGames
{
    public partial class Game
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }

        public virtual Country Country { get; set; }
        public override string ToString()
        {
            return $"\nID: {this.Id}\nCountryID: {this.CountryId}\nName: {this.Name}\nYear: {Year}\n ";
        }
        
    }
}
