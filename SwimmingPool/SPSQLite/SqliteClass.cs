using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions;
using System.Reflection;


//using System.Windows.Forms;

namespace SPSQLite
{
    
    public static class DatabaseConnection
    {
        public static SQLiteConnection Conn { get; set; }
        public static string Path { get; set; }

        public static int i { get; set; } = 1;


        public static void CreateTables()
        {
            Conn.CreateTables<HealthNotice, Subscriber, Subscription, Coach>();
            Conn.CreateTables<SubscribtionPrice,  Doctor>();
            
        }

        //Abonent 
       
        public static void insertAbonent(string name , string lastname , string phonenumber, string adress , string dateofbirth)
        {
            Conn.Insert(new Subscriber { Name = name, LastName = lastname, PhoneNumber = phonenumber, Address = adress, DateOfBirth = dateofbirth });
           
            
        }

        //Delete Abonent 

        public static void DeleteAbonent (ISubscriber subscriber)
        {
            Conn.Delete(Conn.Table<Subscriber>().FirstOrDefault(a => a.Id == subscriber.ID));
        }

        //Edit Abonent 

         public static void EditAbonent ( ISubscriber subscriber)
        {
            var abonent = Conn.Table<Subscriber>().Where(a => a.Id == subscriber.ID).SingleOrDefault();
            if ( abonent!=null)
            {
                abonent.Name = subscriber.Name;
                abonent.LastName = subscriber.LastName;
                abonent.PhoneNumber = subscriber.PhoneNumber;
                abonent.DateOfBirth = subscriber.DateOfBirth;
                abonent.Address = subscriber.Adress;

                Conn.Update(abonent);
            }
        }

        // get Abonents source
        
        public  static List<Subscriber> GetAbonentSource()
        {
            return Conn.Table<Subscriber>().ToList();
        }

        //insert coach 

        public static void insertCoach(  string name, string lastname)
        {

            Conn.Insert(new Coach {  Name = name, LastName = lastname });
            
        }

        

       

        //insert Subscription Price

        public static void insertSubscribtionPrice(int saaTebisraodenoa, double fasi)
        {
            Conn.Insert(new SubscribtionPrice { NumberOfHours=saaTebisraodenoa, Price=fasi  });
    
        }

        // Delete subscription Price 

        public static void DeleteSubscriptionPrice ( ISubscriptionPrice sub )
        {
            Conn.Delete(Conn.Table<SubscribtionPrice>().FirstOrDefault(a => a.Id == sub.ID));

        }

        // Edit Subscription Price 

         public static void EditSubscriptionPrice ( ISubscriptionPrice price )
            {

            var SubPrice = Conn.Table<SubscribtionPrice>().Where(a => a.Id == price.ID).SingleOrDefault();

            if ( SubPrice!=null)
            {

                SubPrice.NumberOfHours = price.NumberOfHours;
                SubPrice.Price = price.Price;

                Conn.Update(SubPrice);
            }

           }

        //Get subscription Price Source

        public static List<SubscribtionPrice> GetSubscribtionPrice()
        {
            return Conn.Table<SubscribtionPrice>().ToList();
        }

        //insert HealthNotice

        public static void InsertHealthNotice(DateTime DateCreated , string CurrencyName , int AbonentID)
        {
            Conn.Insert(new HealthNotice { AbonentId = AbonentID, CurrencyName = CurrencyName, DateCreated = DateCreated });
        }

        //Delete HealthNotice

        public static void DeleteHealthNotice ( IHealthNotice healthNotice)
        {
            Conn.Delete(Conn.Table<HealthNotice>().FirstOrDefault(a => a.id == healthNotice.ID));
        }

        //Edit Health Notice 

        public static void EditHealthNotice ( IHealthNotice health)
        {
            var Health = Conn.Table<HealthNotice>().Where(a => a.id == health.ID).SingleOrDefault();
            if ( Health!=null)
            {
                Health.AbonentId = health.AbonentId;
                Health.CurrencyName = health.CurrencyName;
                Health.DateCreated = health.DateCreated;
                Conn.Update(Health);
            }
        }

