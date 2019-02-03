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
            Quantity = Quantity++;

        }

    }
}
