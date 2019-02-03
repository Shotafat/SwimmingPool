using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite
{
   public interface ISubscriberServices
    {

        void Add(ISubscriber a );
        void Delete(ISubscriber a);
        void Edit(ISubscriber a );
        IList<ISubscriber> GetData();
    }
}