        // get Health Notice Source 

        public static List<HealthNotice> GetHealthNotice()
        {
            return Conn.Table<HealthNotice>().ToList();
        }
  

        // Insert Subscription Shedule

        public static void InsertSubscriptionShedule(DateTime shedule, int SubscriptionID) 
        {

            Conn.Insert(new SubscriptionSchedule { Schedule = shedule, SubscribtionID = SubscriptionID });

        }

        // Delete Subscription Shedule

         public static void DeleteSubscriptionShedule(ISubscriptionSchedule sub)
        {
            Conn.Delete(Conn.Table<SubscriptionSchedule>().FirstOrDefault(a => a.Id == sub.ID));

        }

        // Edit Subscription Schedule 

         public static void EditSubscriptionSchedule (ISubscriptionSchedule Schedule)
        {
            var Schedules = Conn.Table<SubscriptionSchedule>().Where(a => a.Id == Schedule.ID).SingleOrDefault();
            if(Schedules !=null)
            {
                Schedules.Schedule = Schedule.Schedule;
                Schedules.SubscribtionID = Schedule.SubscribtionID;
                Conn.Update(Schedules);

            }

        }

        // Get Subscription Shedule Source 
        public static  List<SubscriptionSchedule> GetSheduleSource() 
        {

            return Conn.Table<SubscriptionSchedule>().ToList();
        }


        // Insert Subscription 

        public static void InsertSubscription(int SubscriberID, int CoachID, int DoctorID, int SubscriptionTypeID) 
        {

            Conn.Insert(new Subscription { CoachId = CoachID, SubscriberID = SubscriberID, DoctorID = DoctorID, SubscribtionTypeID = SubscriptionTypeID });

        }

        // Delete Subscription 

        public static void DeleteSubscription(ISubscription sub )
        {

            Conn.Delete(Conn.Table<Subscription>().FirstOrDefault(a => a.Id == sub.ID));
        }

        // Edit Subscription 

        public static void EditSubscription( ISubscription subscription)
        {
            var Subscription = Conn.Table<Subscription>().Where(a => a.Id == subscription.ID).SingleOrDefault();
            if (Subscription!=null)
            {
                Subscription.DoctorID = subscription.DoctorID;
                Subscription.CoachId = subscription.CoachID;
                Subscription.SubscriberID = subscription.SubscriberID;
                Subscription.SubscribtionTypeID = subscription.SubscribtionTypeID;
                Conn.Update(Subscription);
            }
            
        }

        // Get Subscription Source

        public static List<Subscription> GetSubscriptions()  
        {


            return Conn.Table<Subscription>().ToList();
        }

       
    }
    
    //აბონიმენტი
    public class Subscription
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //[ForeignKey(typeof(Subscriber))]
        public int SubscriberID { get; set; }

        //[ForeignKey(typeof(Coach))]
        public int CoachId { get; set; }

        public int DoctorID { get; set; }
        //[ForeignKey(typeof(SubscribtionPrice))]
        public int SubscribtionTypeID { get; set; }

    }

    //აბონენტი
    public class Subscriber
    {
        [PrimaryKey, AutoIncrement]
        public  int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }


    }
     
    //მწვრთნელი
    public class Coach
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    //ექიმი
    public class Doctor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    //ჯანმრთელობის ცნობა
    public class HealthNotice
    {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public DateTime DateCreated { get; set; }
        public string CurrencyName { get; set; }
        [ForeignKey(typeof(Subscriber))]   //ForeignKey_ს დამატება SqliteExtensions nuget-ით
        public int AbonentId { get; set; }

    }

    //ფასი და საათი
    public class SubscribtionPrice
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int NumberOfHours { get; set; }
        public double Price { get; set; }
    }

    public class SubscriptionSchedule
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Schedule { get; set; }
        [ForeignKey(typeof(Subscription))]
        public int SubscribtionID { get; set; }


    }

}
