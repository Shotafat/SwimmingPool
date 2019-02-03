using System;
using System.Collections.Generic;
using System.Text;
using SPSQLite.Check;

namespace SPSQLite.CLASSES
{
    public class Subscription : ISubscription
    {
        public int ID { get; set; }
        public string IDnumber { get; set; }
        public int SubscriberID { get ; set; }
        
        public int SubscribtionTypeID { get ; set ; }

    }
}
