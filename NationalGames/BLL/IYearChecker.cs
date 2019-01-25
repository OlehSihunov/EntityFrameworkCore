using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IYearChecker
    {
       IEnumerable<NationalGames.Game> showYearTwoGames();
         NationalGames.Game showOldestGame();
        NationalGames.Game showNewestGame();
        NationalGames.Game moveGame(NationalGames.Game game , int id);
    }
}
