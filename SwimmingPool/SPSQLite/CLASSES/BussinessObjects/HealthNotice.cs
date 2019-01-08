using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite.CLASSES
{
    public class HealthNotice : IHealthNotice
    {
        public int ID { get; set ; }
        public string DateCreated { get ; set ; }
        public string CurrencyName { get ; set ; }
        public int AbonentId { get ; set ; }
    }
}
