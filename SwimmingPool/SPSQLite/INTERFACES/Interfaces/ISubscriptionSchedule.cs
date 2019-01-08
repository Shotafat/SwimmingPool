using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite
{
   public interface ISubscriptionSchedule
    {
        int ID { get; set; }
        DateTime Schedule { get; set; }  
        int SubscribtionID { get; set; }
    }
}
