using System;
using System.Collections.Generic;
using System.Text;

namespace NationalGames
{
     public class UnitOfWork:IDisposable
    {
        private gamesContext db = new gamesContext();
        private SQLCountryReprository countryReprository;
        private SQLGameRepository gameRepository;
        public SQLGameRepository Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new SQLGameRepository(db);
                return gameRepository;
            }
        }
        public SQLCountryReprository Countries
        {
            get
            {
                if (countryReprository == null)
                    countryReprository = new SQLCountryReprository(db);
                return countryReprository;
            }
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        public void Save()
        {
            db.SaveChanges();

        }
    }
}
