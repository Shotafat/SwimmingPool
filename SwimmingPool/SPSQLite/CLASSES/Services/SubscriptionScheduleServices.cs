using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPSQLite.CLASSES
{
    public class SubscriptionScheduleServices : ISubscriptionScheduleServices
    {
        private static SubscriptionScheduleServices Instance = null;
        public static SubscriptionScheduleServices Object
        {
            get
            {
                if (Instance == null)
                    Instance = new SubscriptionScheduleServices();
                return Instance;
            }
        }

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
           IList<ISubscriptionSchedule> list =   DatabaseConnection.GetSheduleSource().Select(a => new SubscriptionSchedule { Schedule = a.Schedule, SubscribtionID = a.SubscribtionID }).ToList<ISubscriptionSchedule>();

            return list;
        }
    }
}
