using SPSQLite.INTERFACES;
using System;
using System.Collections.Generic;
using System.Text;


namespace SPSQLite.CLASSES
{
    public class Coach : ICoach
    {
        public int ID { get ; set ; }
        public string Name { get ; set ; }
        public string LastName { get ; set ; }


    }
}
