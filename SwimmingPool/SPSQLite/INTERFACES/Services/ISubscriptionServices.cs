using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite
{
   public interface ISubscriptionServices
    {
        void Add(ISubscription a );
        void Delete(ISubscription a);
        void Edit(ISubscription a);
        IList<ISubscription> GetData();
    }
}
