using SPSQLite.CLASSES.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite.CLASSES.BussinessObjects
{
    public static class QuantityCounter
    {
        public static int Quantity { get; set; }
        public static int QuantityIncrementer()
        {
            int i;
            //mogvaqvs subscribtion-ebis baza
            var Quantit= ServiceInstances.Service().GetSubscriptionServices().GetData();
            int count = Quantit.Count;
         
                i= count + 1;

            return i;
        }

    }
}
