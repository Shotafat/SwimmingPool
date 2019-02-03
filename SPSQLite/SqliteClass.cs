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
using SPSQLite.INTERFACES.Interfaces;
using SQLiteNetExtensions.Extensions;


//using System.Windows.Forms;

namespace SPSQLite
{

    public static class DatabaseConnection
    {
        public static SQLiteConnection Conn { get; set; }
        public static string Path { get; set; }



        public static void CreateTables()
        {
            Conn.CreateTables<HealthNotice, Subscriber, Subscription, SubscribtionPrice>();
            Conn.CreateTables<Capacity, SubscriptionScheduleDB>();
        }

        //Abonent 

        public static void insertAbonent(ISubscriber sub)
        {
            Conn.Insert(new Subscriber { Name = sub.Name, LastName = sub.LastName, PhoneNumber = sub.PhoneNumber, Address = sub.Adress, DateOfBirth = sub.DateOfBirth });


        }

        //SQLITE EXTENSIONS - ONE TO MANY RELATIONSHIP



        public static void insertSubscribtion(ISubscriber subscriber_, ISubscriptionPrice subscriberprice, ISubscription subscription_)
        {
            var subscriberkey = Conn.Table<Subscriber>().Where(s => s.PhoneNumber == subscriber_.PhoneNumber).FirstOrDefault();

            var subscribtionPricekey = Conn.Table<SubscribtionPrice>().Where(s => s.NumberOfHours == subscriberprice.NumberOfHours).FirstOrDefault();
            var subscription = Conn.Table<Subscription>().Where(s => s.IDnumber == subscription_.IDnumber).FirstOrDefault();
            List<Subscription> NewSubscription = new List<Subscription>();

            foreach (var item in NewSubscription)
            {
                NewSubscription.Add(new Subscription()
                {
                    //ბიზნეს ლოგიკა აგენერირებს  subscription_.ID-ს ფორმატში A001 და IDNUMBER=A001-ს, SQL ID-ს ინკრემენტს იუზერი ვერ ხედავს
                    IDnumber = subscription.IDnumber,

                    Subscriber_ = subscriberkey,
                    SubscriberID = subscriberkey.Id,

                    SubscriberPrice_ = subscribtionPricekey,

                    SubscriptionTypeID = subscribtionPricekey.Id


                });

                subscriberkey.Subscriptions = NewSubscription;
                subscribtionPricekey.Subscribtions = NewSubscription;
                Conn.InsertAllWithChildren(NewSubscription, true);
            }


            foreach (var item in NewSubscription)
            {
                Conn.UpdateWithChildren(item);
            }



            //    subscriberkey.Subscriptions = NewSubscription;
            //subscribtionPricekey.Subscribtions = NewSubscription;
            //Conn.InsertAllWithChildren(NewSubscription, true)



            //subscribtionPricekey.Subscribtions = new List<Subscription>();


            /*
             public static void InsertAllWithChildren(this SQLiteConnection conn, IEnumerable elements, bool recursive = false);
        public static void InsertOrReplaceAllWithChildren(this SQLiteConnection conn, IEnumerable elements, bool recursive = false);
        public static void InsertOrReplaceWithChildren(this SQLiteConnection conn, object element, bool recursive = false);
        public static void InsertWithChildren(this SQLiteConnection conn, object element, bool recursive = false);
             * */



            //Conn.Insert(new Subscriber { Name = sub.Name, LastName = sub.LastName, PhoneNumber = sub.PhoneNumber, Address = sub.Adress, DateOfBirth = sub.DateOfBirth });


        }




        //Delete Abonent 

        public static void DeleteAbonent (ISubscriber subscriber)
        {
            Conn.Delete(Conn.Table<Subscriber>().FirstOrDefault(a => a.Id == subscriber.ID));
        }

        //Edit Abonent 

