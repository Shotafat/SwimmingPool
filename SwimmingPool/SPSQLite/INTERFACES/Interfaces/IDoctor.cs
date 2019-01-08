using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite
{
   public interface IDoctor
    {
        int ID { get; set; }
        string Name { get; set; }
        string LastName { get; set; }

    }
}
