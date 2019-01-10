using System;
using System.Collections.Generic;
using System.Text;


namespace SPSQLite.CLASSES.Services
{
   public  class ServiceInstances
    {

        private static ServiceInstances ServiceObject = null;


        public static  ServiceInstances Service ()
        {
            if (ServiceObject == null)
                ServiceObject = new ServiceInstances();
            return ServiceObject;

        }

        


        public ISubscriberServices GetSubscriberService() {

            return new SubscriberServices();
        }


        public IHealthNoticeServices GetHealthNoticeServices()
        {

            return new HealthNoticeServices();
        }

        public ISubscriptionPriceServices GetSubscriptionPriceServices()
        {

            return new SubscriptionPriceServices();
        }

        public ISubscriptionScheduleServices GetSubscriptionScheduleServices()
        {

            return new SubscriptionScheduleServices();
        }
        public ISubscriptionServices GetSubscriptionServices()
        {
            return new SubscriptionServices();
        }


    }
}
