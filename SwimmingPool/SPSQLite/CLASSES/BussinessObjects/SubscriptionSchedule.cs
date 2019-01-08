using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite.CLASSES
{
    public class SubscriptionSchedule : ISubscriptionSchedule
    {
        public int ID { get ; set ; }
        public DateTime Schedule { get ; set ; }
        public int SubscribtionID { get ; set ; }
    }
}
