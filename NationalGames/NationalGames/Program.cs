using System;

namespace NationalGames
{
    class Program
    {
        static void Main(string[] args)
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
            Console.ReadLine();
        }
    }
}
