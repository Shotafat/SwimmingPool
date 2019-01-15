using System;
using System.Collections.Generic;
using System.Text;
using SPSQLite.Enums;

namespace SPSQLite.CLASSES
{
    public class SubscriptionSchedule : ISubscriptionSchedule
    {
        public int ID { get ; set ; }
        public DateTime Schedule { get ; set ; }
        public int SubscribtionID { get ; set ; }
        public AttendanceTypes Attendance { get; set; }
    }
}
