using System;
using System.Collections.Generic;
using System.Text;
using SPSQLite.INTERFACES.Services;
using SPSQLite.CLASSES.BussinessObjects;


namespace SPSQLite.CLASSES.Services
{
    public class ServiceInstances
    {

        private static ServiceInstances ServiceObject = null;


        public static ServiceInstances Service()
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

        public ICapicityServices GetCapicityServices()
        {


            return new CapicityServices();
        }

        public ISubscriptionPrice CreateObject(int TextboxText1, double TextboxText2)

        {
            SubcsriptionPrice gela = new SubcsriptionPrice();
            gela.NumberOfHours = TextboxText1;
            gela.Price = TextboxText2;

            return gela;

        }

        public ISubscriber CreateObjectForSub(int id, string Name, string LastName, DateTime age, string Number, string adress)
        {


            Subscriber gela = new Subscriber();

            gela.ID = id;
            gela.Name = Name;
            gela.LastName = LastName;
            gela.DateOfBirth = age;
            gela.PhoneNumber = Number;
            gela.Adress = adress;
            return gela;

        }
    }
}
