using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace NationalGames
{
    class SQLGameRepository : IRepository<Game>
    {
        private gamesContext db;
        
        public SQLGameRepository(gamesContext context)
        {
            this.db = context;
        }

        public void Create(Game item)
        {
            db.Games.Add(item);
        }

        public void Delete(int ID)
        {
            Game game = db.Games.Find(ID);
            if (game != null)
                db.Games.Remove(game);

        }

        public Game GetItem(int ID)
        {
            return db.Games.Find(ID);
        }

        public IEnumerable<Game> GetItemList()
        {
            return db.Games;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Game game)
        {
            db.Entry(game).State = EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }



                disposedValue = true;
            }
        }


        public void Dispose()
        {

            Dispose(true);

        }
        #endregion
    }
}

