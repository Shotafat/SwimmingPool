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
        public static void CreateTables()
        {

        }


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


    }

    //აბონიმენტი
    public class Subscription
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SubscribernNumber{ get; set; }
        [ForeignKey(typeof(Subscriber))]
        public int SubscriberID { get; set; }
        [ForeignKey(typeof(Coach))]
        public int CoachId { get; set; }
        [ForeignKey(typeof(SubscribtionPrice))]
        public int SubscribtionTypeID { get; set; }

    }

    public class Coach
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

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
