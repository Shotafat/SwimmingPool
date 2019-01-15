using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPSQLite.CLASSES
{
    public class SubscriptionPriceServices : ISubscriptionPriceServices
    {


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
            IList<ISubscriptionPrice> list =  DatabaseConnection.GetSubscribtionPrice().Select(a => new SubcsriptionPrice { ID=a.Id, NumberOfHours = a.NumberOfHours, Price = a.Price }).ToList<ISubscriptionPrice>();
            return list;
        }
    }
}
