﻿using System;
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
            
        }

        public void Edit(ISubscriptionPrice a)
        {
           
        }

        public IList<ISubscriptionPrice> GetData()
        {
            IList<ISubscriptionPrice> list =  DatabaseConnection.GetSubscribtionPrice().Select(a => new SubscriptionPrice { NumberOfHours = a.NumberOfHours, Price = a.Price }).ToList<ISubscriptionPrice>();
            return list;
        }
    }
}
