using System;
using System.Collections.Generic;
using System.Text;

using SPSQLite.INTERFACES.Interfaces;

namespace SPSQLite.INTERFACES.Services
{
  public  interface ICapicityServices
    {
        void Edit(ICapicity a);
        IList<ICapicity> GetData();

    }
}
