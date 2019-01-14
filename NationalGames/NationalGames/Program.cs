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
         
            Console.ReadLine();
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
