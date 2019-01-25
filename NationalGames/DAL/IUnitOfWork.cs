using System;
using System.Collections.Generic;
using System.Text;

namespace NationalGames
{
    public interface IUnitOfWork:IDisposable
    {
        void Save();
    }
}
