﻿using SPSQLite.CLASSES.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite.CLASSES.BussinessObjects
{
    public static class QuantityCounter
    {
        public static int Quantity { get; set; } = 1;
        public static void QuantityIncrementer()
        {
            //mogvaqvs subscribtion-ebis baza
            var Quantit= ServiceInstances.Service().GetSubscriptionServices().GetData();
            int count = Quantit.Count;


            //GetData()

            Quantity = Quantit[count - 1].ID+1;

        }

    }
}