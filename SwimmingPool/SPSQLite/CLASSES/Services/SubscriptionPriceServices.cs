using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPSQLite.CLASSES
{
    public class SubscriptionPriceServices : ISubscriptionPriceServices
    {
        private static SubscriberServices Instance = null;
        public static SubscriberServices Object
        {
            get
            {
                if (Instance == null)
                    Instance = new SubscriberServices();
                return Instance;
            }
        }


        public void Add(ISubscriptionPrice a)
        {
            DatabaseConnection.insertSubscribtionPrice(a.NumberOfHours, a.Price);
        }

        public void Delete(ISubscriptionPrice a)
        {
            DatabaseConnection.DeleteSubscriptionPrice(a);
        }

        public void Edit(ISubscriptionPrice a)
        {
            DatabaseConnection.EditSubscriptionPrice(a);
        }

        public IList<ISubscriptionPrice> GetData()
        {
            IList<ISubscriptionPrice> list =  DatabaseConnection.GetSubscribtionPrice().Select(a => new SubscriptionPrice { NumberOfHours = a.NumberOfHours, Price = a.Price }).ToList<ISubscriptionPrice>();
            return list;
        }
    }
}
