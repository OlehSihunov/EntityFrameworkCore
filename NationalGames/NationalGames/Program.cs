using System;
using BLL;
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
            StartExpoBLL();
          //  StartExpoDAL();
            Console.ReadLine();
        }
        public static void StartExpoDAL()
        {
            UnitOfWork unitOne = new UnitOfWork();
            var countries = unitOne.Countries.GetItemList();
            foreach (var item in countries)
            {
                item.ShowItem();
            }
            var games = unitOne.Games.GetItemList();
            foreach (var item in games)
            {
                item.ShowItem();
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
