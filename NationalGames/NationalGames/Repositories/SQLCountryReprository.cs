using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
namespace NationalGames
{
    class SQLCountryReprository : IRepository<Country>

    {
        private gamesContext db;
        public SQLCountryReprository(gamesContext context)
        {
            this.db = context;
        }
       
        public IEnumerable<Country> GetItemList()
        {
            return db.Countries;
        }

        public Country GetItem(int ID)
        {
           return  db.Countries.Find(ID);
        }

        public void Create(Country country)
        {
            db.Countries.Add(country);
        }

        public void Update(Country country)
        {
            db.Entry(country).State = EntityState.Modified;
        }

        public void Delete(int ID)
        {
            Country country = db.Countries.Find(ID);
            if (country != null)
                db.Countries.Remove(country);
        }

        public void Save()
        {
           db.SaveChanges();
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
