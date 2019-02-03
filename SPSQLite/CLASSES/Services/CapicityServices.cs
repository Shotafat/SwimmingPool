using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPSQLite.INTERFACES.Interfaces;
using SPSQLite.INTERFACES.Services;
using SPSQLite.CLASSES.BussinessObjects;

namespace SPSQLite.CLASSES.Services
{
    public class CapicityServices : ICapicityServices
    {
      

        public void Edit(ICapicity a)
        {
            DatabaseConnection.EditCapicity(a);
        }

        public  IList<ICapicity> GetData()
        {
            IList < ICapicity > list = DatabaseConnection.GetCapicity().Select(a =>new Capicity {CapicityValue = a.MaximumCapacity }).ToList<ICapicity>();

            return list;
        }
    }
}
