using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;

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

        public void Distribute(DataGridView a)
        {
           IList<ISubscriptionSchedule> ISchedule = GetData();
            var Counter = (from x in ISchedule
                          group x by x.Schedule into g
                          let count = g.Count()
                          orderby count descending
                          select new { Date = g.Key, Datelist = g.Count(c=>c.Schedule==g.Key) }).ToList();

            //var Counter2 = (from x in ISchedule group x by x.Schedule into g select new { a=g }).ToList();
                         
            //var Count = ISchedule.Distinct();


        }

        /*
          var q = from x in list
        group x by x.Name into g
        let count = g.Count()
        orderby count descending
        select new {Name = g.Key, Count = count, ID = g.First().ID};*/



        //დასაწერია
        public void UpdateSchedule(ISubscriptionSchedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
