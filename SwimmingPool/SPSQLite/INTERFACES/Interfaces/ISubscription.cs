using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite
{
   public interface ISubscription
    {
        int ID { get; set; }
        int SubscriberID { get; set; }
        int DoctorID { get; set; }
        int SubscribtionTypeID { get; set; }
    }
}
