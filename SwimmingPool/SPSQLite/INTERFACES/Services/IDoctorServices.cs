using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite
{
   public interface IDoctorServices
    {
        void Add(IDoctor a);
        void Delete(IDoctor a);
        void Edit(IDoctor a);
        IList<IDoctor> GetData();
    }
}
