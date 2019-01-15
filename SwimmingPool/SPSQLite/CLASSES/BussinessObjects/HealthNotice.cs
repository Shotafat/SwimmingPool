using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite.CLASSES
{
    public class HealthNotice : IHealthNotice
    {
        public int ID { get; set ; }
        public DateTime DateCreated { get ; set ; }
       
        public int AbonentId { get ; set ; }
    }
}
