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
            DatabaseConnection.DeleteSubscriptionShedule(a);
        }

      

        public void Edit(ISubscriptionSchedule a)
        {
            DatabaseConnection.EditSubscriptionSchedule(a);
        }

      
         public IList<ISubscriptionSchedule> GetData()
        {
           IList<ISubscriptionSchedule> list =   DatabaseConnection.GetSheduleSource().Select(a => new SubscriptionSchedule { Schedule = a.Schedule, SubscribtionID = a.SubscriptionID }).ToList<ISubscriptionSchedule>();

            return list;
        }

        //დასაწერია
        public void UpdateSchedule(ISubscriptionSchedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
