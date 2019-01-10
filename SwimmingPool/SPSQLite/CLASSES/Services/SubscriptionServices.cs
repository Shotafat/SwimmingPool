using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPSQLite.CLASSES
{
    public class SubscriptionServices : ISubscriptionServices
    {
        private static SubscriptionServices Instance = null;
        public static SubscriptionServices Object
        {
            get
            {
                if (Instance == null)
                    Instance = new SubscriptionServices();
                return Instance;
            }
        }



        public void Add(ISubscription a)
        {
            DatabaseConnection.InsertSubscription(a.SubscriberID,  a.SubscribtionTypeID);
        }


        public void Delete(ISubscription a)

        {
            DatabaseConnection.DeleteSubscription(a);
        }

       
        public void Edit(ISubscription a)
        {
            DatabaseConnection.EditSubscription(a);
           
        }

      
        public  IList<ISubscription> GetData()
        {
          IList<ISubscription> list =    DatabaseConnection.GetSubscriptions().Select(a => new Subscription { SubscriberID = a.SubscriberID, SubscribtionTypeID = a.SubscribtionTypeID }).ToList<ISubscription>();

            return list;
        }
    }
}
