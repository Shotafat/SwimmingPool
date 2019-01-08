using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPSQLite.CLASSES
{
    public class DoctorServices : IDoctorServices
    {
        public void Add(IDoctor a)
        {
            DatabaseConnection.insertDoctor(a.Name,a.LastName);
        }

        public void Delete(IDoctor a)
        {
            throw new NotImplementedException();
        }

        public void Edit(IDoctor a)
        {
            throw new NotImplementedException();
        }

        public IList<IDoctor> GetData()
        {
           IList<IDoctor> list = DatabaseConnection.GetDoctorSource().Select(a => new Doctor { Name = a.Name, LastName = a.LastName }).ToList<IDoctor>();
            return list;
        }
    }
}
