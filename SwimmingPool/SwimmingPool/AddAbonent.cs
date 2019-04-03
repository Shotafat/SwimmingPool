﻿using SPSQLite;
using SPSQLite.CLASSES;
using SPSQLite.CLASSES.BussinessObjects;
using SPSQLite.CLASSES.Services;
using SPSQLite.UIMethods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SPSQLite;
using SQLiteNetExtensions.Extensions;

namespace SwimmingPool
{
    public partial class AddAbonent : Form
    {
        public List<string> ganrigidge = new List<string>();
        public List<int> columni = new List<int>();
        public List<int> rovsi = new List<int>();
       
        private int daynumber = Convert.ToInt16(DateTime.Now.DayOfWeek);
        #region shott
        //შოთა - გამოიყენება დეითების შესავსებად
        public Dictionary<int, List<DateTime>> DateDic = new Dictionary<int, List<DateTime>>();
        public static int Pagenumber = 0;
        public List<int> AbonentHours { get; set; }
        public List<DateTime> CurrentWeekDays { get; set; } = new List<DateTime>();
        public List<DateTime> SelectedDays { get; set; } = new List<DateTime>();
        public int SelectedCellCount;
        public int SelectedHour;
        public int SelectedCellIndex;
        public DateTime ThisMonday { get; set; }
        public DateTime CurrentMonday { get; set; }
        public int SelectedRowIndex;
        public Color BgColor;
        // public Dictionary<DateTime, List<CurrentGrid>> GridDataList { get; set; } = new Dictionary<DateTime, List<CurrentGrid>>();

        public bool FirstClick { get; set; } = false;
        public Label label;
        public List<int> CoordinateList { get; set; } = new List<int>();
        public bool IsHide = false;

        public DateTime CurrentDateValue { get; private set; } = DateTime.Now.Date;
        Dictionary<int, int> gela = new Dictionary<int, int>();
        #endregion


        public AddAbonent()
        {
            InitializeComponent();

            grafiki();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ka-GE"));

            SubscribtionPriceToDropdown();
            SelectedCellCount = 0;
            lblBack.Enabled = true;
            //dateTimePicker3.Value = dateTimePicker1.Value.AddMonths(1);

            /*function for calc current monday*/

            button2.Hide();
            IsHide = true;
            //AssignGridData();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ThisMonday = GetCurrentMonday(CurrentDateValue);
            AssignCurrentWeek(ThisMonday);
            // CellGrayColor(DateTime.Now.Date, dateTimePicker3.Value);

            dataGridView1.Rows[0].ReadOnly = true;
            dataGridView1.Rows[0].Frozen = true;
            dataGridView1.Rows[0].Cells[1].ReadOnly = true;
            GetCellColorToday();
            gridFillter(dataGridView1, ThisMonday);

        }

        public AddAbonent(DateTime date):this()
        {
            CurrentDateValue = date;


            button2.Hide();
            IsHide = true;
            //AssignGridData();

        }
       

        public AddAbonent(string IdNumber, string Name , string LastName, string phoneNumber, DateTime Age , string Adress , SPSQLite.Subscription subscribtion) :this()
        {
            
                label6.Text = "რ ე დ ა ქ ტ ი რ ე ბ ა";
           
                saxeli.Text = Name;
                gvari.Text = LastName;
                asaki.Text = Age.ToString();
                telefoni.Text = phoneNumber.ToString();
                misamarti.Text = Adress;



            shenaxva.Hide();
            button2.Show();
                
                //lblAnonimentNumber.Visible = abonenti.Visible = false;

            

        }

    


        public void GetCellColorToday()
        {
            dataGridView1.Rows[0].Cells[daynumber].Style.BackColor = Color.DarkSlateGray;
            dataGridView1.Rows[0].Cells[daynumber].Style.ForeColor = Color.White;
        }


        public DateTime GetCurrentMonday(DateTime day)
        {
            CurrentMonday = day;
            while (CurrentMonday.DayOfWeek != DayOfWeek.Monday)
            {
                CurrentMonday = day.AddDays(-1);
                day = CurrentMonday;
            }
            return CurrentMonday;
        }




        public void AssignCurrentWeek(DateTime CurrentMonday)
        {
            CurrentWeekDays.Clear();
            //dataGridView1.Rows.Add();
            for (int i = 1; i <= 7; i++)
            {
                var geoCulture = new CultureInfo("ka-GE");
                var euCulture = new CultureInfo("en-US");
                var dateTimeInfo = DateTimeFormatInfo.GetInstance(geoCulture);

                
                CurrentWeekDays.Add(CurrentMonday.AddDays(i - 1));
                dataGridView1.Rows[0].Cells[i].Value = CurrentWeekDays[i - 1].ToString("dd MMMM", geoCulture);
                var nino = CurrentWeekDays[i - 1].ToString("dd MMMM", euCulture);
                dataGridView1.Rows[0].Cells[i].Style.ForeColor = Color.DarkSlateGray;


                //dataGridView1.Rows[0].Cells[i].Selected = false;
                //dataGridView1.Columns[i].HeaderCell.Selected = false;
                if (i == 7)
                {
                    dataGridView1.Rows[0].Cells[i].Style.ForeColor = Color.DarkRed;
                }
                else
                {
                    dataGridView1.Rows[0].Cells[i].Style.ForeColor = Color.DarkSlateGray;
                }
            }
        }

