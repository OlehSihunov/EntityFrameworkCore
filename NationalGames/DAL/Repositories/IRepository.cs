using System;
using System.Collections.Generic;
using System.Text;

namespace NationalGames
{
    public  interface IRepository<T>:IDisposable
        where T: class
    {
        IEnumerable<T> GetItemList();
        T GetItem(int ID);
        void Create(T item);
        void Update(T item);
        void Delete(int ID);
        void Save();
    }
}
