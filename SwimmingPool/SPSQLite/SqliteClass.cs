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


//using System.Windows.Forms;

namespace SPSQLite
{
    
    public static class DatabaseConnection
    {
        public static SQLiteConnection Conn { get; set; }
        public static string Path { get; set; }


        public static int Subscriberindex { get; set; }
        public static int Coachindex { get; set; }
        public static int Doctorindex { get; set; }


        public static void CreateTables()
        {
            Conn.CreateTables<HealthNotice, Subscriber, Subscription, Coach>();
            Conn.CreateTables<SubscribtionPrice,  Doctor>();
            
        }

        //Abonent 
        private static bool isCreated = false;

        public static void insertAbonent(string name , string lastname , string phonenumber, string adress , string dateofbirth)
        {
            Conn.Insert(new Subscriber { Name = name, LastName = lastname, PhoneNumber = phonenumber, Address = adress, DateOfBirth = dateofbirth });
            var Subscriberindex = Conn.Table<Subscriber>().ToList().FindLastIndex(u=>u.Name==name);
            
        }
        public  static List<Subscriber> GetAbonentSource()
        {
            return Conn.Table<Subscriber>().ToList().Sort();
        }
        //coach 
        public static void insertCoach(  string name, string lastname)
        {

            Conn.Insert(new Coach {  Name = name, LastName = lastname });
            var Coachindex = Conn.Table<Subscriber>().ToList().FindLastIndex(u => u.Name == name);
        }
        public static List<Coach> GetCoachesSource()
        {
            return Conn.Table<Coach>().ToList();
        }

        //doctor

        public static void insertDoctor ( string name , string lastname )
        {
            Conn.Insert(new Doctor {Name = name, LastName = lastname });
            var Doctorindex = Conn.Table<Subscriber>().ToList().FindLastIndex(u => u.Name == name);
        }
        public static List<Doctor> GetDoctorSource ( )
        {
            return Conn.Table<Doctor>().ToList();
        }

        public static void index()
        {
            Conn.Insert(new Subscription { SubscriberID = Subscriberindex, CoachId = Coachindex, DoctorID = Doctorindex });
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

    //public class SubscriptionSchedule
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int Id { get; set; }
    //    public DateTime Schedule { get; set; }
    //    [ForeignKey(typeof(Subscription))]
    //    public int SubscribtionID { get; set; }


    //}

}
