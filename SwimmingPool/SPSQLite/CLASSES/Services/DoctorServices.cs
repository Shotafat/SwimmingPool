using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPSQLite.CLASSES
{
    public class DoctorServices : IDoctorServices
    {
        //private static SubscriberServices Instance = null;
        //public static SubscriberServices Object
        //{
        //    get
        //    {
        //        if (Instance == null)
        //            Instance = new SubscriberServices();
        //        return Instance;
        //    }
        //}

        public void Add(IDoctor a)
        {
            DatabaseConnection.insertDoctor(a.Name,a.LastName);
        }

        public void Delete(IDoctor a)
        {
            DatabaseConnection.DeleteDoctor(a);
        }

        public void Edit(IDoctor a)
        {
            DatabaseConnection.EditDoctor(a);
        }

        public IList<IDoctor> GetData()
        {
           IList<IDoctor> list = DatabaseConnection.GetDoctorSource().Select(a => new Doctor {ID =a.Id, Name = a.Name, LastName = a.LastName }).ToList<IDoctor>();
            return list;
        }
    }
}
