using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite.INTERFACES
{
  public  interface ICoach
    {
        int ID { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
    }
}
