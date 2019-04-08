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
            dataGridView1.AutoGenerateColumns = true;
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

            dataGridView1.DataSource = fillgrid;
            MyFillGrid = fillgrid;

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

        public void EditFillGrid (DataGridView DataGrid, List<DateTime> DateList)
            { 
            foreach (var item in DateList)
            {
                int rowindex = item.Hour - 8;
                int columnindex = (int)item.DayOfWeek;
                DataGrid.DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
                DataGrid.Rows[rowindex].Cells[columnindex].Selected = true;
  //              MessageBox.Show(DataGrid.Rows[rowindex].Cells[columnindex].Selected.ToString());
                DataGrid.Rows[rowindex].Cells[columnindex].Style.BackColor = Color.DarkSlateGray;
            }
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

            HoursChek A = new HoursChek();
            A.EdiTAbonent();
            //if (dataGridView1.SelectedRows[0].Selected)
            //{
            //    var subscriptionPrice = dataGridView1.SelectedRows[0].DataBoundItem as ISubscriber;
            //    AddAbonent add = new AddAbonent(subscriptionPrice);

            //    add.ShowDialog();
            //    if (add.DialogResult == DialogResult.OK)
            //    {
            //        Form1_Load(sender, e);

            //    }
            //}
            //else
            //{
            //    MessageBox.Show("გთხოვთ მონიშნოთ აბონიმენტი!");
            //}
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
                newfillgrid = fillgrid.Where(i => i.Address.Contains(textboxText)).ToList();
                newfillgrid = fillgrid.Where(i => i.PhoneNumber.Contains(textboxText)).ToList();
                List<string> kk = new List<string>();
                foreach (var item in f)
                {
                    kk.Add(item);
                }

                if (fillgrid.Any(o => o.FirstName == kk[0] && o.LastName == kk[1]))
                    newfillgrid = fillgrid.FindAll(k => k.FirstName == kk[0] && k.LastName == kk[1]);

                
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
            toolStripTextBox1.Text = string.Empty;

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
        /*
                private void ექსპორტიToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel Documents (*.xls)|*.xls";
                    sfd.FileName = "Abonimentebis sia.xls";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                         Copy DataGridView results to clipboard
                        copyAlltoClipboard();

                        object misValue = System.Reflection.Missing.Value;
                        Excel.Application xlexcel = new Excel.Application();

                        xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                        Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);

                        Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                         Format column D as text before pasting results, this was required for my data
                        Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                        rng.NumberFormat = "@";

                         Paste clipboard results to worksheet range
                       Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                       CR.Select();
                        xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                         For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                         Delete blank column A and select cell A1
                       Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                      delRng.Delete(Type.Missing);
                        xlWorkSheet.get_Range("A1").Select();

                         Save the excel file under the captured location from the SaveFileDialog
                        xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlexcel.DisplayAlerts = true;
                        xlWorkBook.Close(true, misValue, misValue);
                        xlexcel.Quit();

                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlexcel);

                         Clear Clipboard and DataGridView selection
                        Clipboard.Clear();
                        dataGridView1.ClearSelection();

                         Open the newly saved excel file
                        if (File.Exists(sfd.FileName))
                            System.Diagnostics.Process.Start(sfd.FileName);
                    }

                }
                */
        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            //DataObject dataObj = dataGridView1.DataSource;
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
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
    }
}


