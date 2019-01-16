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
        public override string ToString()
        {
            return $"\nID: {this.Id}\nName: {this.Name}\n";
        }
       
    }
}
