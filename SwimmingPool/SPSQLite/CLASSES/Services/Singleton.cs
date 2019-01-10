using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite.CLASSES.Services
{
   public  class ServiceInstances
    {



        public ISubscriberServices GetSubscriberService() {

            return new SubscriberServices();
        }



    }
}
