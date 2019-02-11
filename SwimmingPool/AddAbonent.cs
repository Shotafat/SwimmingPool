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

namespace SwimmingPool
{

    public partial class AddAbonent : Form
    {
        public List<string> ganrigidge = new List<string>();
        public List<int> columni = new List<int>();
        public List<int> rovsi = new List<int>();
        private int daynumber = Convert.ToInt16(DateTime.Now.DayOfWeek);

        #region Nika 1.0
        public List<int> AbonentHours { get; set; }
        public List<DateTime> CurrentWeekDays { get; set; } = new List<DateTime>();
        public List<DateTime> SelectedDays { get; set; } = new List<DateTime>();
        public int SelectedCellCount;
        public int SelectedHour;
        public int SelectedCellIndex;
        public DateTime ThisMonday { get; set; }
        public DateTime CurrentMonday { get; set; }

        #endregion

        public AddAbonent()
        {
            InitializeComponent();
  

            grafiki();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ka-GE"));

            #region Nika 1.1
            //AbonentHours = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            //cmbxHour.DataSource = AbonentHours;

            SubscribtionPriceToDropdown();
            SelectedCellCount = 0;
            lblBack.Cursor = Cursors.No;
            lblBack.Enabled = false;

            /*function for calc current monday*/

            ThisMonday = GetCurrentMonday(DateTime.Now.Date);

            AssignCurrentWeek(ThisMonday);
            dataGridView1.Rows[0].ReadOnly = true;
            dataGridView1.Rows[0].Frozen = true;
            dataGridView1.Rows[0].Cells[1].ReadOnly = true;
            #endregion

            gridFillter(dataGridView1, ThisMonday);
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

        public AddAbonent(ISubscriber subscriber) : this()
        {
            if (subscriber != null)
            {
                label6.Text = "რ" + " " + "ე" + " " + "დ" + " " + "ა" + " " + "ქ" + " " + "ტ" + " " + "ი" + " " + "რ" + " " + "ე" + " " + "ბ" + " " + "ა";

                saxeli.Text = subscriber.Name;
                gvari.Text = subscriber.LastName;
                asaki.Text = subscriber.DateOfBirth.ToString();
                telefoni.Text = subscriber.PhoneNumber;
                misamarti.Text = subscriber.Adress;
                shenaxva.Text = "რედაქტირება";
                //lblAnonimentNumber.Visible = abonenti.Visible = false;

            }

        }

        #region Nika 1.3
        /*from Nika*/
        public void AssignCurrentWeek(DateTime CurrentMonday)
        {
            CurrentWeekDays.Clear();
            //dataGridView1.Rows.Add();
            for (int i = 1; i < 7; i++)
            {
                CurrentWeekDays.Add(CurrentMonday.AddDays(i - 1));
                dataGridView1.Rows[0].Cells[i].Value = CurrentWeekDays[i - 1].ToString("dd MMMM");
                dataGridView1.Rows[0].Cells[i].Style.ForeColor = Color.DodgerBlue;
                // dataGridView1.Rows[1].ReadOnly = true;
            }

            CellGrayColor(CurrentMonday);
        }


        public void CellGrayColor(DateTime day)
        {
            if (CurrentWeekDays.Contains(day) && day.Date < DateTime.Now.Date)
            {
                for (int i = 0; i < daynumber; i++)
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


        /*from Nika*/
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
        #endregion

        public void gridFillter(DataGridView SubscriberSchedul, DateTime Start)
        {

            DateTime End = Start.AddDays(6 - (int)Start.DayOfWeek);
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
                //for (int i = 0; i < InputMethods.DATAforInput.Count; i++)

                SubscriberSchedul.Rows[item.Date.Hour - 8].Cells[(int)item.Date.Date.DayOfWeek].Value = item.Datelist.ToString();   //item.DatainputList[i].Datelist.ToString(); // item.DatainputList[i].Date.ToString()+" "+ 



            }
            //PAST

            foreach (var item in InputMethods.DATAforInputPast)
            {
                //   for (int i = 0; i < InputMethods.DATAforInputPast.Count; i++)
                SubscriberSchedul.Rows[item.Date.Hour - 8].Cells[(int)item.Date.Date.DayOfWeek].Value = item.Datelist.ToString();
            }

            EmptyCellfiller(SubscriberSchedul);

        }

        public void EmptyCellfiller(DataGridView EmptyCell)
        {
            foreach (DataGridViewRow dgRow in EmptyCell.Rows)
            {
                for (int i = 0; i < dgRow.Cells.Count; i++)
                {
                    var cell = dgRow.Cells[i];
                    if (cell.Value == null)   //Check for null reference
                    {
                        //cell.Style.BackColor = string.IsNullOrEmpty(cell.Value.ToString()) ?
                        //    Color.LightCyan :
                        //    Color.Orange;

                        cell.Style.ForeColor = Color.Gray;
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
                    dataGridView1.Rows[i].Cells[ii].DataGridView.DefaultCellStyle.BackColor = Color.Snow;
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

            //CultureInfo provider = new CultureInfo("fr-FR");
            //DateTime start = DateTime.ParseExact("21/01/2019 09:00", "g", provider);     //dateTimePicker1.Value;
            //6-(int)dateTimePicker1.Value.DayOfWeek
            //  DateTime End = dateTimePicker1.Value.AddDays(6 - (int)dateTimePicker1.Value.DayOfWeek);
            //   gridFillter(dataGridView1, DateTime.Now);
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
            var check = (CheckBox)sender;

            if (check.Name == "ara")
            {
                diax.Checked = false;
            }

            else if (check.Name == "diax")
            {
                ara.Checked = false;
            }
        }



        #region Nika
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

        private void cmbxHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedHour = AbonentHours[cmbxHour.SelectedIndex];
        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            grafiki();
            CurrentMonday = CurrentMonday.AddDays(7);
            AssignCurrentWeek(CurrentMonday);
            lblBack.Enabled = true;
            lblBack.ForeColor = Color.LightSkyBlue;
            lblBack.Cursor = Cursors.Hand;

            gridFillter(dataGridView1, CurrentMonday);
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            grafiki();
            CurrentMonday = CurrentMonday.AddDays(-7);
            AssignCurrentWeek(CurrentMonday);

            if (CurrentMonday == ThisMonday)
            {
                lblBack.Enabled = false;
                lblBack.ForeColor = Color.Gray;
                lblBack.Cursor = Cursors.No;
            }

            gridFillter(dataGridView1, CurrentMonday);
        }
        #endregion


        public ISubscription GenerateSubscribtionID(ISubscription subscribtion)
        {
            //Subscription : ISubscription


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
            ISubscriber subscriber = new SPSQLite.CLASSES.Subscriber();
            ISubscriptionPrice SubPrice = new SubcsriptionPrice();
            ISubscription subscription = new SPSQLite.CLASSES.Subscription();
            subscriber = subscriberSaver();
            SubPrice = SubPriceReturner();
            subscription = GenerateSubscribtionID(subscription);
            IHealthNotice healthNotice = HealthNoticeSaver();
            //ServiceInstances.Service().GetHealthNoticeServices().Add(healthNotice);
            //InsertHealthNotice(healthNotice_);
            DatabaseConnection.insertSubscribtion(subscriber, SubPrice, subscription, healthNotice);

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
            DateTime DateOfBirth = DateTime.ParseExact(Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //var Subscriber = ServiceInstances.Service().CreateObjectForSub(saxeli.Text, gvari.Text, DateOfBirth, telefoni.Text, misamarti.Text);
            SPSQLite.CLASSES.Subscriber subscriber = new SPSQLite.CLASSES.Subscriber { Name = saxeli.Text, LastName = gvari.Text, DateOfBirth = DateOfBirth, PhoneNumber = telefoni.Text, Adress = misamarti.Text };

            //ServiceInstances.Service().GetSubscriberService().Add(subscriber);

            return subscriber;

        }

        //SubcsriptionPrice : ISubscriptionPrice
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
            Saver();






            var nino = ServiceInstances.Service().GetSubscriptionScheduleServices().GetData();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            AssignCurrentWeek(GetCurrentMonday(dateTimePicker1.Value));
            //CellGrayColor();
        }

        private void lblNext_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            grafiki();
            CurrentMonday = CurrentMonday.AddDays(7);
            AssignCurrentWeek(CurrentMonday);
            lblBack.Enabled = true;
            lblBack.ForeColor = Color.LightSkyBlue;
            lblBack.Cursor = Cursors.Hand;

            gridFillter(dataGridView1, CurrentMonday);
        }

        private void lblBack_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            grafiki();
            CurrentMonday = CurrentMonday.AddDays(-7);
            AssignCurrentWeek(CurrentMonday);

            if (CurrentMonday == ThisMonday)
            {
                lblBack.Enabled = false;
                lblBack.ForeColor = Color.Gray;
                lblBack.Cursor = Cursors.No;
            }

            gridFillter(dataGridView1, CurrentMonday);
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                int ColumnIndex = e.ColumnIndex;
                int Hour = (e.RowIndex + 8)
                     ;

                //var g = TimeSpan.Parse(Hour);
                var Date = CurrentWeekDays[0 + ColumnIndex - 1];
                ISubscriptionSchedule gela = new SubscriptionSchedule();




                var guliko = ServiceInstances.Service().GetSubscriptionServices().GetData().FirstOrDefault(x => x.ID == gela.ID);

                //(g.ID == gela.ID)


                ServiceInstances.Service().GetSubscriptionScheduleServices().Add(gela);

                Color green = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;
                //
                //   DateTime InsertDate = DateTime.ParseExact(, "hh/mm/yyyy", CultureInfo.InvariantCulture);





                //     DateTime guliko = DateTime.Parse(FinalDate);
                //


                if (green == Color.LightGray || green == Color.Snow)
                {
                    dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.LightGray;
                    dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
                    return;
                }
                if (e.ColumnIndex == 0 || e.RowIndex == 0)
                {
                    dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Snow;
                    dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.DodgerBlue;
                    return;
                }

                bool sell = columni.Contains(e.ColumnIndex);
                bool rov = rovsi.Contains(e.RowIndex);

                //Color green = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;

                string columnName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                string rowName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = columnName + " - " + rowName;

                bool isselect = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValueType.IsSealed;

                if (sell && isselect && green != Color.Green)
                {
                    dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Snow;
                    dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
                }
                else if (sell && green == Color.Green)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Snow;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Gray;
                    columni.Remove(e.ColumnIndex);
                    ganrigidge.Remove(value);
                }
                else
                {
                    dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Green;
                    dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Gray;
                    columni.Add(e.ColumnIndex);
                    ganrigidge.Add(value);
                }
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

        
    }
}
