using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSQLite;

using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions;
using SPSQLite.CLASSES;
using SPSQLite.CLASSES.Services;
using SPSQLite.Enums;
using System.Globalization;

namespace SwimmingPool
{
    public partial class Form1 : Form
    {

      

        public Form1()
        {
         
        InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            //dataGrid_eqimi.DataSource = null;
            //dataGrid_eqimi.DataSource = ServiceInstances.Service().GetDoctorServices().GetData();
            //dataGridView5.DataSource = null;
            //dataGridView5.DataSource = ServiceInstances.Service().GetSubscriptionServices().GetData();

        }

        public void ADDABONENT(object sender, EventArgs e)
        {
           
        }

        private void წაშლაToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //for (int i = 10; i < 21; i++)
            //{
            //    ServiceInstances.Service().GetSubscriptionScheduleServices().Add(new SPSQLite.CLASSES.SubscriptionSchedule { Attendance = AttendanceTypes.Waiting, Schedule = DateTime.ParseExact("15/08/2019 15:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture), SubscribtionID = 5 + i - 1 });
            //    ServiceInstances.Service().GetSubscriptionScheduleServices().Add(new SPSQLite.CLASSES.SubscriptionSchedule { Attendance = AttendanceTypes.Waiting, Schedule = DateTime.ParseExact("15/08/2019 15:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture), SubscribtionID = 5 + i - 4 });
            //    ServiceInstances.Service().GetSubscriptionScheduleServices().Add(new SPSQLite.CLASSES.SubscriptionSchedule { Attendance = AttendanceTypes.Waiting, Schedule = DateTime.ParseExact("15/08/2019 15:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture), SubscribtionID = 5 + i - 2 });

            //    i++;
            //}

            //var a=ServiceInstances.Service().GetSubscriptionScheduleServices().GetData();
            //foreach (var item in a)
            //{
            //    MessageBox.Show(item.SubscribtionID.ToString());
            //}
          
            

            //  ServiceInstances.Service().GetSubscriptionScheduleServices().Add(gela);
           ServiceInstances.Service().GetSubscriptionScheduleServices().Distribute();
        }

       
           

    

       

        private void დამატებაToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

                AddAbonent addAbonent = new AddAbonent();
                addAbonent.ShowDialog();
            
        }

        private void საათებიდაფასებიToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form2 form = new Form2();
            form.ShowDialog();

        }
    }
}


