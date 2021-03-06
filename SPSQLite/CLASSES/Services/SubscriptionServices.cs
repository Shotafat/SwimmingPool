﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPSQLite.CLASSES
{
    public class SubscriptionServices : ISubscriptionServices
    {
        


        public void Add(ISubscription a)
        {
            DatabaseConnection.InsertSubscription(a);
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
          IList<ISubscription> list =    DatabaseConnection.GetSubscriptions().Select(a => new Subscription { /* SubscriberID = a.SubscriberID,  */ IDnumber=a.IDnumber}).ToList<ISubscription>();

            return list;
        }
    }
}
