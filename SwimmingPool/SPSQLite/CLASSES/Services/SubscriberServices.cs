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
            DatabaseConnection.insertAbonent(a.Name,a.LastName,a.PhoneNumber,a.DateOfBirth,a.Adress);
         
        }

        public void Delete(ISubscriber a)
        {
            
        }

        public void Edit(ISubscriber a)
        {
          
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
