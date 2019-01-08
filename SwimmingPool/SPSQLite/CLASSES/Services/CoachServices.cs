using System;
using System.Collections.Generic;
using System.Text;
using SPSQLite.INTERFACES;
using System.Linq;

namespace SPSQLite.CLASSES
{
    public class CoachServices : ICoachServices
    {
       
        public void Add(ICoach a)
        {
            DatabaseConnection.insertCoach(a.Name, a.LastName);

        }

        

        public void Delete(ICoach a)
        {
           
        }

       
        public void Edit(ICoach a)
        {
           
        }

       
        IList<ICoach> ICoachServices.GetData()
        {
           IList<ICoach> list = DatabaseConnection.GetCoachesSource().Select(a => new Coach {Name=a.Name,LastName=a.LastName }).ToList<ICoach>();

            return list;
        }
    }
}
