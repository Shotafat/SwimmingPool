using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SPSQLite.CLASSES
{
    public class SubscriberServices : ISubscriberServices
    {        
        public void Add(ISubscriber a)
        {
            DatabaseConnection.insertAbonent(a);         
        }

        public void Delete(ISubscriber a)
        {
            DatabaseConnection.DeleteAbonent(a);
        }

        public void Edit(ISubscriber a)
        {
            DatabaseConnection.EditAbonent(a);
        }

        public IList<ISubscriber> GetData()
        {            
           List<ISubscriber> list = DatabaseConnection.GetAbonentSource().Select(o=>new Subscriber {Adress=o.Address,DateOfBirth=o.DateOfBirth,
            ID=o.Id,
            LastName=o.LastName,Name=o.Name,PhoneNumber=o.PhoneNumber}).ToList<ISubscriber>();
                
            return list;
        }
    }
}
