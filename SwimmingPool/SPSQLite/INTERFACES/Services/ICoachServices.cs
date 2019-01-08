using SPSQLite.INTERFACES;
using System;
using System.Collections.Generic;
using System.Text;


namespace SPSQLite
{
   public interface ICoachServices
    {
        void Add(ICoach a);
        void Delete(ICoach a );
        void Edit(ICoach a );
        IList<ICoach> GetData();
    }
}
