using SPSQLite;
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
        public List<GridFormat> CheckedDayList = new List<GridFormat>();
        DateTime FinalDate = new DateTime();
        string AbonimentisnomeriVdagasulebidan;
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

        public DateTime CurrentDateValue { get; private set; } = DateTime.Now.Date;
        #endregion


        public AddAbonent()
        {
            InitializeComponent();
            
            grafiki();
            //InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ka-GE"));

            ThisMonday = GetCurrentMonday(CurrentDateValue);
            AssignCurrentWeek(ThisMonday);

            SubscribtionPriceToDropdown();
            SelectedCellCount = 0;
            lblBack.Enabled = true;
            //dateTimePicker3.Value = dateTimePicker1.Value.AddMonths(1);

            /*function for calc current monday*/
            buttonVadagas.Hide();
            button3.Hide();
            button2.Hide();
            //AssignGridData();
            dataGridView1.Rows[0].ReadOnly = true;
            dataGridView1.Rows[0].Selected = false;
            dataGridView1.Rows[0].Frozen = true;
            dataGridView1.Rows[0].Cells[1].ReadOnly = true;






        }

        protected override void OnLoad(EventArgs e)
        {
            //base.OnLoad(e);

            dataGridView1.Rows[0].ReadOnly = true;
            dataGridView1.Rows[0].Frozen = true;
            dataGridView1.Rows[0].Cells[1].ReadOnly = true;
            GetCellColorToday();
            gridFillter(dataGridView1, ThisMonday);

        }

        public AddAbonent(DateTime date):this()
        {
            CurrentDateValue = date;

            buttonVadagas.Hide();
            button3.Hide();
            //AssignGridData();

        }
       

        public void FillCheckdayList(List<DateTime> DatabaseDates)
        {
            Dates = DatabaseDates;
            foreach (var item in DatabaseDates)
            {
                int rowindex = item.Hour - 8;
                int columnindex = (int)item.DayOfWeek;

                GridFormat AA = new GridFormat(1) { Day = item, X = rowindex, Y = columnindex, IsChecked = true };
                CheckedDayList.Add(AA);

            }

         


        }

        public AddAbonent(string IdNumber, string Name , string LastName, string phoneNumber, DateTime Age , string Adress , SPSQLite.Subscription subscribtion, List<DateTime> DatabaseScheduleDate) //:this()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            ThisMonday = GetCurrentMonday(DatabaseScheduleDate[0]);


            //  grafiki(dataGridView1);
           Grafiki_edit(DatabaseScheduleDate[0]);
           gridFillter(dataGridView1, ThisMonday);

        //    DrawGrid();



            AssignCurrentWeek(ThisMonday, dataGridView1);
          
            // Grafiki_edit(dataGridView1);
            FillCheckdayList(DatabaseScheduleDate);
            abonenti.Text = IdNumber;
            saxeli.Text = Name;
            gvari.Text = LastName;
            asaki.Text = string.Format("{0:MM/dd/yyyy}", Age); //Convert.ToDateTime(Age).ToString();
            telefoni.Text = phoneNumber.ToString();
            misamarti.Text = Adress;
            shenaxva.Hide();
            buttonVadagas.Hide();
            button3.Show();
       

        }






        public AddAbonent(string IdNumber, string Name, string LastName, string phoneNumber, DateTime Age, string Adress, SPSQLite.Subscription subscribtion, List<DateTime> DatabaseScheduleDate, bool Vadagasulebi) //:this()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            ThisMonday = GetCurrentMonday(DatabaseScheduleDate[0]);
            AbonimentisnomeriVdagasulebidan = IdNumber;

            //  grafiki(dataGridView1);
            Grafiki_edit(DatabaseScheduleDate[0]);
            gridFillter(dataGridView1, ThisMonday);

            //    DrawGrid();



            AssignCurrentWeek(ThisMonday, dataGridView1);

            // Grafiki_edit(dataGridView1);
            FillCheckdayList(DatabaseScheduleDate);
            abonenti.Text = IdNumber;
            saxeli.Text = Name;
            gvari.Text = LastName;
            asaki.Text = string.Format("{0:MM/dd/yyyy}", Age); //Convert.ToDateTime(Age).ToString();
            telefoni.Text = phoneNumber.ToString();
            misamarti.Text = Adress;
            shenaxva.Hide();
            buttonVadagas.Show();
            button3.Hide();


        }
















        public void GetCellColorToday()
        {
            dataGridView1.Rows[0].Cells[daynumber].Style.BackColor = Color.SaddleBrown;
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
              
                var dateTimeInfo = DateTimeFormatInfo.GetInstance(geoCulture);

                
                CurrentWeekDays.Add(CurrentMonday.AddDays(i - 1));
                dataGridView1.Rows[0].Cells[i].Value = CurrentWeekDays[i - 1].ToString("dd MMMM", geoCulture);
                var nino = CurrentWeekDays[i - 1].ToString("dd MMMM", geoCulture);
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
                //var geoCulture = new CultureInfo("en-ENG");
                var euCulture = new CultureInfo("en-US");
                CurrentWeekDays.Add(CurrentMonday.AddDays(i - 1));
                view.Rows[0].Cells[i].Value = CurrentWeekDays[i - 1].ToString("dd MMMM", euCulture);
                view.Rows[0].Cells[i].Style.ForeColor = Color.Teal;


                //dataGridView1.Rows[0].Cells[i].Selected = false;
                //dataGridView1.Columns[i].HeaderCell.Selected = false;
                if (i == 7)
                    view.Rows[0].Cells[i].Style.ForeColor = Color.Red;
                else
                    view.Rows[0].Cells[i].Style.ForeColor = Color.DarkSlateGray;
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
            //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
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


        /*----------------------------------*/


        public void Grafiki_edit(DateTime EditDate)
        {
          //  HoursChek AAA = new HoursChek();
            
            //List<DateTime> DDD = AAA.ScheduleList();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Add();

            for (int i = 10; i < 22; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i - 9].Cells[0].Value = Convert.ToString(i - 1 + ":00");
            }

            for (int i = 0; i < 11; i++)
            {
                for (int ii = 0; ii < 7; ii++)
                {
                    dataGridView1.Rows[i].Cells[ii].DataGridView.DefaultCellStyle.BackColor = Color.Snow;
                }
            }

            //pirveli ujris shevseba DATE-biT

            int CurrentDay = (int)EditDate.DayOfWeek;
            int ForwardDays = 6 - CurrentDay;
            int StartDay = CurrentDay - (CurrentDay - 1);

            dataGridView1.Rows[0].Cells[(int)EditDate.DayOfWeek].Value = getFormattedDate(EditDate);

            for (int i = 1; i <= ForwardDays; i++)
            {
                dataGridView1.Rows[0].Cells[(int)EditDate.DayOfWeek + i].Value = getFormattedDate(EditDate.AddDays(i));
            }

            for (int i = 1; i < CurrentDay; i++)
            {
                dataGridView1.Rows[0].Cells[(int)EditDate.DayOfWeek - i].Value = getFormattedDate(EditDate.AddDays(-i));
            }

            dataGridView1.Rows[0].Cells[0].Value = " ";
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Green;
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
                Health.YESNO = Availability.Yes;
            }
            else
            {
                Health.YESNO = Availability.No;
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
            int Hour = Convert.ToInt32(lblHours.Text);
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
        HoursChek hours = new HoursChek();

        Dictionary<int, int> gela = new Dictionary<int, int>();

        public void DateFormat()
        {
       }



        private void ShotaCopydataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 && e.RowIndex != 0) { 
            int Hour = (e.RowIndex + 8);
            var Date = CurrentWeekDays[0 + e.ColumnIndex - 1];
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
            //   Dates.Add(FinalDate);




            //________________________
            var id = CheckedDayList.Count;
            GridFormat f = new GridFormat(id);
            f.X = e.RowIndex;
            f.Y = e.ColumnIndex;
            f.Day = FinalDate;
            f.IsChecked = true;

            if (CheckedDayList.Count == 0)
            {
                CheckedDayList.Add(f);
                dataGridView1.Rows[f.X].Cells[f.Y].Style.SelectionBackColor = Color.Red;
            }

            else
            {
                Checking(f);
                DrawGrid(CurrentWeekDays);
            }


            var lbl = CheckedDayList.Count();
            lblHours.Text = lbl.ToString();


            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void DrawGrid(List<DateTime> week)
        {
            if (CheckedDayList.Count > 0)
            {
                var currentGrid = CheckedDayList.Where(d => d.Day >= week[0] && d.Day <= week[week.Count - 1]).ToList();

                foreach (var item in currentGrid)
                {
                    dataGridView1.Rows[item.X].Cells[item.Y].Style.SelectionBackColor = Color.Red;
                    dataGridView1.Rows[item.X].Cells[item.Y].Style.BackColor = Color.Red;
                }
            }
            else
                return;
        }





        public void Checking(GridFormat obj)
        {
            bool value = CheckedDayList.Any(o => o.Day == obj.Day && o.Y == obj.Y && o.X == obj.X);
            bool value2 = CheckedDayList.Any(x => x.Day == obj.Day && x.Y == obj.Y && x.X != obj.X);

            if (value2)
            {
                var OriginObj = CheckedDayList.Where(x => x.Day == obj.Day && x.Y == obj.Y && x.X != obj.X).FirstOrDefault();
                var _id = CheckedDayList.IndexOf(OriginObj);

                dataGridView1.Rows[OriginObj.X].Cells[OriginObj.Y].Style.SelectionBackColor = Color.White;
                dataGridView1.Rows[OriginObj.X].Cells[OriginObj.Y].Style.BackColor = Color.White;

                CheckedDayList[_id] = obj;
                return;
            }


            if (value)
            {
                var result = CheckedDayList.Where(x => x.Day == obj.Day && x.X == obj.X && x.Y == obj.Y).FirstOrDefault();
                CheckedDayList.Remove(result);
                dataGridView1.Rows[obj.X].Cells[obj.Y].Style.SelectionBackColor = Color.White;
                dataGridView1.Rows[obj.X].Cells[obj.Y].Style.BackColor = Color.White;
            }

            else
            {
                CheckedDayList.Add(obj);
            }
            var testlit2 = CheckedDayList;
        }

        public void DrawGrid()
        {
            if (CheckedDayList.Count > 0)
            {
                var currentGrid = CheckedDayList.Where(d => d.Day >= CurrentWeekDays[0] && d.Day <= CurrentWeekDays[CurrentWeekDays.Count - 1]).ToList();

                foreach (var item in currentGrid)
                {
                    dataGridView1.Rows[item.X].Cells[item.Y].Style.SelectionBackColor = Color.Red;
                    dataGridView1.Rows[item.X].Cells[item.Y].Style.BackColor = Color.Red;
                }
            }
            else
                return;                
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
            if(!DictDate.ContainsKey(Pagenumber))
            DictDate.Add(Pagenumber, DictionaryValues);
            Pagenumber = Pagenumber + 1;
           // MessageBox.Show(Pagenumber.ToString());
        }


        public void BackClickSaveDictionary(Dictionary<int, List<DateTime>> DictDate)
        {
            //MessageBox.Show("BackClickSaveDictionary" + Pagenumber.ToString());
            List<DateTime> DictionaryValues = new List<DateTime>();
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

            var DatestringFromGridclass = CheckedDayList.Select(x => x.Day).ToList();
            Dates = DatestringFromGridclass;


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
                CheckedDayList.Sort();
                archeuligrafiki.DataSource = CheckedDayList;
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
            #region OldCode
            //DICTIONARIS SHESAVSEBAD
            //Datefiller(DateDic);

            //dataGridView1.Rows.Clear();
            //grafiki();
            //CurrentMonday = CurrentMonday.AddDays(7);
            //AssignCurrentWeek(CurrentMonday);
            //lblBack.Enabled = true;
            //lblBack.ForeColor = Color.DarkSlateGray;
            //lblBack.Cursor = Cursors.Hand;

            //gridFillter(dataGridView1, CurrentMonday);
            ////DICTIONARIS WASAKITXTAD
            //DatefillFront(DateDic);

            //CellGrayColor(dateTimePicker1.Value, dateTimePicker3.Value); 
            #endregion

            dataGridView1.Rows.Clear();
            grafiki();
            CurrentMonday = CurrentMonday.AddDays(7);
            AssignCurrentWeek(CurrentMonday);

            gridFillter(dataGridView1, CurrentMonday);

            DrawGrid();

        }

        private void lblBack_Click_2(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            grafiki();
            CurrentMonday = CurrentMonday.AddDays(-7);
            AssignCurrentWeek(CurrentMonday);

            if (CurrentMonday == ThisMonday)
            {
                lblBack.Enabled = true;
                GetCellColorToday();
            }
            gridFillter(dataGridView1, CurrentMonday);
            DrawGrid();

            #region OldCode
            //// MessageBox.Show("SHEMOSVLA 1" + Pagenumber.ToString());
            //BackClickSaveDictionary(DateDic);
            //dataGridView1.Rows.Clear();
            //grafiki();
            //CurrentMonday = CurrentMonday.AddDays(-7);
            //AssignCurrentWeek(CurrentMonday);


            //if (CurrentMonday == ThisMonday)
            //{
            //    lblBack.Enabled = true;
            //    //lblBack.ForeColor = Color.Gray;
            //    //lblBack.Cursor = Cursors.No;
            //    //CellGrayColor(DateTime.Now.Date);
            //    GetCellColorToday();
            //}

            ////CellGrayColor(dateTimePicker1.Value, dateTimePicker3.Value);

            //gridFillter(dataGridView1, CurrentMonday);
            //// MessageBox.Show("SHEMOSVLA 2 " + Pagenumber.ToString());
            //Datefiller(DateDic, 1.5);
            #endregion
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

        public void SubscribtionEditMethod()
        {
            try
            {
                var subscriptionByID = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>().Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault();
                var newobj = subscriptionByID;
                var subscriber = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscriber>().Where(x => x.SubscribtionID == subscriptionByID.Id).FirstOrDefault();

                var ScheduleList = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>()
                   .Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault()
                   .SubscribtionSchedule_.OrderBy(x => x.Schedule.Date).ToList();
                List<DateTime> Dateeeslist = new List<DateTime> ();

                foreach (var item in ScheduleList)
                {
                    Dateeeslist.Add(item.Schedule);
                }


                var cdl = CheckedDayList;
                List<SubscriptionScheduleDB> NewScheduleList = new List<SubscriptionScheduleDB>();

                foreach (var item in cdl)
                {
                           if (Dateeeslist.Contains(item.Day))
                        {
                            SubscriptionScheduleDB NewSchedule = new SubscriptionScheduleDB { Id=item.Id,  Attandance = (int)ScheduleList[Dateeeslist.IndexOf(item.Day)].Attandance,
                                Schedule = ScheduleList[Dateeeslist.IndexOf(item.Day)].Schedule,
                                Subscription = ScheduleList[Dateeeslist.IndexOf(item.Day)].Subscription,
                                SubscriptionID = ScheduleList[Dateeeslist.IndexOf(item.Day)].SubscriptionID };
                  //      DatabaseConnection.Conn.Update(NewSchedule);        
                            NewScheduleList.Add(NewSchedule);
                        }
                                               else
                        {
                            SubscriptionScheduleDB NewSchedule = new SubscriptionScheduleDB { Attandance = 0, Schedule=item.Day,
                                Subscription = ScheduleList[0].Subscription, SubscriptionID= ScheduleList[0].SubscriptionID };
                    //DatabaseConnection.Conn.Insert(NewSchedule);
                           NewScheduleList.Add(NewSchedule);
                        }




                }

                foreach (var item in ScheduleList)
                {
                    DatabaseConnection.Conn.Delete(item);
                }
                foreach (var item in NewScheduleList)
                {
                    DatabaseConnection.Conn.Insert(item);

                }


                subscriber.Subscriptions.SubscribtionSchedule_ = NewScheduleList;


                subscriber.Name = saxeli.Text;
                subscriber.LastName = gvari.Text;
                subscriber.PhoneNumber = telefoni.Text;
                subscriber.Address = misamarti.Text;
                //   subscriber.DateOfBirth = asaki.ToString();

                //if (diax.Checked)
                //    subscriber.Healthnotice[0].YesNO =Availability.Yes;
                //else
                //    subscriber.Healthnotice[0].YesNO = Availability.No;


                DatabaseConnection.Conn.UpdateWithChildren(subscriber);
                //DatabaseConnection.Conn.UpdateWithChildren(newobj);


                //foreach (var item in NewScheduleList)
                //{
                //    DatabaseConnection.Conn.Insert(item);
                //}


                //var SelectedObject = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>().Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault();

                //var SelectAllSchedule = DatabaseConnection.Conn.GetAllWithChildren<SubscriptionScheduleDB>()
                //    .FindAll(x => x.SubscriptionID == SelectedObject.Id);

                //#region giorgim ikarnaxa

                //for (int i = 0; i < SelectAllSchedule.Count; i++)
                //{

                //    var g = SelectAllSchedule[i].Schedule;
                //    // CheckedDayList[i] = g;
                //}

//#endregion

                //var SelectedObject = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>().Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault();

                //var SelectAllSchedule = DatabaseConnection.Conn.GetAllWithChildren<SubscriptionScheduleDB>()
                //    .FindAll(x => x.SubscriptionID == SelectedObject.Id);




//#endregion







                //for (int i = 0; i < CheckedDayList.Count; i++)
                //{
                //    //როცა ნაკლებია ბაზაში არსებული დინამიურზე, სანამ ბაზის რაოდენობა შეივსება ვუტოლებთ, როცა შეივსება ვამატებთ
                //    if(ScheduleList.Count<CheckedDayList.Count)
                //    {

                //       while (i != ScheduleList.Count);
                //        ScheduleList[i].Schedule = CheckedDayList[i].Day;

                //        SubscriptionScheduleDB _Shchedule = new SubscriptionScheduleDB
                //        {
                //            Attandance = ScheduleList[i - 1].Attandance,
                //            Subscription = ScheduleList[i - 1].Subscription,
                //            SubscriptionID = ScheduleList[i - 1].SubscriptionID,
                //            Schedule = CheckedDayList[i].Day
                //        };

                //        ScheduleList.Add(_Shchedule);



                //    }
                //    //როცა რაოდენობრივად ტოლია, პირდაპირ ვუტოლებთ
                //    else if(ScheduleList.Count == CheckedDayList.Count)
                //    ScheduleList[i].Schedule = CheckedDayList[i].Day;
                //    //როცა ბაზის მონაცემები მეტია დინამიურზე, რაც დარჩა ზედმეტი ბაზაში იშლება
                //    //აქ შეცდომის დაშვების ალბათობა მაღალია, მივუბრუნდე, რა ხდება თუ საწყის ელემენტებს შლის და არა საბოლოოს?
                //    else
                //    {
                //        while (i!= ScheduleList.Count) ;
                //        ScheduleList[i].Schedule = CheckedDayList[i].Day;
                //        ScheduleList.RemoveRange(i, ScheduleList.Count - CheckedDayList.Count);

                //    }





                //}

                //________________________შოთას კოდის დასასრული დასაწერია ბოლოს UPDATE


                //subscriptionByID.SubscribtionSchedule_ = new List<SubscriptionScheduleDB>();

                //foreach (var item in CheckedDayList)
                //{
                //    SubscriptionScheduleDB Shchedule = new SubscriptionScheduleDB { Schedule = item.Day };
                //    subscriptionByID.SubscribtionSchedule_.Add(Shchedule);
                //}



                var guliko = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>().SingleOrDefault(x => x.IDnumber == "A001");
                var gggg = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscriber>().FirstOrDefault(x => x.SubscribtionID == 1);


            }

            catch
            {
                MessageBox.Show("დაამატეთ საათების რაოდენობა");


            }
            Form1 form = new Form1();
            Close();
            form.Refresh();




        }








        public void SubscribtionEditMethod(string AbonimentNumber)
        {
            try
            {
                var subscriptionByID = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>().Where(x => x.IDnumber == AbonimentNumber).FirstOrDefault();
                var newobj = subscriptionByID;
                var subscriber = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscriber>().Where(x => x.SubscribtionID == subscriptionByID.Id).FirstOrDefault();

                var ScheduleList = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>()
                   .Where(x => x.IDnumber == AbonimentNumber).FirstOrDefault()
                   .SubscribtionSchedule_.OrderBy(x => x.Schedule.Date).ToList();
                List<DateTime> Dateeeslist = new List<DateTime>();

                foreach (var item in ScheduleList)
                {
                    Dateeeslist.Add(item.Schedule);
                }


                var cdl = CheckedDayList;
                List<SubscriptionScheduleDB> NewScheduleList = new List<SubscriptionScheduleDB>();

                foreach (var item in cdl)
                {
                    if (Dateeeslist.Contains(item.Day))
                    {
                        SubscriptionScheduleDB NewSchedule = new SubscriptionScheduleDB
                        {
                            Id = item.Id,
                            Attandance = (int)ScheduleList[Dateeeslist.IndexOf(item.Day)].Attandance,
                            Schedule = ScheduleList[Dateeeslist.IndexOf(item.Day)].Schedule,
                            Subscription = ScheduleList[Dateeeslist.IndexOf(item.Day)].Subscription,
                            SubscriptionID = ScheduleList[Dateeeslist.IndexOf(item.Day)].SubscriptionID
                        };
                        //      DatabaseConnection.Conn.Update(NewSchedule);        
                        NewScheduleList.Add(NewSchedule);
                    }
                    else
                    {
                        SubscriptionScheduleDB NewSchedule = new SubscriptionScheduleDB
                        {
                            Attandance = 0,
                            Schedule = item.Day,
                            Subscription = ScheduleList[0].Subscription,
                            SubscriptionID = ScheduleList[0].SubscriptionID
                        };
                        //DatabaseConnection.Conn.Insert(NewSchedule);
                        NewScheduleList.Add(NewSchedule);
                    }




                }

                foreach (var item in ScheduleList)
                {
                    DatabaseConnection.Conn.Delete(item);
                }
                foreach (var item in NewScheduleList)
                {
                    DatabaseConnection.Conn.Insert(item);

                }


                subscriber.Subscriptions.SubscribtionSchedule_ = NewScheduleList;


                subscriber.Name = saxeli.Text;
                subscriber.LastName = gvari.Text;
                subscriber.PhoneNumber = telefoni.Text;
                subscriber.Address = misamarti.Text;
                //   subscriber.DateOfBirth = asaki.ToString();

                //if (diax.Checked)
                //    subscriber.Healthnotice[0].YesNO =Availability.Yes;
                //else
                //    subscriber.Healthnotice[0].YesNO = Availability.No;


                DatabaseConnection.Conn.UpdateWithChildren(subscriber);
                //DatabaseConnection.Conn.UpdateWithChildren(newobj);


                //foreach (var item in NewScheduleList)
                //{
                //    DatabaseConnection.Conn.Insert(item);
                //}




                //var SelectedObject = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>().Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault();

                //var SelectAllSchedule = DatabaseConnection.Conn.GetAllWithChildren<SubscriptionScheduleDB>()
                //    .FindAll(x => x.SubscriptionID == SelectedObject.Id);

                //#region giorgim ikarnaxa

                //for (int i = 0; i < SelectAllSchedule.Count; i++)
                //{

                //    var g = SelectAllSchedule[i].Schedule;
                //    // CheckedDayList[i] = g;
                //}

                //#endregion













                //for (int i = 0; i < CheckedDayList.Count; i++)
                //{
                //    //როცა ნაკლებია ბაზაში არსებული დინამიურზე, სანამ ბაზის რაოდენობა შეივსება ვუტოლებთ, როცა შეივსება ვამატებთ
                //    if(ScheduleList.Count<CheckedDayList.Count)
                //    {

                //       while (i != ScheduleList.Count);
                //        ScheduleList[i].Schedule = CheckedDayList[i].Day;

                //        SubscriptionScheduleDB _Shchedule = new SubscriptionScheduleDB
                //        {
                //            Attandance = ScheduleList[i - 1].Attandance,
                //            Subscription = ScheduleList[i - 1].Subscription,
                //            SubscriptionID = ScheduleList[i - 1].SubscriptionID,
                //            Schedule = CheckedDayList[i].Day
                //        };

                //        ScheduleList.Add(_Shchedule);



                //    }
                //    //როცა რაოდენობრივად ტოლია, პირდაპირ ვუტოლებთ
                //    else if(ScheduleList.Count == CheckedDayList.Count)
                //    ScheduleList[i].Schedule = CheckedDayList[i].Day;
                //    //როცა ბაზის მონაცემები მეტია დინამიურზე, რაც დარჩა ზედმეტი ბაზაში იშლება
                //    //აქ შეცდომის დაშვების ალბათობა მაღალია, მივუბრუნდე, რა ხდება თუ საწყის ელემენტებს შლის და არა საბოლოოს?
                //    else
                //    {
                //        while (i!= ScheduleList.Count) ;
                //        ScheduleList[i].Schedule = CheckedDayList[i].Day;
                //        ScheduleList.RemoveRange(i, ScheduleList.Count - CheckedDayList.Count);

                //    }





                //}

                //________________________შოთას კოდის დასასრული დასაწერია ბოლოს UPDATE


                //subscriptionByID.SubscribtionSchedule_ = new List<SubscriptionScheduleDB>();

                //foreach (var item in CheckedDayList)
                //{
                //    SubscriptionScheduleDB Shchedule = new SubscriptionScheduleDB { Schedule = item.Day };
                //    subscriptionByID.SubscribtionSchedule_.Add(Shchedule);
                //}



                var guliko = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>().SingleOrDefault(x => x.IDnumber == "A001");
                var gggg = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscriber>().FirstOrDefault(x => x.SubscribtionID == 1);


            }

            catch
            {
                MessageBox.Show("დაამატეთ საათების რაოდენობა");


            }
            Form1 form = new Form1();
            Close();
            form.Refresh();




        }







        private void button2_Click_1(object sender, EventArgs e)
        {
            SubscribtionEditMethod();


        }

        private void ara_CheckedChanged(object sender, EventArgs e)
        {
            if (ara.Checked)
                diax.Checked = false;
        }

        private void diax_CheckedChanged(object sender, EventArgs e)
        {
            if (diax.Checked)
                ara.Checked = false;
        }

        private void buttonVadagas_Click(object sender, EventArgs e)
        {
            SubscribtionEditMethod(AbonimentisnomeriVdagasulebidan);
            Form4 F = new Form4();
            F.Show();
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

