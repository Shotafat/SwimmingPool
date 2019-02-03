using System;
using System.Collections.Generic;
using System.Text;
using SPSQLite.Enums;


namespace SPSQLite
{
   public interface ISubscriptionSchedule
    {
        int ID { get; set; }
        DateTime Schedule { get; set; }  
        int SubscribtionID { get; set; }
        AttendanceTypes Attendance { get; set; }
    }
}
