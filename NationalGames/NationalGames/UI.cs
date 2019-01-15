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
            Console.WriteLine("Hello user press:");
            Console.WriteLine("1. To get list of games;");
            Console.WriteLine("2. To find Game by name;");
            Console.WriteLine("3. To find game by ID;");
            Console.WriteLine("4. To get all games from selected country;");
            Console.WriteLine("5. To Find country by id;");
            Console.WriteLine("6. Add new Game;");
            Console.WriteLine("7. Add new Country");
            Console.WriteLine("8. Remove Game;");
            Console.WriteLine("9. Delete Country and games;");
            Console.WriteLine("10. To exit;");
            Console.WriteLine("11. Get List of Countries");
            int menuArg;
            do
            {
                menuArg = Convert.ToInt32(Console.ReadLine());
            } while (!(menuArg > 0 && menuArg < 12));
            menu(menuArg);
            unitOne.Save();

        }
        private void menu(int menuArg)
        {
            switch (menuArg)
            {
                case 1:
                    ShowAllGamesAndCountries();
                    break;
                case 2:
                    string gameName;
                    Console.Write("Enter name of game: ");
                    gameName = Console.ReadLine();
                    FindGameByID(getGameIdByName(gameName)).ShowItem();
                    break;
                case 3:
                    int gameID;
                    Console.Write("Enter game id: ");
                    gameID =Convert.ToInt32(Console.ReadLine());
                    FindGameByID(gameID).ShowItem();
                    break;
                case 4:
                    ShowListOfCountries();
                    int countryID;
                    Console.WriteLine("Enter id of country: ");
                    countryID = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in FindGamesByCountry(countryID))
                    {
                        item.ShowItem();
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter countty id: ");
                    countryID = Convert.ToInt32(Console.ReadLine());
                    FindCountryByID(countryID).ShowItem();
                    break;
                case 6:
                    Console.WriteLine("Enter game name: ");
                    gameName = Console.ReadLine();
                    Console.WriteLine("Enter game id: ");
                    gameID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter countryID: ");
                    countryID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter year: ");
                    int? year = Convert.ToInt16(Console.ReadLine());
                    AddNewGame(new Game
                    {
                        Name = gameName,
                        Id = gameID,
                        CountryId = countryID,
                        Year = year
                    });
                    break;
                case 7:
                    Console.WriteLine("Enter country name: ");
                    string countryName = Console.ReadLine();
                    Console.WriteLine("Enter country ID: ");
                    countryID = Convert.ToInt32(Console.ReadLine());
                    AddNewCountry(new Country
                    {
                        Id = countryID,
                        Name = countryName
                    });
                    break;
                case 8:
                    ShowListOfGames();
                    Console.Write("Enter game id: ");
                    gameID = Convert.ToInt32(Console.ReadLine());
                    RemoveGameByID(gameID);
                    break;
                case 9:
                    ShowListOfCountries();
                    Console.WriteLine("Enter id of country: ");
                    countryID = Convert.ToInt32(Console.ReadLine());
                    RemoveCountyByID(countryID);
                    break;
                case 10:
                    Environment.Exit(0);
                    break;
                case 11:
                    ShowListOfCountries();
                    break;
                default:
                    break;
            }
        }
        private void ShowListOfCountries()
        {
            foreach (var item in countries)
            {
                item.ShowItem();
            }
        }
        private void ShowListOfGames()
        {
            foreach (var item in games)
            {
                item.ShowItem();
            }
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
        private  IEnumerable<Game> FindGamesByCountry(int countryID)
        {
            IEnumerable<Game> result = games.Where(x => x.CountryId == countryID);
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
