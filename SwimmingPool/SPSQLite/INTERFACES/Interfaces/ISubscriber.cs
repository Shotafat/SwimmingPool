using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite
{
    public interface ISubscriber
    {
        int ID { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Adress { get; set; }
        string DateOfBirth { get; set; }
    }
}
