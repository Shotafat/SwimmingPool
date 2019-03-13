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
using SPSQLite.CLASSES.Services;
using SPSQLite.CLASSES.BussinessObjects;
using System.Windows.Forms;


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
            Conn.CreateTables<CapacityDB, SubscriptionScheduleDB>();
        }

        //Abonent 

        public static Subscriber insertAbonent(ISubscriber sub)
        {
            Conn.Insert(new Subscriber { Name = sub.Name, LastName = sub.LastName, PhoneNumber = sub.PhoneNumber, Address = sub.Adress, DateOfBirth = sub.DateOfBirth });

            Subscriber subsc = new Subscriber { Name = sub.Name, LastName = sub.LastName, PhoneNumber = sub.PhoneNumber, Address = sub.Adress, DateOfBirth = sub.DateOfBirth };
            return subsc;
        }

        //SQLITE EXTENSIONS - ONE TO MANY RELATIONSHIP



        public static void insertSubscribtion(ISubscriber subscriber_, ISubscriptionPrice subscriberprice, ISubscription subscription_, IHealthNotice healthNotice_, List<ISubscriptionSchedule> Schedule_)
        {
            SubscribtionPrice SubPrice = new SubscribtionPrice();
            List<SubscriptionScheduleDB> ScheduleDB_ = new List<SubscriptionScheduleDB>();
            
            foreach (var item in Schedule_)
            {

                SubscriptionScheduleDB SubDB = new SubscriptionScheduleDB { Schedule = item.Schedule, Attandance = (int)item.Attendance };
                ScheduleDB_.Add(SubDB);
            }

          //  MessageBox.Show("SHCHEDULIS SIGRDZE" +ScheduleDB_.Count.ToString());
           HealthNotice healthnot = new HealthNotice { DateCreated = healthNotice_.DateCreated, YesNO = healthNotice_.YESNO };
           SubPrice = Conn.Table<SubscribtionPrice>().Where(s => s.NumberOfHours == subscriberprice.NumberOfHours).FirstOrDefault();
            Subscriber subscriber = new Subscriber
            {
                Name = subscriber_.Name,
                LastName = subscriber_.LastName,
                PhoneNumber = subscriber_.PhoneNumber,
                Address = subscriber_.Adress,
                DateOfBirth = subscriber_.DateOfBirth,
                
            };
            Subscription subscription = new Subscription { IDnumber = subscription_.IDnumber, SubscriberPrice_ = SubPrice , SubscribtionPriceID = SubPrice.Id, /*Subscriber_ = subscriberInserted */ };

            subscription.SubscribtionSchedule_ = new List<SubscriptionScheduleDB>();
           
         
            subscriber.Subscriptions = subscription;
            subscriber.SubscribtionID = subscription.Id;
            subscriber.Subscriptions = subscription;
            subscriber.Subscriptions.SubscribtionSchedule_ = ScheduleDB_;
        

            subscriber.Healthnotice =  new List<HealthNotice> {healthnot };
            healthnot.subscriber = subscriber;
            healthnot.subscriber = subscriber;
            SubPrice.Subscriptions = new List<Subscription> { subscription };

            Conn.InsertWithChildren(subscriber);

            var SubscribtionInserted = Conn.Table<Subscription>().Where(o => o.IDnumber == subscription.IDnumber).FirstOrDefault();
            foreach (var item in ScheduleDB_)
            {
                item.Subscription = SubscribtionInserted;
                item.SubscriptionID = SubscribtionInserted.Id;
                Conn.Insert(item);

            }


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

        public static void InsertHealthNotice(IHealthNotice healthNotice)
        {
            Conn.Insert(new HealthNotice { DateCreated = healthNotice.DateCreated, YesNO=healthNotice.YESNO});
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
                //Health.AbonentId = health.AbonentId;              
                Health.DateCreated = health.DateCreated;
                Health.YesNO = health.YESNO;
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

        public static Subscription InsertSubscription(ISubscription subscription) 
        {

            Conn.Insert(new Subscription {IDnumber=subscription.IDnumber });
            Subscription sub = new Subscription { IDnumber = subscription.IDnumber };
            return sub;
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
                
             //   Subscription.SubscriberID = subscription.SubscriberID;
                Subscription.IDnumber = subscription.IDnumber;
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
            var cap =  Conn.Table<CapacityDB>().Where(a => a.MaximumCapacity == capicity.CapicityValue).FirstOrDefault();
            if (cap != null)
            {
                cap.MaximumCapacity = capicity.CapicityValue;
                Conn.Update(capicity);
            }      


        }

        // Get capicity
        public static List<CapacityDB> GetCapicity()
        {
            return Conn.Table<CapacityDB>().ToList();
        }

        // insert capicity

        public static void MaximumCapicity(ICapicity capicity)
        {
            Conn.Insert(new CapacityDB { MaximumCapacity= capicity.CapicityValue });


        }

    }
    
    //აბონიმენტი
    public class Subscription
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string IDnumber { get; set; }

        [ForeignKey(typeof(SubscribtionPrice))]
        public int SubscribtionPriceID { get; set; }
     

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<SubscriptionScheduleDB> SubscribtionSchedule_ { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Subscriber Subscriber_ { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public SubscribtionPrice SubscriberPrice_ { get; set; }
        
    }
  


    //აბონენტი
    public class Subscriber
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }


        [ForeignKey(typeof(Subscription))]
        public int SubscribtionID { get; set; }


        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Subscription Subscriptions { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<HealthNotice> Healthnotice { get; set; }


    }





    //ფასი და საათი
    public class SubscribtionPrice
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int NumberOfHours { get; set; }
        public double Price { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Subscription> Subscriptions { get; set; }


    }





    //აუზზე ადამიანების რაოდენობა. ადმინს რომ მოუნდეს  შეცვალოს ლიმიტი უმჯობესია ბაზაში ინახებოდეს.
    public class CapacityDB
    {
       [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int MaximumCapacity { get; set; }

    }

    



    //ჯანმრთელობის ცნობა
    public class HealthNotice
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public DateTime DateCreated { get; set; }
      
        public Availability YesNO { get; set; }


        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Subscriber subscriber{ get; set; }

        [ForeignKey(typeof(Subscriber))]
        public int SubscriberID { get; set; }
    }



    //სააბონენტო განრიგი
    public class SubscriptionScheduleDB
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Schedule { get; set; }
        [ForeignKey(typeof(Subscription))]
        public int SubscriptionID { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Subscription Subscription { get; set; }
        public int Attandance { get; set; }

    }
  

}
