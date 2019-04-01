using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;
namespace SPSQLite
{
    public static class ConnectToDatabase
    {
        public static void ConnectAndCreateTables()
        {
            DatabaseConnection.Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SwimmingPool.db");
            DatabaseConnection.Conn = new SQLiteConnection(DatabaseConnection.Path);
            DatabaseConnection.CreateTables();


        }

    }


  

   public static class BusinesLogic
    {




    }



}
