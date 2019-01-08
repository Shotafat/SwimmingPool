using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite.CLASSES
{
    public class SubscriptionPrice : ISubscriptionPrice
    {
        public int ID { get ; set ; }
        public int NumberOfHours { get ; set ; }
        public double Price { get; set; }
    }
}
