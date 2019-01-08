using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPSQLite.CLASSES
{
    public class SubscriptionServices : ISubscriptionServices
    {
       
        public void Add(ISubscription a)
        {
            DatabaseConnection.InsertSubscription(a.SubscriberID, a.CoachID, a.DoctorID, a.SubscribtionTypeID);
        }


        public void Delete(ISubscription a)

        {
            DatabaseConnection.DeleteSubscription(a);
        }

       
        public void Edit(ISubscription a)
        {
            DatabaseConnection.EditSubscription(a);
           
        }

      
        IList<ISubscription> ISubscriptionServices.GetData()
        {
          IList<ISubscription> list =    DatabaseConnection.GetSubscriptions().Select(a => new Subscription { CoachID = a.CoachId, DoctorID = a.DoctorID, SubscriberID = a.SubscriberID, SubscribtionTypeID = a.SubscribtionTypeID }).ToList<ISubscription>();

            return list;
        }
    }
}