        public void AssignCurrentWeek(DateTime CurrentMonday, DataGridView view)
        {
            CurrentWeekDays.Clear();
            //dataGridView1.Rows.Add();
            for (int i = 1; i <= 7; i++)
            {
                var geoCulture = new CultureInfo("ka-GE");
                var dateTimeInfo = DateTimeFormatInfo.GetInstance(geoCulture);
                CurrentWeekDays.Add(CurrentMonday.AddDays(i - 1));
                view.Rows[0].Cells[i].Value = CurrentWeekDays[i - 1].ToString("dd MMMM", geoCulture);
                view.Rows[0].Cells[i].Style.ForeColor = Color.Teal;


                //dataGridView1.Rows[0].Cells[i].Selected = false;
                //dataGridView1.Columns[i].HeaderCell.Selected = false;
                if (i == 7)
                    view.Rows[0].Cells[i].Style.ForeColor = Color.Red;
                else
                    view.Rows[0].Cells[i].Style.ForeColor = Color.DodgerBlue;
            }
        }


        public void CellGrayColor(DateTime day)
        {
            daynumber = Convert.ToInt32(day.DayOfWeek);

            if (CurrentWeekDays.Contains(day))
            {
                for (int i = 1; i < daynumber; i++)
                {
                    for (int j = 1; j < 13; j++)
                    {
                        dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[j].Cells[i].Style.ForeColor = Color.Gray;
                    }
                }
            }

            else
            {
                return;
            }
        }

        public void CellGrayColor(DateTime FstDate, DateTime SndDate)
        {
            int FstDateRank = Convert.ToInt32(FstDate.DayOfWeek);
            int SndDateRank = Convert.ToInt32(SndDate.DayOfWeek);
            int i = 0;
            do
            {
                foreach (var day in CurrentWeekDays)
                {
                    i++;
                    if (day.Date >= FstDate.Date && day.Date <= SndDate.Date)
                    {
                        continue;
                    }

                    else
                    {
                        for (int j = 1; j < 13; j++)
                        {
                            dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.LightGray;
                            dataGridView1.Rows[j].Cells[i].Style.ForeColor = Color.Gray;
                            dataGridView1.Rows[j].Cells[i].Selected = false;
                        }
                    }
                }

            } while (i < 6);
        }

        public void CalculateLastDate(int _selected, int _hours)
        {
            int WeekStep, DayStep;
            WeekStep = _hours / _selected;
            DayStep = _hours % _selected;

            if (_hours > _selected)
            {
                for (int i = 0; i < WeekStep; i++)
                {

                }
            }
        }


        public void gridFillter(DataGridView SubscriberSchedul, DateTime Start)
        {
            DateTime End = Start.AddDays(7 - (int)Start.DayOfWeek);
            SubscriberSchedul.DataSource = null;
            //MessageBox.Show(((int)Start.DayOfWeek).ToString());
            //FUTURE
            if (Start.DayOfWeek == 0)
            {
                Start.AddDays(-3);
            }

            var test = InputMethods.Filldata(Start, End);
            foreach (var item in InputMethods.DATAforInput)
            {
                SubscriberSchedul.Rows[item.Date.Hour - 8].Cells[(int)item.Date.Date.DayOfWeek].Value = item.Datelist.ToString();
            }
            //PAST

            foreach (var item in InputMethods.DATAforInputPast)
            {
                SubscriberSchedul.Rows[item.Date.Hour - 8].Cells[(int)item.Date.Date.DayOfWeek].Value = item.Datelist.ToString();
            }

            EmptyCellfiller(SubscriberSchedul);

        }

        public void EmptyCellfiller(DataGridView EmptyCell)
        {
            foreach (DataGridViewRow dgRow in EmptyCell.Rows)
            {
                for (int i = 0; i < 7; i++)
                {
                    var cell = dgRow.Cells[i];
                    if (cell.Value == null)   //Check for null reference
                    {
                        //cell.Style.BackColor = string.IsNullOrEmpty(cell.Value.ToString()) ?
                        //    Color.LightCyan :
                        //    Color.Orange;
                        cell.Style.ForeColor = Color.LightSlateGray;
                        cell.ReadOnly = true;
                        cell.Value = "0";
                    }
                }
            }
        }

        public void grafiki()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Add();

