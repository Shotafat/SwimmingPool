using SPSQLite;
using SPSQLite.Enums;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
//using Excel=Microsoft.Office.Interop.Excel;
using System.IO;
namespace SwimmingPool
{
    public partial class Form1 : Form
    {

        public List<SubscriptionScheduleDB> DBDB { get; set; }
        public static string selectedAbonentNumber { get; set; }

        public List<FillGrid> fillgrid { get; set; }

        public   List<FillGrid>  newfillgrid { get; set; }
        public Form1()
        {
            InitializeComponent();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));
           dataGridView1.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // dataGridView1.AutoGenerateColumns = true;
            initData();
        }

        private void initData()
        {
            JoinClasses();
            label3.Text = "";
            if (dataGridView1.SelectedCells.Count <= 0)
                return;
            else
                selectedAbonentNumber = dataGridView1.SelectedCells[0].Value.ToString();
            InIt(selectedAbonentNumber);
        }

        private void დამატებაToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private List<FillGrid> MyFillGrid;

        public void JoinClasses()
        {
            DBDB = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.SubscriptionScheduleDB>();
            var subscriber = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscriber>();
            var scheduledb = (from o in DBDB select new { ID = o.Id, Sub = o.Subscription.IDnumber }).ToList();
            var SubscribtionTable = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>();
            var subfromsubscribtion = (from o in SubscribtionTable select new { ID = o.Id, subscriberName = o.Subscriber_.Id, PriceTyme = o.SubscriberPrice_.Id }).ToList();
            var subTa = (from o in SubscribtionTable select new { IDDD = o.IDnumber, Name = o.Subscriber_.LastName, nn = o.Subscriber_.Healthnotice }).ToList();
            var HealthTable = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.HealthNotice>();

            //MessageBox.Show("BAZIS METHODIS BOLOS" + scheduledb.Count().ToString());


             fillgrid = (from o in SubscribtionTable
                            join a in HealthTable on o.Subscriber_.Id equals a.SubscriberID
                            select new FillGrid
                            {
                                AbonentId = o.IDnumber,
                                FirstName = o.Subscriber_.Name,
                                LastName = o.Subscriber_.LastName,
                                Age = Convert.ToInt32(Math.Round((DateTime.Now - o.Subscriber_.DateOfBirth).TotalDays / 365, 0)),
                                Address = o.Subscriber_.Address,
                                PhoneNumber = o.Subscriber_.PhoneNumber,
                                HasInqury = a.YesNO,
                                DateFrom = o?.SubscribtionSchedule_.OrderBy(x => x?.Schedule.Date).FirstOrDefault()?.Schedule.Date,
                                DateTo = o?.SubscribtionSchedule_.OrderByDescending(x => x?.Schedule.Date).FirstOrDefault()?.Schedule.Date,
                                Price = o.SubscriberPrice_.Price,
                                Hours = o.SubscriberPrice_.NumberOfHours
                            })?.ToList();

            var mm = fillgrid.OrderBy(o => o.DateTo < DateTime.Now).ToList();

            dataGridView1.DataSource = mm;

            MyFillGrid = fillgrid;

            vadagasulidatagridi();
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if (Convert.ToDateTime(dataGridView1.Rows[i].Cells[8].Value) < DateTime.Now)
            //        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;               

            //}

        }


        public void vadagasulidatagridi()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToDateTime(dataGridView1.Rows[i].Cells[8].Value) < DateTime.Now)
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;

            }
        }

        public void SearchGrid(List<object> GridData)
        {
         //   var a= 

        }


        private string monthName;
        private string WeekDay;
        private int DayNumber;
        public void GeoCulture()
        {
        }

        public static List<DateTime> FullDatetime { get; set; }

        public void EditFillGrid (AddAbonent abonent, List<DateTime> DateList)
            {
            abonent.DrawGrid(abonent.CurrentWeekDays);

            //foreach (var item in DateList)
            //{
               
            //    //int rowindex = item.Hour - 8;
            //    //int columnindex = (int)item.DayOfWeek;
            //    ////   GridFormat AA = new GridFormat(1) { Day = item, X = rowindex, Y = columnindex, IsChecked = true };
            //    //// abonent.CheckedDayList.Add(AA);
            //    ////abonent.dataGridView1.Rows[rowindex].Cells[columnindex].Selected = true;

            //    ////abonent.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            //    //var Date = abonent.CurrentWeekDays[0 + columnindex - 1];

            //    //abonent.Checking(f);





            //    ////              MessageBox.Show(DataGrid.Rows[rowindex].Cells[columnindex].Selected.ToString());
            //    //abonent.dataGridView1.Rows[rowindex].Cells[columnindex].Style.BackColor = Color.DarkSlateGray;
            //}

        }

        public void InIt(string AbonentID)
        {
            flowLayoutPanel1.Controls.Clear();
            Refresh();
            selectedAbonentNumber = AbonentID;

            label3.Text = "";
            var firstName = MyFillGrid.Where(i => i.AbonentId == selectedAbonentNumber).FirstOrDefault().FirstName;
            var lastName = MyFillGrid.Where(i => i.AbonentId == selectedAbonentNumber).FirstOrDefault().LastName;

            label3.Text = selectedAbonentNumber + " - " + firstName + " " + lastName;

            var DBDB = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.SubscriptionScheduleDB>();
            var SelectedSubscribtion = (from o in DBDB where o.Subscription.IDnumber == selectedAbonentNumber.ToString() select new { Ganrigi = o.Schedule, Daswreba = o.Attandance }).ToList();
            var SelectDates = (from G in DBDB where G.Subscription.IDnumber == selectedAbonentNumber.ToString() select new { Ganrigi = G.Schedule }).ToList();

            var onlyDates = (from x in DBDB
                             where x.Subscription.IDnumber == selectedAbonentNumber.ToString()
                             select x.Schedule).ToList();
            FullDatetime = onlyDates;

            //HoursChek Hours = new HoursChek();
            foreach (var item in SelectedSubscribtion.OrderBy(x => x.Ganrigi.Date))
            {
                var gela = item.Ganrigi.Month;
                var geoCulture = new CultureInfo("ka-GE");
                var dateTimeInfo = DateTimeFormatInfo.GetInstance(geoCulture);
                var weekDay = item.Ganrigi.DayOfWeek;

                monthName = dateTimeInfo.GetAbbreviatedMonthName(gela);
                WeekDay = dateTimeInfo.GetAbbreviatedDayName(weekDay);
                DayNumber = item.Ganrigi.Day;

                //int aa = Convert.ToInt32(item.Daswreba);
                //AttendanceTypes Attend = new AttendanceTypes();
                var Attend = (AttendanceTypes)item.Daswreba;

                //DateTime gela = DateTime.Parse(item.Ganrigi, new CultureInfo("ka-Ge"));

                ////DateTime DateOfBirth = DateTime.ParseExact(item.Ganrigi, "MM-dd-yyyy", new CultureInfo("ka-GE"));
                SubscriptionScheduleDB g = new SubscriptionScheduleDB();


                HoursChek Hours = new HoursChek();
                Hours.GetHoursLabel = DayNumber + " " + monthName;
                Hours.GetAttendanceLabel = WeekDay + " " + item.Ganrigi.Hour + ":00 სთ";
                Hours.GetAttendanceGela = Attend.ToString();

                #region ფერები
                if (Hours.GetAttendanceGela == "დასვენება")
                {
                    Hours.BackColor = Color.Teal;
                }
                else if (Hours.GetAttendanceGela == "გააცდინა")
                {
                    Hours.BackColor = Color.Red;
                }

                else if (Hours.GetAttendanceGela == "დაესწრო")
                {
                    Hours.BackColor = Color.DarkSlateGray;
                }
                if (Hours.GetAttendanceGela == "მოლოდინი")
                {
                    Hours.BackColor = Color.Gray;
                }
                #endregion

                flowLayoutPanel1.Controls.Add(Hours);
                flowLayoutPanel1.AutoScroll = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedAbonentNumber = dataGridView1.SelectedCells[0].Value.ToString();
            InIt(selectedAbonentNumber);
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


            var subscriptionByID = DatabaseConnection.Conn.GetAllWithChildren<Subscription>().Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault();


            Form1 A = new Form1();






            var IDnumber = subscriptionByID.IDnumber.ToString();
            var LastName = subscriptionByID.Subscriber_.LastName;
            var Name = subscriptionByID.Subscriber_.Name;

            var Adress = subscriptionByID.Subscriber_.Address;
            var PhoneNumber = subscriptionByID.Subscriber_.PhoneNumber.ToString();
            var Age = subscriptionByID.Subscriber_.DateOfBirth;

            var currFillGrid = dataGridView1.SelectedRows[0].DataBoundItem as FillGrid;

            var ScheduleList = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>()
             .Where(x => x.IDnumber == currFillGrid.AbonentId).FirstOrDefault()
             .SubscribtionSchedule_.OrderBy(x => x.Schedule.Date).Select(x => x.Schedule).ToList();
            

            List<DateTime> Dates = ScheduleList;
            AddAbonent abonent = new AddAbonent(IDnumber, Name, LastName, PhoneNumber, Age, Adress, subscriptionByID, Dates);
            //abonent.Controls.Add(DataGridView datagridview1);
            A.EditFillGrid(abonent, Dates);


            var result = abonent.ShowDialog();


            if (result == DialogResult.OK)
            {
                initData();
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
        }

        private void ვადაგასულიToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
        }

        private int daynumber = Convert.ToInt16(DateTime.Now.DayOfWeek);


        private string getFormattedDate(DateTime dateTime)
        {

            return dateTime.ToString("dd/MM/yyyy");
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //List<FillGrid> TempList;
        #region Search 
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
           string textboxText = toolStripTextBox1.Text;

            newfillgrid = null;

            bool condition = !textboxText.Contains(" ");
            string[] f = textboxText.Split(' ');

            if (condition)
            {
                if (fillgrid.Any(o => o.AbonentId == textboxText))
                    newfillgrid = fillgrid.Where(i => i.AbonentId.Contains(textboxText)).ToList();

                else if (fillgrid.Any(o => o.FirstName == textboxText))
                    newfillgrid = fillgrid.Where(i => i.FirstName.Contains(textboxText)).ToList();

                else if (fillgrid.Any(o => o.LastName == textboxText))
                    newfillgrid = fillgrid.Where(i => i.LastName.Contains(textboxText)).ToList();

                //else if (fillgrid.Any(o => o.PhoneNumber == textboxText))
                //    newfillgrid = fillgrid.Where(i => i.PhoneNumber.Contains( textboxText)).ToList();

                else if (fillgrid.Any(o => o.Address == textboxText))
                    newfillgrid = fillgrid.Where(i => i.Address.Contains(textboxText)).ToList();
            }
            else if (!condition)
            {
               // newfillgrid = fillgrid.Where(i => i.Address.Contains(textboxText)).ToList();

                

                newfillgrid = fillgrid.Where(i => i.PhoneNumber.Contains(textboxText)).ToList();

                List<string> kk = new List<string>();
                foreach (var item in f)
                {
                    kk.Add(item);
                }



                if (fillgrid.Any(o => o.FirstName == kk[0] && o.LastName == kk[1]) )
                    newfillgrid = fillgrid.FindAll(k => k.FirstName == kk[0] && k.LastName == kk[1]);
                else
                    newfillgrid = fillgrid.FindAll(o => o.Address == textboxText).ToList();
            }

            if (string.IsNullOrEmpty(textboxText))
            {
                newfillgrid = fillgrid;
            }

            if (newfillgrid?.Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = newfillgrid;
            }
           
        }

        #endregion

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = null;

        }

        private void ლიმიტიToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Limit form = new Limit();

            form.Show();

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void გრაფიკიToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics gr = new Graphics();
            gr.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = form.last();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            //dataGridView1.DataSource = JoinClasses();
            //dataGridView1.DataSource = 
        }
        public class FillGrid
        {
            public string AbonentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public Availability HasInqury { get; set; }
            public DateTime? DateFrom { get; set; }
            public DateTime? DateTo { get; set; }
            public double Price { get; set; }
            public int Hours { get; set; }
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {            
           // this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
           
            //dataGridView1.Columns[columnIndexOrName].HeaderCell.ToolTipText = "OK";
        }

        private void ExportToExcel()
        {
            // Creating a Excel object.
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column.
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check.
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user.
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("წარმატებით შეინახა");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }




        private void ექსპორტიToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

         }
}


