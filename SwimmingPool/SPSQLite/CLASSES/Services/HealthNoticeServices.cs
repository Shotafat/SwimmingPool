using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPSQLite.CLASSES
{
    public class HealthNoticeServices : IHealthNoticeServices
    {

        


        public void Add(IHealthNotice a)
        {
            DatabaseConnection.InsertHealthNotice(a.DateCreated,  a.AbonentId);
        }

        public void Delete(IHealthNotice a)
        {
            DatabaseConnection.DeleteHealthNotice(a);
        }

        public void Edit(IHealthNotice a)
        {
            DatabaseConnection.EditHealthNotice(a);
        }

        public IList<IHealthNotice> GetData()
        {
          IList<IHealthNotice> list =  DatabaseConnection.GetHealthNotice().Select(a => new HealthNotice { AbonentId = a.AbonentId, DateCreated = a.DateCreated }).ToList<IHealthNotice>();

            return list;
        }
    }
}