            for (int i = 10; i < 22; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i - 9].Cells[0].Value = Convert.ToString(i - 1 + ":00");
            }
            for (int i = 1; i < 13; i++)
            {
                for (int ii = 1; ii < daynumber; ii++)
                {
                    //dataGridView1.Rows[i].Cells[ii].Style.BackColor = Color.LightGray;
                    //dataGridView1.Rows[i].Cells[ii].Style.ForeColor = Color.Gray;

                }
            }
            for (int i = 0; i < 11; i++)
            {
                for (int ii = 0; ii < 7; ii++)
                {
                    dataGridView1.Rows[i].Cells[ii].DataGridView.DefaultCellStyle.BackColor = Color.White;
                }
            }

            //pirveli ujris shevseba DATE-biT

            int CurrentDay = (int)DateTime.Now.DayOfWeek;
            int ForwardDays = 6 - CurrentDay;
            int StartDay = CurrentDay - (CurrentDay - 1);

            dataGridView1.Rows[0].Cells[(int)DateTime.Now.DayOfWeek].Value = getFormattedDate(DateTime.Now);

            for (int i = 1; i <= ForwardDays; i++)
            {
                dataGridView1.Rows[0].Cells[(int)DateTime.Now.DayOfWeek + i].Value = getFormattedDate(DateTime.Now.AddDays(i));
            }

            for (int i = 1; i < CurrentDay; i++)
            {
                dataGridView1.Rows[0].Cells[(int)DateTime.Now.DayOfWeek - i].Value = getFormattedDate(DateTime.Now.AddDays(-i));
                // dataGridView1.Columns
            }

