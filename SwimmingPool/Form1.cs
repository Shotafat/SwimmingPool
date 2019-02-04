using SPSQLite;
using SPSQLite.CLASSES;
using SPSQLite.CLASSES.Services;
using SPSQLite.Enums;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class Form1 : Form
    {



        public Form1()
        {

            InitializeComponent();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridView1.AutoGenerateColumns = true;
            JoinClasses();
            //dataGrid_eqimi.DataSource = null;
            //dataGrid_eqimi.DataSource = ServiceInstances.Service().GetDoctorServices().GetData();
            //dataGridView5.DataSource = null;
            //dataGridView5.DataSource = ServiceInstances.Service().GetSubscriptionServices().GetData();

        }

        private void დამატებაToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }
        public void JoinClasses()
        {

            //ქართული ცვლადები პროსტა სატესტოდ დავწერე რანთაიმში ენიჭება ქოლუმნებს სახელები ანონიმური ობიექტის პონტში :) :D 
            //var gela = (from g in ServiceInstances.Service().GetSubscriptionServices().GetData()
            //            join c in ServiceInstances.Service().GetSubscriberService().GetData() on g.SubscriberID equals c.ID
            //            join s in ServiceInstances.Service().GetSubscriptionPriceServices().GetData() on g.SubscribtionTypeID equals s.ID
            //            select new
            //            {
            //                ნომერი = g.IDnumber,
            //                სახელი = c.Name,
            //                გვარი = c.LastName,
            //                მობილური = c.PhoneNumber,
            //                მისამართი = c.Adress,
            //                ასაკი = DateTime.Now.Year - c.DateOfBirth.Year,
            //                საათი = s.NumberOfHours,
            //                ფასი = s.Price




            //            }).ToList();


            //var vano = (from c in ServiceInstances.Service().GetSubscriberService().GetData() select new
            //            {
            //                სახელი = c.Name,
            //                გვარი = c.LastName,
            //                მობილური = c.PhoneNumber,
            //                მისამართი = c.Adress,
            //                ასაკი = DateTime.Now.Year - c.DateOfBirth.Year,
                         





            

         var JoinedTable=DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>();

            var fillgrid = (from o in JoinedTable select new { SubscribID = o.Id, SubsIDNUM = o.IDnumber, SubscriberID = o.SubscriberID ,
                                  PRICE=o.SubscriberPrice_.Price}).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = fillgrid;
        }

   

     

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells[1].Value);
                string b = Convert.ToString(selectedRow.Cells[2].Value);
                //label1.Text = a + " " + b;
            }
        }

        private void დამატებაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAbonent addAbonent = new AddAbonent();


            addAbonent.ShowDialog();
            if (addAbonent.DialogResult == DialogResult.OK)
            {

                Form1_Load(sender, e);
            }
        }

        private void რედაქტირებაToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Selected)
            {
                var subscriptionPrice = dataGridView1.SelectedRows[0].DataBoundItem as ISubscriber;
                AddAbonent add = new AddAbonent(subscriptionPrice);

                add.ShowDialog();
                if (add.DialogResult == DialogResult.OK)
                {
                    Form1_Load(sender, e);

                }
            }
            else
            {
                MessageBox.Show("გთხოვთ მონიშნოთ აბონიმენტი!");
            }
        }

        private void საათებიდაფასებიToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            Form2 form2 = new Form2();


            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.OK)
            {

                Form1_Load(sender, e);
            }
        }

        private void წაშლაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseConnection.insertSubscribtionPrice(2, 2.5);
            DatabaseConnection.insertSubscribtionPrice(3, 40.5);
            DatabaseConnection.insertSubscribtionPrice(4, 30.5);
            DatabaseConnection.insertSubscribtionPrice(5, 20.5);
            DatabaseConnection.insertSubscribtionPrice(6, 12.5);
            DatabaseConnection.insertSubscribtionPrice(7, 9.5);
            DatabaseConnection.insertSubscribtionPrice(8, 8.5);
            DatabaseConnection.insertSubscribtionPrice(9, 7.5);
            DatabaseConnection.insertSubscribtionPrice(10, 3.5);





            CultureInfo provider = new CultureInfo("fr-FR");
            List<SubscriptionSchedule> list = new List<SubscriptionSchedule>
            {
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("02/02/2019 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=15 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("03/02/2009 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=13  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("05/02/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=12},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("06/02/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=13},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("29/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=43},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("28/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=47},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("27/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=12},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("29/01/2019 11:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=20},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("30/01/2019 11:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=21},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("30/01/2019 12:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=30 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2019 13:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=45},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2019 14:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=17  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("01/02/2019 14:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=17  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("25/01/2019 15:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=3 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("29/01/2019 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=15 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("29/01/2019 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=13  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("28/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=12},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("30/01/2019 11:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=20},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("03/02/2019 12:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=30 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("28/01/2019 13:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=45},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("28/01/2019 14:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=17  }

        };
            foreach (var item in list)
            {
                //SubscriptionSchedule : ISubscriptionSchedule
                ServiceInstances.Service().GetSubscriptionScheduleServices().Add(item);

            }

        }

        private void ვადაგასულიToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
        }
    }
}


