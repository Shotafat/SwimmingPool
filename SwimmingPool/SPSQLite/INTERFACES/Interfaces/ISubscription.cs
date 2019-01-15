using System;
using System.Collections.Generic;
using System.Text;
using SPSQLite.Check;

namespace SPSQLite
{
   public interface ISubscription
    {
        int ID { get; set; }
        int SubscriberID { get; set; }
       
        int SubscribtionTypeID { get; set; }
 

    }
}
