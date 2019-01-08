using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite
{
   public interface IHealthNoticeServices
    {
        void Add(IHealthNotice a);
        void Delete(IHealthNotice a );
        void Edit(IHealthNotice a );
        IList<IHealthNotice> GetData();
    }
}
