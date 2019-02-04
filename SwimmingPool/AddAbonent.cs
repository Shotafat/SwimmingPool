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
        public Dictionary<int, int> table = new Dictionary<int, int>();

        #region Nika 1.0
        public List<int> AbonentHours { get; set; }
        public List<DateTime> CurrentWeekDays { get; set; } = new List<DateTime>();
        public List<DateTime> SelectedDays { get; set; } = new List<DateTime>();
        public int SelectedCellCount;
        public int SelectedHour;
        public int SelectedCellIndex;
        public DateTime CurrentMonday;
        public DateTime ThisMonday;
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

            ThisMonday = DateTime.Now;
            while (ThisMonday.DayOfWeek != DayOfWeek.Monday)
            {
                ThisMonday = ThisMonday.AddDays(-1);
            }

            CurrentMonday = ThisMonday;

            AssignCurrentWeek(CurrentMonday);
            dataGridView1.Rows[0].ReadOnly = true;
            dataGridView1.Rows[0].Frozen = true;
            dataGridView1.Rows[0].Cells[1].ReadOnly = true;
            #endregion

            gridFillter(dataGridView1, ThisMonday);
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
                dataGridView1.Rows[0].Cells[i].DataGridView.ForeColor = Color.BlueViolet;
                // dataGridView1.Rows[1].ReadOnly = true;
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
            if (ara.Checked)
            {
                diax.Enabled = false;
            }
            else
            {
                diax.Enabled = true;
            }

            if (diax.Checked)
            {
                ara.Enabled = false;
            }
            else
            {
                ara.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            bool sell = columni.Contains(e.ColumnIndex);
            bool rov = rovsi.Contains(e.RowIndex);

            if (sell && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor != Color.Green)
            {
                return;
            }
            else
            {

                //rovsi.Add(e.RowIndex);
                if (e.ColumnIndex <= 0)
                {
                    return;
                }

                string columnName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                string rowName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var value = columnName + " - " + rowName;

                bool cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValueType.IsSealed;

                Color feri = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].DataGridView.DefaultCellStyle.BackColor;

                if (cellValue && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Green)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = feri;
                    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Snow;
                    dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Gray;
                    columni.Remove(e.ColumnIndex);
                    ganrigidge.Remove(value);
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                    //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Teal;
                    //dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Gray;
                    columni.Add(e.ColumnIndex);
                    ganrigidge.Add(value);
                }

                /*from Nika*/
                SelectedCellCount++;
                //MessageBox.Show(SelectedCellCount.ToString());

                NotEqual(SelectedCellCount, SelectedHour);

                SelectedCellIndex = dataGridView1.CurrentCell.ColumnIndex - 1;
                //PushDays(CurrentWeekDays[SelectedCellIndex]);

                archeuligrafiki.DataSource = null;
                archeuligrafiki.DataSource = ganrigidge;
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
            QuantityCounter.Quantity=QuantityCounter.QuantityIncrementer();
                       string SubscribtionNumber = string.Format("A" + "{0:000}", QuantityCounter.Quantity);
            subscribtion.IDnumber = SubscribtionNumber;
            
            return subscribtion;
        }




        public void SubscribtionPriceToDropdown()
        {
            var SubscribtionPriceObject = ServiceInstances.Service().GetSubscriptionPriceServices().GetData().ToList();
            var Hour = (from o in SubscribtionPriceObject select new  { Hours = o.NumberOfHours }).ToList();

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

            MessageBox.Show(subscription.IDnumber);


           // insertSubscribtion(ISubscription subscription_, ISubscriber  subscriber_, ISubscriptionPrice subscriberprice)

            // ბაზაში ჩაწერა ფასის აბონენტის და აბონიმენტის
       
          //  ServiceInstances.Service().GetSubscriptionPriceServices().Add(SubPrice);
            DatabaseConnection.insertSubscribtion(subscriber, SubPrice, subscription);
                                          
            //  MessageBox.Show("SAXELI " +subscriber.Name + " " + subscriber.LastName+" PRICE "+SubPrice.NumberOfHours +" ABID "+ subscription.IDnumber);


        }

        //ES METHODI DASAWERIA, AXLA SATESTOA


        //insertSubscribtion(ISubscription subscription_, ISubscriber  subscriber_, ISubscriptionPrice subscriberprice)

        //Methodebis mimdevroba
        // 1 Subscriber
        //2 SubscribtionPrice
        //3 HealthNotice  <<dasakavshirebelia Subscriber-Tan
        // 4 Subscription <<dasakavshirebelia Subscriber da SubscribtionPrice-tan
        //5 SubscriptionScheduleDB << dasakavshirebelia Subscriber-tan


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






        private void shenaxva_Click(object sender, EventArgs e)
        {
            //string gela = asaki.Text;
            //DateTime gela1 = DateTime.ParseExact(gela, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            //var gelag = ServiceInstances.Service().CreateObjectForSub( saxeli.Text, gvari.Text, gela1, telefoni.Text, misamarti.Text);

            //ServiceInstances.Service().GetSubscriberService().Add(gelag);
            Saver();
            DialogResult = DialogResult.OK;
            Close();


        }
    }
}
