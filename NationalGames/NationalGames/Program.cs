using System;
using BLL;
using System.Linq;
namespace NationalGames
{
    class Program
    {
        private  readonly IYearChecker YearCheckerOne;
        public Program(IYearChecker IYearCheckerOne)
           {
            YearCheckerOne = IYearCheckerOne;
           }
        static void Main(string[] args)
        {
           // StartExpoBLL();
           StartExpoDAL();
            Console.ReadLine();
        }
        public static void StartExpoDAL()
        { 
            UnitOfWork unitOne = new UnitOfWork();
            var countries = unitOne.Countries.GetItemList();
            var games = unitOne.Games.GetItemList();
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
        public static  void StartExpoBLL()

        {
            YearChecker YearCheckerTwo = new YearChecker();
            YearCheckerTwo.showNewestGame().ShowItem();
            YearCheckerTwo.showOldestGame().ShowItem();
            foreach (var item in YearCheckerTwo.showYearTwoGames())
                item.ShowItem();
        }
    }
}