         public static void EditAbonent ( ISubscriber subscriber)
        {
            var abonent = Conn.Table<Subscriber>().Where(a => a.LastName == subscriber.LastName).SingleOrDefault();
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
            //return Conn.Table<Subscriber>().ToList();
            //Subscriber A = new Subscriber { Id = 5 };
            //Conn.GetWithChildren<Subscriber>(A.Id);


            return Conn.Table<Subscriber>().ToList();
         

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

        public static void InsertHealthNotice(DateTime DateCreated ,  int AbonentID)
        {
            Conn.Insert(new HealthNotice { AbonentId = AbonentID,  DateCreated = DateCreated });
        }

        //Delete HealthNotice

        public static void DeleteHealthNotice (IHealthNotice healthNotice)
        {
            Conn.Delete(Conn.Table<HealthNotice>().FirstOrDefault(a => a.id == healthNotice.ID));
        }

        //Edit Health Notice 

        public static void EditHealthNotice (IHealthNotice health)
        {
            var Health = Conn.Table<HealthNotice>().Where(a => a.id == health.ID).SingleOrDefault();
            if ( Health!=null)
            {
                Health.AbonentId = health.AbonentId;              
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
        //DefaulAttendance ჩავსვი (შოთა)
        public static void InsertSubscriptionShedule(DateTime shedule, int SubscriptionID, int DefaultAttendance=0) 
        {

            Conn.Insert(new SubscriptionScheduleDB { Schedule = shedule, SubscriptionID = SubscriptionID, Attandance=DefaultAttendance });

        }

        // Delete Subscription Shedule

         public static void DeleteSubscriptionShedule(ISubscriptionSchedule sub)
        {
                                                                         //აქ SubscribtionID ხომ არ უნდა IDს ნაცვლად?
            Conn.Delete(Conn.Table<SubscriptionScheduleDB>().FirstOrDefault(a => a.Id == sub.ID));

        }

      

        // Edit Subscription Schedule 

         public static void EditSubscriptionSchedule (ISubscriptionSchedule Schedule)
        {
                                                                        //ID დაემთხვევა? SubscribtionID ხომ არ ჯობს?
            var Schedules = Conn.Table<SubscriptionScheduleDB>().Where(a => a.Id == Schedule.ID).SingleOrDefault();
            if(Schedules !=null)
            {
                Schedules.Schedule = Schedule.Schedule;
                Schedules.SubscriptionID = Schedule.SubscribtionID;
                //დასწრება ჩავამატე, Enum გადადის ინტში და გადაეცემა ინტი
                Schedules.Attandance = (int)Schedule.Attendance;

                Conn.Update(Schedules);

            }

        }

        // Get Subscription Shedule Source 
        public static  List<SubscriptionScheduleDB> GetSheduleSource() 
        {

            return Conn.Table<SubscriptionScheduleDB>().ToList();
        }


        // Insert Subscription 

        public static void InsertSubscription(int SubscriberID,  int SubscriptionTypeID) 
        {

            Conn.Insert(new Subscription {  SubscriberID = SubscriberID, SubscriptionTypeID = SubscriptionTypeID });

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
                
                Subscription.SubscriberID = subscription.SubscriberID;
                Subscription.SubscriptionTypeID = subscription.SubscribtionTypeID;
                Conn.Update(Subscription);
            }
            
        }

        // Get Subscription Source

        public static List<Subscription> GetSubscriptions()  
        {


            return Conn.Table<Subscription>().ToList();
        }

      // 
      
  

    // Edit capicity
    public static void EditCapicity(ICapicity capicity)
        {
            var cap =  Conn.Table<Capacity>().Where(a => a.MaximumCapacity == capicity.CapicityValue).FirstOrDefault();
            if (cap != null)
            {
                cap.MaximumCapacity = capicity.CapicityValue;
                Conn.Update(capicity);
            }      


        }

        // Get capicity
        public static List<Capacity> GetCapicity()
        {
            return Conn.Table<Capacity>().ToList();
        }


       
    }
    
    //აბონიმენტი
    public class Subscription
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string IDnumber { get; set; }


        [ForeignKey(typeof(Subscriber))]
        public int SubscriberID { get; set; }

      
        [ForeignKey(typeof(SubscribtionPrice))]
        public int SubscriptionTypeID { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Subscriber Subscriber_ { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public SubscribtionPrice SubscriberPrice_ { get; set; }


    }

        //აუზზე ადამიანების რაოდენობა. ადმინს რომ მოუნდეს  შეცვალოს ლიმიტი უმჯობესია ბაზაში ინახებოდეს.
    public class Capacity
    {
        [PrimaryKey, AutoIncrement]
        public int MaximumCapacity { get; set; } = 28;

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
        public DateTime DateOfBirth { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Subscription> Subscriptions { get; set; }

    }
     
 
    //ჯანმრთელობის ცნობა
    public class HealthNotice
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public DateTime DateCreated { get; set; }
      
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

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Subscription> Subscribtions { get; set; }

      
    }

    //სააბონენტო განრიგი
    public class SubscriptionScheduleDB
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Schedule { get; set; }
        [ForeignKey(typeof(Subscription))]
        public int SubscriptionID { get; set; }
        public int Attandance { get; set; }


    }
  

}
