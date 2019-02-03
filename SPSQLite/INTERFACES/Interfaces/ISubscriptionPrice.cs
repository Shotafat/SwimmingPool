using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite
{
  public interface ISubscriptionPrice
    {
        int ID { get; set; }
        int NumberOfHours { get; set; }
        double Price { get; set; }
    }
}
