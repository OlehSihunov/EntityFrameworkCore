using System;
using System.Collections.Generic;
using NationalGames;
using System.Linq;
namespace BLL
{
    public class YearChecker : IYearChecker
    {
        public  Game showNewestGame()
        {
            IEnumerable<Game> games = (new UnitOfWork()).Games.GetItemList();
            Game result = games.Single(x => x.Year == games.Max(y => y.Year));
            return result;
        }

        public  Game showOldestGame()
        {
            IEnumerable<Game> games = (new UnitOfWork()).Games.GetItemList();
            Game result = games.Single(x=>x.Year== games.Min(y => y.Year));
            return result;
        }

        public  IEnumerable<Game> showYearTwoGames()
        {
            IEnumerable<Game> games = (new UnitOfWork()).Games.GetItemList();
            IEnumerable<Game> result = games.Where(x => 2019 - x.Year > 600);
            return result;
        }
    }
}
