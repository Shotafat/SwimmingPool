using System;
using System.Collections.Generic;
using System.Text;
using SPSQLite.INTERFACES;
using System.Linq;


namespace SPSQLite.CLASSES
{
    public class CoachServices :ICoachServices
    {
        private static CoachServices Instance = null;
        public static CoachServices Object
        {
            get
            {
                if (Instance == null)
                    Instance = new CoachServices();
                return Instance;
            }
        }

        public void Add(ICoach a)
        {
            DatabaseConnection.insertCoach(a.Name, a.LastName);

        }

        

        public void Delete(ICoach a)
        {
            DatabaseConnection.DeleteCoach(a);
           
        }

       
        public void Edit(ICoach a)
        {
            DatabaseConnection.EditCoach(a);

           
        }

       
       public IList<ICoach> GetData()
        {
           IList<ICoach> list = DatabaseConnection.GetCoachesSource().Select(a => new Coach { ID=a.Id, Name=a.Name,LastName=a.LastName }).ToList<ICoach>();

            return list;
        }
    }
}
