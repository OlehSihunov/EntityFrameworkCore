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
            
            UI ui = new UI();
            ui.StartExpoDAL();
            /* while (true)
             {
             ui.StartExpoDAL();
             };*/
            StartExpoBLL();
          
            ui.StartExpoDAL();
            Console.ReadLine();
        }

        public static  void StartExpoBLL()

        {
            IYearChecker YearCheckerTwo = new YearChecker();
            Console.WriteLine(YearCheckerTwo.showNewestGame().ToString());
            Console.WriteLine(YearCheckerTwo.showOldestGame().ToString());
           
            foreach (var item in YearCheckerTwo.mixCountries())
                Console.WriteLine(item.ToString());
            foreach (var item in YearCheckerTwo.showYearTwoGames())
              Console.WriteLine(item.ToString());
        }
    }
}
