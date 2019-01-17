using System;
using System.Collections.Generic;
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
            IList<ISubscriptionSchedule> list = DatabaseConnection.GetSheduleSource().Select(a => new SubscriptionSchedule { Schedule = a.Schedule, SubscribtionID = a.SubscriptionID }).ToList<ISubscriptionSchedule>();

            return list;
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

        public void Distribute()
        {
            List<ISubscriptionSchedule> ISchedule = GetData().ToList();
            var Counter = (from x in ISchedule
                           group x by x.Schedule into g
                          
                           select new { Date = g.Key, Datelist = g.Count(c => c.Schedule == g.Key) }).ToList();


            Counter= Counter.OrderByDescending(o => o.Date).ToList();
            Form A = new Form();









            foreach (var item in Counter)
                    A.Controls.Add(new TextBox { Text = item.Date.ToString() + "DAEMATA  " + item.Datelist.ToString() });

            A.Controls.Add(new Label { Text = "ROGOR XAR"});


            A.Show();



         


            
        }
    }
}
