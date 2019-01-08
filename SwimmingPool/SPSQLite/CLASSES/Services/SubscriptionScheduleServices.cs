using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPSQLite.CLASSES
{
    public class SubscriptionScheduleServices : ISubscriptionScheduleServices
    {
       

        public void Add(ISubscriptionSchedule a)
        {
            DatabaseConnection.InsertSubscriptionShedule(a.Schedule, a.SubscribtionID);
        }

       
        public void Delete(ISubscriptionSchedule a)
        {
           
        }

      

        public void Edit(ISubscriptionSchedule a)
        {
           
        }

      
        IList<ISubscriptionSchedule> ISubscriptionScheduleServices.GetData()
        {
         IList<ISubscriptionSchedule> list =   DatabaseConnection.GetSheduleSource().Select(a => new SubscriptionSchedule { Schedule = a.Schedule, SubscribtionID = a.SubscribtionID }).ToList<ISubscriptionSchedule>();

            return list;
        }
    }
}
