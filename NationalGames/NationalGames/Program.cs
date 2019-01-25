using System;
using BLL;
using System.Linq;
namespace NationalGames
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            UI ui = new UI(new YearChecker());
            ui.StartExpoDAL();
            ui.StartExpoBLL();
            while (true)
            {
                ui.StartExpoDAL();
            };
        }

    }
}
