using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NationalGames
{
    class UI
    {
        private static UnitOfWork unitOne = new UnitOfWork();
        private IEnumerable<Country> countries = unitOne.Countries.GetItemList();
        private IEnumerable<Game> games = unitOne.Games.GetItemList();
        public void StartExpoDAL()
        {
            //add switch case for UI           zZ
            

        }
        private void ShowAllGamesAndCountries()
        {
            var list = from g in games
                       join c in countries on g.CountryId equals c.Id
                       select new
                       {
                           name = g.Name,
                           country = c.Name
                       };
            foreach (var item in list)
            {
                Console.WriteLine($"{item.name} <-----> {item.country}");
            }

        }
        private Game FindGameByID(int id)
        {
            Game result = games.Single(x=>x.Id==id);
            return result;
        }
        private Country FindCountryByID(int id)
        {
            Country result = countries.Single(x => x.Id == id);
            return result;
        }
        private int getCountryIdByName(string name)
        {
            Country result = countries.Single(x => x.Name == name);
            return result.Id;
        }
        private int getGameIdByName(string name)
        {
           Game result = games.Single(x => x.Name == name);
            return result.Id;
        }
        private  IEnumerable<Game> FindGamesByCountry(string countryName)
        {
            IEnumerable<Game> result = games.Where(x => x.CountryId == getCountryIdByName(countryName));
            return result;
        }
        
        private void AddNewCountry(Country newCountry)
        {
            unitOne.Countries.Create(newCountry);
        }
        private void AddNewGame(Game newGame)
        {
            unitOne.Games.Create(newGame);
        }
        private void RemoveCountryByName(string countryName)
        {
            unitOne.Countries.Delete(getCountryIdByName(countryName));
        }
        private void RemoveCountyByID(int id)
        {
            unitOne.Countries.Delete(id);
        }
        private void RemoveGameByName(string gameName)
        {
            unitOne.Games.Delete(getGameIdByName(gameName));
        }
        private void RemoveGameByID(int id)
        {
            unitOne.Games.Delete(id);
        }
        
    }
}
