using System;
using System.Collections.Generic;
using System.Text;
using SPSQLite.Check;

namespace SPSQLite.CLASSES
{
    public class Subscriber : ISubscriber
    {
        public int ID { get ; set; }
        public string Name { get ; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get ; set; }
        public string Adress { get; set ; }
        public DateTime DateOfBirth { get; set; }

    }
}
