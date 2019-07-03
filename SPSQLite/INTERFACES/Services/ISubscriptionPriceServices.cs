using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite
{
   public interface ISubscriptionPriceServices
    {
        void Add(ISubscriptionPrice a );
        void Delete(ISubscriptionPrice a );
        void Edit(ISubscriptionPrice a );
        IList<ISubscriptionPrice> GetData();
    }
}
