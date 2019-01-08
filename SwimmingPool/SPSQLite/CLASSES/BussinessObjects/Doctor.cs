using System;
using System.Collections.Generic;
using System.Text;


namespace SPSQLite.CLASSES
{
    public class Doctor : IDoctor
    {
        public int ID { get ; set; }
        public string Name { get ; set ; }
        public string LastName { get ; set; }
    }
}
