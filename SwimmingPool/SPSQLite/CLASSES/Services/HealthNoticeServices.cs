using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPSQLite.CLASSES
{
    public class HealthNoticeServices : IHealthNoticeServices
    {

        private static SubscriberServices Instance = null;
        public static SubscriberServices Object
        {
            get
            {
                if (Instance == null)
                    Instance = new SubscriberServices();
                return Instance;
            }
        }



        public void Add(IHealthNotice a)
        {
            DatabaseConnection.InsertHealthNotice(a.DateCreated, a.CurrencyName, a.AbonentId);
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
          IList<IHealthNotice> list =  DatabaseConnection.GetHealthNotice().Select(a => new HealthNotice { AbonentId = a.AbonentId, CurrencyName = a.CurrencyName, DateCreated = a.DateCreated }).ToList<IHealthNotice>();

            return list;
        }
    }
}
