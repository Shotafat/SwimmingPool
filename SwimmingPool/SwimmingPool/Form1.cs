using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using SPSQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions;
using SPSQLite.CLASSES.BussinessObjects;
using SPSQLite.CLASSES.Services;
using SPSQLite.Enums;
using System.Globalization;
using SPSQLite.CLASSES;

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

        private void წაშლაToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CultureInfo provider = new CultureInfo("fr-FR");
            List<SubscriptionSchedule> list = new List<SubscriptionSchedule>
            {
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2019 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=15 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2009 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=13  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=12},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=13},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=43},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=47},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=12},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("24/01/2009 11:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=20},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("24/01/2009 11:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=21},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("24/01/2019 12:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=30 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2009 13:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=45},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2019 14:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=17  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2019 14:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=17  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("25/01/2009 15:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=3 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("25/01/2019 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=15 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("25/01/2009 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=13  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("25/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=12},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("25/01/2009 11:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=20},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("25/01/2019 12:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=30 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("24/01/2009 13:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=45},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("25/01/2019 14:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=17  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23 / 01 / 2019 16:00", "g", provider), SubscriptionID=4, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23 / 01 / 2009 17:00", "g", provider), SubscriptionID=5, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23 / 01 / 2019 18:00", "g", provider), SubscriptionID=4, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23 / 01 / 2009 19:00", "g", provider), SubscriptionID=5, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23 / 01 / 2019 20:00", "g", provider), SubscriptionID=4, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("24 / 01 / 2009 20:00", "g", provider), SubscriptionID=5, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("24 / 01 / 2019 14:00", "g", provider), SubscriptionID=4, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("24 / 01 / 2009 15:00", "g", provider), SubscriptionID=5, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("24 / 01 / 2019 16:00", "g", provider), SubscriptionID=4, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("25 / 01 / 2009 17:00", "g", provider), SubscriptionID=5, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("26 / 01 / 2019 18:00", "g", provider), SubscriptionID=4, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("27 / 01 / 2009 19:00", "g", provider), SubscriptionID=5, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("27 / 01 / 2019 20:00", "g", provider), SubscriptionID=4, Attandance=(int)AttendanceTypes.Attended  },
//new SubscriptionSchedule() {Schedule=DateTime.ParseExact("26 / 01 / 2009 20:00", "g", provider), SubscriptionID=5, Attandance=(int)AttendanceTypes.Attended  },

        };
            //SubscriptionSchedule a = new SubscriptionSchedule() {Schedule=DateTime.ParseExact("15 / 08 / 2000 09:00", "g", provider), SubscriptionID=4, Attandance=(int)AttendanceTypes.Attended  };





            foreach (var item in list)
            {
                //SubscriptionSchedule : ISubscriptionSchedule
                ServiceInstances.Service().GetSubscriptionScheduleServices().Add(item);

            }

//            ServiceInstances.Service().GetSubscriptionScheduleServices().Add();



        }
    }
}