            dataGridView1.Rows[0].Cells[0].Value = " ";
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
        }

        public void grafiki(DataGridView gridview)
        {
            gridview.DataSource = null;
            gridview.Rows.Add();

            for (int i = 10; i < 22; i++)
            {
                gridview.Rows.Add();
                gridview.Rows[i - 9].Cells[0].Value = Convert.ToString(i - 1 + ":00");
            }

            for (int i = 0; i < 11; i++)
            {
                for (int ii = 0; ii < 7; ii++)
                {
                    gridview.Rows[i].Cells[ii].DataGridView.DefaultCellStyle.BackColor = Color.Snow;
                }
            }

            //pirveli ujris shevseba DATE-biT

            int CurrentDay = (int)DateTime.Now.DayOfWeek;
            int ForwardDays = 6 - CurrentDay;
            int StartDay = CurrentDay - (CurrentDay - 1);

            gridview.Rows[0].Cells[(int)DateTime.Now.DayOfWeek].Value = getFormattedDate(DateTime.Now);

            for (int i = 1; i <= ForwardDays; i++)
            {
                gridview.Rows[0].Cells[(int)DateTime.Now.DayOfWeek + i].Value = getFormattedDate(DateTime.Now.AddDays(i));
            }

            for (int i = 1; i < CurrentDay; i++)
            {
                gridview.Rows[0].Cells[(int)DateTime.Now.DayOfWeek - i].Value = getFormattedDate(DateTime.Now.AddDays(-i));
            }

            gridview.Rows[0].Cells[0].Value = " ";
            gridview.DefaultCellStyle.SelectionBackColor = Color.Green;
        }

        private string getFormattedDate(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }

        public void ricxvebi(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void simboloebi(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void cheked(object sender, EventArgs e)
        {

        }

        public void PushDays(DateTime day)
        {
            SelectedDays.Add(day);
        }

        private bool NotEqual(int count, int hour)
        {
            if (count > hour)
            {
                MessageBox.Show("თქვენს მიერ შერჩეული გრაფიკის საათები მეტია სასურველი საათების რაოდენობაზე");
                //cmbxHour.BackColor = Color.Red;

                return false;
            }

            else
            {
                return true;
            }
        }

        //private void cmbxHour_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SelectedHour = AbonentHours[cmbxHour.SelectedIndex];
        //}



        public ISubscription GenerateSubscribtionID(ISubscription subscribtion)
        {
            //  Subscription : ISubscription


            //var gel = ServiceInstances.Service().GetSubscriptionServices().GetData().Where(a => a.ID == gela.ID).FirstOrDefault();
            QuantityCounter.Quantity = QuantityCounter.QuantityIncrementer();
            string SubscribtionNumber = string.Format("A" + "{0:000}", QuantityCounter.Quantity);
            subscribtion.IDnumber = SubscribtionNumber;

            return subscribtion;
        }

        public void SubscribtionPriceToDropdown()
        {
            var SubscribtionPriceObject = ServiceInstances.Service().GetSubscriptionPriceServices().GetData().ToList();
            var Hour = (from o in SubscribtionPriceObject select new { Hours = o.NumberOfHours }).ToList();

            List<int> HourList = new List<int>();
            foreach (var item in Hour)
            {
                HourList.Add(item.Hours);
            }
            cmbxHour.DataSource = HourList;
        }



        public void Saver()
        {
            //  Datefiller();
            Datefiller(Pagenumber, DateDic, true);
            ISubscriber subscriber = new SPSQLite.CLASSES.Subscriber();
            ISubscriptionPrice SubPrice = new SubcsriptionPrice();
            ISubscription subscription = new SPSQLite.CLASSES.Subscription();
            subscriber = subscriberSaver();
            SubPrice = SubPriceReturner();
            subscription = GenerateSubscribtionID(subscription);
            IHealthNotice healthNotice = HealthNoticeSaver();
            List<ISubscriptionSchedule> Schedule = new List<ISubscriptionSchedule>();
            Schedule = Schedulereturner();
           // MessageBox.Show("METODSHI SHESVLAMDE" + Schedule.Count.ToString());
            DatabaseConnection.insertSubscribtion(subscriber, SubPrice, subscription, healthNotice, Schedule);
            Dates.Clear();
        }

        public IHealthNotice HealthNoticeSaver()
        {

            SPSQLite.CLASSES.HealthNotice Health = new SPSQLite.CLASSES.HealthNotice();
            if (diax.Checked == true)
            {
                Health.YESNO = Availability.ხელმისაწვდომი;
            }
            else
            {
                Health.YESNO = Availability.არახელმისაწვდომი;
            }

            Health.DateCreated = DateTime.Now;
            // insertSubscribtion(ISubscription subscription_, ISubscriber  subscriber_, ISubscriptionPrice subscriberprice)

            return Health;
        }


        public ISubscriber subscriberSaver()
        {
            //Subscriber subscriber_ = new Subscriber();

            string Date = asaki.Text;

            DateTime DateOfBirth = DateTime.ParseExact(Date, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            //var Subscriber = ServiceInstances.Service().CreateObjectForSub(saxeli.Text, gvari.Text, DateOfBirth, telefoni.Text, misamarti.Text);
            SPSQLite.CLASSES.Subscriber subscriber = new SPSQLite.CLASSES.Subscriber { Name = saxeli.Text, LastName = gvari.Text, DateOfBirth = DateOfBirth, PhoneNumber = telefoni.Text, Adress = misamarti.Text };

            //ServiceInstances.Service().GetSubscriberService().Add(subscriber);

            return subscriber;

        }

        //  SubcsriptionPrice : ISubscriptionPrice
        public ISubscriptionPrice SubPriceReturner()
        {
            int Hour = (int)cmbxHour.SelectedValue;
            SubcsriptionPrice NewSubPR = new SubcsriptionPrice() { NumberOfHours = Hour };

            return NewSubPR;
        }


        private void shenaxva_Click_1(object sender, EventArgs e)
        {

            //string gela = asaki.Text;
            //DateTime gela1 = DateTime.ParseExact(gela, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            //var gelag = ServiceInstances.Service().CreateObjectForSub( saxeli.Text, gvari.Text, gela1, telefoni.Text, misamarti.Text);

            //ServiceInstances.Service().GetSubscriberService().Add(gelag);
            try
            {
                Saver();
            }
            catch
            {
                MessageBox.Show("დაამატეთ საათების რაოდენობა");

            }


            DialogResult = DialogResult.OK;
            Close();
        }

        //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{
        //    if (dateTimePicker1.Value < DateTime.Today)
        //    {
        //        dateTimePicker1.Value = DateTime.Today;
        //        return;
        //    }

        //    if (dateTimePicker1.Value >= dateTimePicker3.Value)
        //    {
        //        return;
        //    }

        //    dataGridView1.Rows.Clear();
        //    grafiki();
        //    AssignCurrentWeek(GetCurrentMonday(dateTimePicker1.Value));
        //    //CellGrayColor(dateTimePicker1.Value,dateTimePicker3.Value);

        //    //DateTime _today = DateTime.ParseExact(DateTime.Now.ToString(), CultureInfo.InvariantCulture);

        //    foreach (var day in CurrentWeekDays)
        //    {
        //        if (day.Date == DateTime.Today.Date)
        //        {
        //            GetCellColorToday();
        //        }
        //    }

        //    gridFillter(dataGridView1, CurrentMonday);
        //}

        private void lblNext_Click_1(object sender, EventArgs e)
        {

        }

        private void lblBack_Click_1(object sender, EventArgs e)
        {
        }


        public static List<DateTime> Dates = new List<DateTime>();

        public List<ISubscriptionSchedule> Schedulereturner()
        {

            // Dates = null;
            List<ISubscriptionSchedule> Schedule_ = new List<ISubscriptionSchedule>();

            foreach (var item in Dates)
            {
                ISubscriptionSchedule SingleDay = new SubscriptionSchedule { Schedule = item, Attendance = SPSQLite.Enums.AttendanceTypes.მოლოდინი };
                Schedule_.Add(SingleDay);
            }
            return Schedule_;
        }


        public bool CoordinatesIsEqual(int X, int Y)
        {
            if (SelectedCellIndex != X || SelectedRowIndex != Y)
            {
                SelectedCellIndex = X;
                SelectedRowIndex = Y;
                //CalcIncreaseDicrease(X, Y);
                return false;
            }

            else
            {
                //CalcIncreaseDicrease(SelectedCellIndex, SelectedRowIndex);
                return true;
            }
        }
        public void SetDefaultCellColor(int ColumnRank)
        {
            for (int i = 1; i < 13; i++)
            {
                dataGridView1.Rows[i].Cells[ColumnRank].Style.BackColor = Color.White;
                dataGridView1.Rows[i].Cells[ColumnRank].Style.ForeColor = Color.Gray;
                dataGridView1.Rows[i].Cells[ColumnRank].Style.SelectionBackColor = Color.White;
                dataGridView1.Rows[i].Cells[ColumnRank].Style.SelectionForeColor = Color.Gray;
            }
        }
       
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {



            // gela.Add(e.ColumnIndex, e.RowIndex);
            
            var nino = gela.Any(x => x.Key == e.ColumnIndex); 
            if(nino)
            {
              var zz =  gela.FirstOrDefault(x => x.Key == e.ColumnIndex);
                if (IsHide)
                {
                    gela.Remove(zz.Key);
               
                    dataGridView1.Rows[zz.Value].Cells[zz.Key].Selected = false;
                }
                else
                {
                    dataGridView1.Rows[zz.Value].Cells[zz.Key].Style.BackColor = Color.White;
                }
              

                gela.Add(zz.Key,e.RowIndex );

              
            }
            else
            {
                gela.Add(e.ColumnIndex, e.RowIndex);

            }

            foreach (var item in gela)
            {
             
            }
            //  NickCode(e);
            // MessageBox.Show("Click");

            Capicity capicity = new Capicity();
            int a = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) + 1;
            try
            {
                if (a > ServiceInstances.Service().GetCapicityServices().GetData().Last().CapicityValue)
                {
                    MessageBox.Show("თავისუფალი ადგილები არ არის, გსურთ გაგრძელება?");
                }
            }

            catch
            {

                MessageBox.Show("განსაზღვრეთ წინასწარ ლიმიტი");

                Limit limit = new Limit();
                limit.ShowDialog();


            }

          //  dataGridView1.Rows[].Cells[item.Key].Selected = true;



        }

        //AQ GAVCHERDI
        public void DatestoSelectedCells()
        {
            //foreach (var item in collection)
            //{

            //}

        }

        //წინ წასვლა
        public void Datefiller(Dictionary<int, List<DateTime>> DictDate)
        {
            List<DateTime> DictionaryValues = new List<DateTime>();
            foreach (var cell in gela)
            {

                if (cell.Key == 0)
                {
                    break;
                }
                else
                {

                    int Hour = (cell.Value + 8);
                    var Date = CurrentWeekDays[0 + cell.Key - 1];
                    DateTime FinalDate = new DateTime();
                    string _FinalDate = "";
                    if (Hour < 10)
                    {
                        _FinalDate = $"{Date.ToString("dd/MM/yyyy")} 0{Hour}:00";
                    }
                    else
                    {
                        _FinalDate = $"{Date.ToString("dd/MM/yyyy")} {Hour}:00";
                    }

             //       MessageBox.Show("წინ ROW " + cell.RowIndex + " COLINDEX: " + cell.ColumnIndex + " " + _FinalDate + " SIGRDZE " + dataGridView1.SelectedCells.Count);

                    FinalDate = DateTime.ParseExact(_FinalDate, "dd/MM/yyyy HH:mm", CultureInfo.CurrentUICulture);
                    DictionaryValues.Add(FinalDate);
//  Dates.Add(FinalDate);
                }
            }
            if(!DictDate.ContainsKey(Pagenumber))
            DictDate.Add(Pagenumber, DictionaryValues);
            Pagenumber = Pagenumber + 1;
           // MessageBox.Show(Pagenumber.ToString());
        }


        public void BackClickSaveDictionary(Dictionary<int, List<DateTime>> DictDate)
        {
            //MessageBox.Show("BackClickSaveDictionary" + Pagenumber.ToString());
            List<DateTime> DictionaryValues = new List<DateTime>();

            Dictionary<int, int> gela = new Dictionary<int, int>();

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                if (cell.ColumnIndex == 0)
                {
                    break;
                }
                else
                {

                    int Hour = (cell.RowIndex + 8);
                    var Date = CurrentWeekDays[0 + cell.ColumnIndex - 1];

                   

                    DateTime FinalDate = new DateTime();
                    string _FinalDate = "";
                    if (Hour < 10)
                    {
                        _FinalDate = $"{Date.ToString("dd/MM/yyyy")} 0{Hour}:00";
                    }
                    else
                    {
                        _FinalDate = $"{Date.ToString("dd/MM/yyyy")} {Hour}:00";
                    }

                    //       MessageBox.Show("წინ ROW " + cell.RowIndex + " COLINDEX: " + cell.ColumnIndex + " " + _FinalDate + " SIGRDZE " + dataGridView1.SelectedCells.Count);

                    FinalDate = DateTime.ParseExact(_FinalDate, "dd/MM/yyyy HH:mm", CultureInfo.CurrentUICulture);

                    DictionaryValues.Add(FinalDate);
                    //  Dates.Add(FinalDate);
                }
            }
            if (!DictDate.ContainsKey(Pagenumber))
                DictDate.Add(Pagenumber, DictionaryValues);
            else
                DictDate[Pagenumber] = DictionaryValues;
            //Pagenumber = Pagenumber + 1;
 //           MessageBox.Show(Pagenumber.ToString());





        }





        public void DatefillFront(Dictionary<int, List<DateTime>> DictDate)
        {
            int PageIndex = Pagenumber;
           // MessageBox.Show("PageIndex " + PageIndex.ToString());
            List<DateTime> DictionaryValuesАFront = new List<DateTime>();
            if (DictDate.ContainsKey(PageIndex))
            {
                DictionaryValuesАFront = DictDate[PageIndex];
                foreach (var item in DictionaryValuesАFront)
                {
                    int rowindex = item.Hour - 8;
                    int columnindex = (int)item.DayOfWeek;
                  //  MessageBox.Show("BACK" + rowindex + "COLUMN " + columnindex);
                    dataGridView1.Rows[rowindex].Cells[columnindex].Selected = true;

                }
            }



        }

        //SAVEZE
        public void Datefiller(int DictionaryIndex, Dictionary<int, List<DateTime>> DictDate, bool Saveclick)
        {
            
            List<DateTime> DictionaryValues = new List<DateTime>();
            foreach (var cell in gela)
            {

                if (cell.Key == 0)
                {
                    break;
                }
                else
                {

                    int Hour = (cell.Value + 8);
                    var Date = CurrentWeekDays[0 + cell.Key - 1];
                    DateTime FinalDate = new DateTime();
                    string _FinalDate = "";
                    if (Hour < 10)
                    {
                        _FinalDate = $"{Date.ToString("dd/MM/yyyy")} 0{Hour}:00";
                    }
                    else
                    {
                        _FinalDate = $"{Date.ToString("dd/MM/yyyy")} {Hour}:00";
                    }

                    // MessageBox.Show(" SAVE ROW " + cell.RowIndex + " COLINDEX: " + cell.ColumnIndex + " " + _FinalDate + " SIGRDZE " + dataGridView1.SelectedCells.Count);

                    FinalDate = DateTime.ParseExact(_FinalDate, "dd/MM/yyyy HH:mm", CultureInfo.CurrentUICulture);

                    DictionaryValues.Add(FinalDate);
                    //  Dates.Add(FinalDate);
                }
            }


            #region shota
            //foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            //{

            //    if (cell.ColumnIndex == 0)
            //    {
            //        break;
            //    }
            //    else
            //    {

            //        int Hour = (cell.RowIndex + 8);
            //        var Date = CurrentWeekDays[0 + cell.ColumnIndex - 1];
            //        DateTime FinalDate = new DateTime();
            //        string _FinalDate = "";
            //        if (Hour < 10)
            //        {
            //            _FinalDate = $"{Date.ToString("dd/MM/yyyy")} 0{Hour}:00";
            //        }
            //        else
            //        {
            //            _FinalDate = $"{Date.ToString("dd/MM/yyyy")} {Hour}:00";
            //        }

            //       // MessageBox.Show(" SAVE ROW " + cell.RowIndex + " COLINDEX: " + cell.ColumnIndex + " " + _FinalDate + " SIGRDZE " + dataGridView1.SelectedCells.Count);

            //        FinalDate = DateTime.ParseExact(_FinalDate, "dd/MM/yyyy HH:mm", CultureInfo.CurrentUICulture);

            //        DictionaryValues.Add(FinalDate);
            //        //  Dates.Add(FinalDate);
            //    }
            //}
            // DictDate.Add(DictionaryIndex, DictionaryValues);
            #endregion
            if (!DictDate.ContainsKey(Pagenumber))
                DictDate.Add(Pagenumber, DictionaryValues);
            else
                DictDate[Pagenumber] = DictionaryValues;


            foreach (var item in DictDate)
            {
                foreach (var internaldata in item.Value)
                {
                    Dates.Add(internaldata);
                }

            }
            DictionaryIndex=0;
//            Pagenumber = 0;
        }



        //UKAN
        public void Datefiller(Dictionary<int, List<DateTime>> DictDate, double Back)
        {
           
            Pagenumber = Pagenumber - 1;

           // MessageBox.Show("PAGE NUMBER FOR DICT" + Pagenumber.ToString());
            if (Pagenumber < 0)
                return;
            else
            { 
            List<DateTime> DictionaryValues = DictDate[Pagenumber];
            foreach (var item in DictionaryValues)
            {
                int rowindex = item.Hour - 8;
                int columnindex = (int)item.DayOfWeek;
               // MessageBox.Show("BACK"+rowindex + "COLUMN " + columnindex);
                dataGridView1.Rows[rowindex].Cells[columnindex].Selected = true;
         
            }
            }



        }





        public void Datefiller()
        {

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                if (cell.ColumnIndex == 0)
                {
                    break;
                }
                else
                {

                    int Hour = (cell.RowIndex + 8);
                    var Date = CurrentWeekDays[0 + cell.ColumnIndex - 1];
                    DateTime FinalDate = new DateTime();
                    string _FinalDate = "";
                    if (Hour < 10)
                    {
                        _FinalDate = $"{Date.ToString("dd/MM/yyyy")} 0{Hour}:00";
                    }
                    else
                    {
                        _FinalDate = $"{Date.ToString("dd/MM/yyyy")} {Hour}:00";
                    }

                //    MessageBox.Show("ROW " + cell.RowIndex + " COLINDEX: " + cell.ColumnIndex + " " + _FinalDate + " SIGRDZE " + dataGridView1.SelectedCells.Count);

                    FinalDate = DateTime.ParseExact(_FinalDate, "dd/MM/yyyy HH:mm", CultureInfo.CurrentUICulture);
                    Dates.Add(FinalDate);
                }
            }
        }
        //if (!FirstClick)
        //{
        //    dateTimePicker1.Value = FinalDate;
        //    FirstClick = !FirstClick;
        //}

        //if (Dates != null)
        //{
        //    if (Dates.Contains(FinalDate.Date))
        //    {
        //        int a = Dates.IndexOf(FinalDate);
        //        Dates.RemoveAt(a);
        //    }

        //    else
        //    {
        //        Dates.Add(FinalDate);
        //    }
        //}





        public void NickCode(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 7 || e.RowIndex == 0)
            {
                dataGridView1.Rows[0].Cells[e.ColumnIndex].Selected = false;
                if (e.ColumnIndex == 7)
                {
                    dataGridView1.Rows[0].Cells[e.ColumnIndex].Selected = false;
                    MessageBox.Show("კვირა დასვენების დღეა!");
                }
                return;
            }


            if (e.RowIndex != -1)
            {
                CoordinateList.Add(e.ColumnIndex);
                CoordinateList.Add(e.RowIndex);

                bool _coordinatesIsEqual = CoordinatesIsEqual(e.ColumnIndex, e.RowIndex);
                int Hour = (e.RowIndex + 8);

                //grid.CalcIncreaseDicrease(e.ColumnIndex, e.RowIndex, CurrentWeekDays[e.ColumnIndex - 1]);

                var Date = CurrentWeekDays[0 + e.ColumnIndex - 1];

                BgColor = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;
                if (BgColor.Name == "0")
                {
                    BgColor = Color.White;
                }

                SetDefaultCellColor(e.ColumnIndex); /*Set Cell Default Color*/

                if (!_coordinatesIsEqual && BgColor == Color.White)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.White;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.Green;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.White;
                }

                else
                {
                    if (BgColor == Color.Green)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Gray;
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Gray;
                    }

                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.White;
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.Green;
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.White;
                    }

                }

                bool sell = columni.Contains(e.ColumnIndex);
                bool rov = rovsi.Contains(e.RowIndex);

                string columnName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                string rowName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = columnName + " - " + rowName;

                archeuligrafiki.DataSource = null;
                ganrigidge.Sort();
                archeuligrafiki.DataSource = ganrigidge;
            }
            else
            {
                return;
            }




        }




        #region რანდომი სატესტოდ
        private void button1_Click(object sender, EventArgs e)
        {

            string[] names = new string[]
               {
                    "გელა",
                    "ნელი",
                    "გულიკო",
                    "მზევინარ",
                    "პაჭურტი"
               };
            string[] LastNames = new string[]
            {
                    "გეჯაძე",
                    "მინდია",
                    "ბუჩუკური",
                    "ლელაძე"
            };

            string[] Numbers = new string[]
            {
                    "555 56 78 23",
                    "577 23 87 23",
                    "587 89 23 76"
            };

            string[] Adress = new string[]
            {
                    "ვარკეთილი",
                    "ფონიჭალა",
                    "რუსთაველი",
                    "ვაშლიჯვარი"
            };

            string[] Date = new string[]
            {
                "01042001",
                "01281996",
                "03042000",
                "10031990",
                "03041890"



            };

            // saxeli 
            Random rand = new Random();
            int index = rand.Next(names.Count());
            var name = names[index];

            saxeli.Text = name;
            //gvari
            int gvarindex = rand.Next(LastNames.Count());
            var LastName = LastNames[gvarindex];

            gvari.Text = LastName;

            // nomrebi 

            int NumberIndex = rand.Next(Numbers.Count());
            var Number = Numbers[NumberIndex];

            telefoni.Text = Number;

            // misamarti 

            int AdressIndex = rand.Next(Adress.Count());
            var adress = Adress[AdressIndex];

            misamarti.Text = adress;


            // asaki 

            int DateIndex = rand.Next(Date.Count());
            var birthDate = Date[DateIndex];

            asaki.Text = birthDate;




        }

        #endregion

        private void lblNext_Click_2(object sender, EventArgs e)
        {

            //DICTIONARIS SHESAVSEBAD
            Datefiller(DateDic);

            dataGridView1.Rows.Clear();
            grafiki();
            CurrentMonday = CurrentMonday.AddDays(7);
            AssignCurrentWeek(CurrentMonday);
            lblBack.Enabled = true;
            lblBack.ForeColor = Color.DarkSlateGray;
            lblBack.Cursor = Cursors.Hand;

            gridFillter(dataGridView1, CurrentMonday);
            //DICTIONARIS WASAKITXTAD
            DatefillFront(DateDic);

            //CellGrayColor(dateTimePicker1.Value, dateTimePicker3.Value);
        }

        private void lblBack_Click_2(object sender, EventArgs e)
        {

            // MessageBox.Show("SHEMOSVLA 1" + Pagenumber.ToString());
            BackClickSaveDictionary(DateDic);
            dataGridView1.Rows.Clear();
            grafiki();
            CurrentMonday = CurrentMonday.AddDays(-7);
            AssignCurrentWeek(CurrentMonday);


            if (CurrentMonday == ThisMonday)
            {
                lblBack.Enabled = true;
                //lblBack.ForeColor = Color.Gray;
                //lblBack.Cursor = Cursors.No;
                //CellGrayColor(DateTime.Now.Date);
                GetCellColorToday();
            }

            //CellGrayColor(dateTimePicker1.Value, dateTimePicker3.Value);

            gridFillter(dataGridView1, CurrentMonday);
           // MessageBox.Show("SHEMOSVLA 2 " + Pagenumber.ToString());
            Datefiller(DateDic, 1.5);
        }


        //private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        //{
        //    if (dateTimePicker3.Value <= dateTimePicker1.Value)
        //    {
        //        return;
        //    }

        //    dataGridView1.Rows.Clear();
        //    grafiki();
        //    AssignCurrentWeek(GetCurrentMonday(dateTimePicker1.Value));

        //    //AssignCurrentWeek(GetCurrentMonday(dateTimePicker3.Value));
        //    //CellGrayColor(dateTimePicker1.Value, dateTimePicker3.Value);
        //    //CellGrayColorRight(dateTimePicker3.Value);

        //    gridFillter(dataGridView1, CurrentMonday);
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                var subscriptionByID = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>().Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault();
                var newobj = subscriptionByID;

                var subscriber = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscriber>().Where(x => x.SubscribtionID == subscriptionByID.Id).FirstOrDefault();

                var ScheduleList = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>()
                   .Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault()
                   .SubscribtionSchedule_.OrderBy(x=>x.Schedule.Date).ToList();
                                   
              

                subscriber.Name = saxeli.Text;
                subscriber.LastName = gvari.Text;
                subscriber.PhoneNumber = telefoni.Text;
                subscriber.Address = misamarti.Text;

                //newobj.Subscriber_.DateOfBirth = Convert.ToDateTime(asaki.Text);


                //newobj.Subscriber_.Healthnotice[0].YesNO = Availability.ხელმისაწვდომი; 
                DatabaseConnection.Conn.Update(subscriber);
                DatabaseConnection.Conn.UpdateWithChildren(newobj);

             


            }

            catch
            {
                MessageBox.Show("დაამატეთ საათების რაოდენობა");


            }
            Form1 form = new Form1();
            Close();
            form.Refresh();



        }
    }
}
//public class CurrentGrid : AddAbonent
//{
//    public int X { get; set; }
//    public int Y { get; set; }
//    public Color CurrentColor { get; set; }
//    public int SeatNumber { get; set; }

//    public void CalcIncreaseDicrease(int x, int y, DateTime day)
//    {
//        //var BgColor = GridDataList.Where(pair => pair.Key == day).Select(pair => pair.Value.Select(c => c.CurrentColor));

//        //if (GridDataList.FirstOrDefault(k=> k.Key == day, ) == Color.White || BgColor.Name == "0")
//        //{
//        //    ++_value;
//        //}

//        //else
//        //{
//        //    --_value;
//        //}


//        //dataGridView1[x, y].Value = _value.ToString();
//        //dataGridView1.Refresh();
//        //dataGridView1.SelectedRows[x].Cells[y].Value = _value;

//    }
//}
