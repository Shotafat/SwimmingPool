using SPSQLite;
using SPSQLite.CLASSES;
using SPSQLite.CLASSES.BussinessObjects;
using SPSQLite.CLASSES.Services;
using SPSQLite.UIMethods;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class Graphics : Form
    {
        public DateTime ThisMonday { get; set; }
        public DateTime MeoreMonday { get; set; }
        public DateTime MesameMonday { get; set; }
        public DateTime MeotxeMonday { get; set; }
        DateTime DateaA = new DateTime();
        AddAbonent abonent = new AddAbonent() ;
        

        public Graphics()
        {
            InitializeComponent();

            ThisMonday = abonent.GetCurrentMonday(DateTime.Now);
            MeoreMonday = ThisMonday.AddDays(7);
            MesameMonday = ThisMonday.AddDays(14);
            MeotxeMonday = ThisMonday.AddDays(21);

            dataGridViewFirst.DataSource = null;


            abonent.grafiki(dataGridViewFirst);
            abonent.grafiki(dataGridView2);
            abonent.grafiki(dataGridView3);
            abonent.grafiki(dataGridViewFourth);

            abonent.gridFillter(dataGridViewFirst, ThisMonday);
            abonent.gridFillter(dataGridView2, MeoreMonday);
            abonent.gridFillter(dataGridView3, MesameMonday);
            abonent.gridFillter(dataGridViewFourth, MeotxeMonday);


            abonent.AssignCurrentWeek(ThisMonday, dataGridViewFirst);
            abonent.AssignCurrentWeek(MeoreMonday, dataGridView2);
            abonent.AssignCurrentWeek(MesameMonday, dataGridView3);
            abonent.AssignCurrentWeek(MeotxeMonday, dataGridViewFourth);

            //dataGridViewFirst.Rows[1].ReadOnly = true;
            //dataGridViewFirst.Rows[1].Selected = true;

        }

        private void Graphics_Load(object sender, EventArgs e)
        {
            SetDefaultGridColor(sender, e);
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            dataGridViewFirst.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridViewFourth.Rows.Clear();

            ThisMonday = ThisMonday.AddDays(28);

            abonent.grafiki(dataGridViewFirst);
            abonent.grafiki(dataGridView2);
            abonent.grafiki(dataGridView3);
            abonent.grafiki(dataGridViewFourth);

            abonent.gridFillter(dataGridViewFirst, ThisMonday);
            abonent.gridFillter(dataGridView2, ThisMonday.AddDays(7));
            abonent.gridFillter(dataGridView3, ThisMonday.AddDays(14));
            abonent.gridFillter(dataGridViewFourth, ThisMonday.AddDays(21));

            abonent.AssignCurrentWeek(ThisMonday, dataGridViewFirst);
            abonent.AssignCurrentWeek(ThisMonday.AddDays(7), dataGridView2);
            abonent.AssignCurrentWeek(ThisMonday.AddDays(14), dataGridView3);
            abonent.AssignCurrentWeek(ThisMonday.AddDays(21), dataGridViewFourth);
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            dataGridViewFirst.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridViewFourth.Rows.Clear();

            ThisMonday = ThisMonday.AddDays(-28);

            abonent.grafiki(dataGridViewFirst);
            abonent.grafiki(dataGridView2);
            abonent.grafiki(dataGridView3);
            abonent.grafiki(dataGridViewFourth);

            abonent.gridFillter(dataGridViewFirst, ThisMonday);
            abonent.gridFillter(dataGridView2, ThisMonday.AddDays(7));
            abonent.gridFillter(dataGridView3, ThisMonday.AddDays(14));
            abonent.gridFillter(dataGridViewFourth, ThisMonday.AddDays(21));

            abonent.AssignCurrentWeek(ThisMonday, dataGridViewFirst);
            abonent.AssignCurrentWeek(ThisMonday.AddDays(7), dataGridView2);
            abonent.AssignCurrentWeek(ThisMonday.AddDays(14), dataGridView3);
            abonent.AssignCurrentWeek(ThisMonday.AddDays(21), dataGridViewFourth);
        }

        public void SetDefaultGridColor(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            //grid.DataSource = null;
            //grid.Rows[0].DefaultCellStyle.SelectionBackColor = Color.Snow;
            //grid.Rows[0].DefaultCellStyle.SelectionForeColor = Color.DodgerBlue;
        }

        public void GridCellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void DrawGrid(DataGridView A)
        {
            if (abonent.CheckedDayList.Count > 0)
            {
                var currentGrid = abonent.CheckedDayList.Where(d => d.Day >= abonent.CurrentWeekDays[0] && d.Day <= abonent.CurrentWeekDays[abonent.CurrentWeekDays.Count - 1]).ToList();

                foreach (var item in currentGrid)
                {
                    A.Rows[item.X].Cells[item.Y].Style.SelectionBackColor = Color.DarkSlateGray;
                    A.Rows[item.X].Cells[item.Y].Style.BackColor = Color.DarkSlateGray;
                }
            }
            else
                return;
        }


        List<DateTime> AbonentzeGadasacemad = new List<DateTime>();


        private void DatagridClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView DGV = sender as DataGridView;
            DateTime PIRVELI = Convert.ToDateTime(DGV.Rows[0].Cells[1].Value.ToString());
           // MessageBox.Show(PIRVELI.Date.ToString() + " "+ThisMonday.Date.ToString());
            if(PIRVELI.Date== ThisMonday.Date)
                abonent.AssignCurrentWeek(ThisMonday);
            else if(PIRVELI.Date == MeoreMonday.Date)
                abonent.AssignCurrentWeek(MeoreMonday);
            else if (PIRVELI.Date == MesameMonday.Date)
                abonent.AssignCurrentWeek(MesameMonday);
            else
                abonent.AssignCurrentWeek(MeotxeMonday);


            abonent.AssignCurrentWeek(ThisMonday);
            if (e.ColumnIndex != 0 && e.RowIndex != 0)
            {
                int Hour = (e.RowIndex + 8);
                var Date = abonent.CurrentWeekDays[0 + e.ColumnIndex - 1];
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
                var id = abonent.CheckedDayList.Count;
                GridFormat f = new GridFormat(id);
                f.X = e.RowIndex;
                f.Y = e.ColumnIndex;
                f.Day = FinalDate;
                f.IsChecked = true;

                if (abonent.CheckedDayList.Count == 0 && f.X != -1)
                {
                    abonent.CheckedDayList.Add(f);
                    abonent.dataGridView1.Rows[f.X].Cells[f.Y].Style.SelectionBackColor = Color.DarkSlateGray;
                    abonent.dataGridView1.Rows[f.X].Cells[f.Y].Style.ForeColor = Color.White;
                }

                else
                {
                    DrawGrid(DGV);
                    abonent.Checking(f);
                    abonent.DrawGrid(abonent.CurrentWeekDays);
                    
                }


                var lbl = abonent.CheckedDayList.Count();
            //    abonent.lblHours.Text = lbl.ToString();








            }


            AbonentzeGadasacemad = abonent.CheckedDayList.Select(x=>x.Day).ToList();

        }








        public void click(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView DT = sender as DataGridView;

            if (DT.Rows[0].Cells[e.ColumnIndex].Selected ||
                  DT.Rows[e.RowIndex].Cells[0].Selected)
            {
                DT.Rows[0].DefaultCellStyle.SelectionBackColor = Color.Snow;
                DT.Rows[0].DefaultCellStyle.SelectionForeColor = Color.DodgerBlue;


                DT.Rows[0].Cells[e.ColumnIndex].Selected = false;
                return;
            }
        }

        private void აბონენტისრეგისტრაციაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (e.RowIndex == 0)
            //    return;
            ToolStripMenuItem currStrip = sender as ToolStripMenuItem;
            var ContextMenustrip = currStrip.Owner as ContextMenuStrip;
            DataGridView grid = ContextMenustrip.SourceControl as DataGridView;
            DateTime currentMonday;

            if (grid == dataGridViewFirst)
                currentMonday = ThisMonday;
            else if (grid == dataGridView2)
                currentMonday = MeoreMonday;
            else if (grid == dataGridView3)
                currentMonday = MesameMonday;
            else
                currentMonday = MeotxeMonday;

            AddAbonent ab = new AddAbonent(currentMonday);

            ab.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            DateTime DD= Convert.ToDateTime("12/12/1980 12:00");
            var subscriptionByID = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>().Where(x => x.IDnumber == "A001").FirstOrDefault();

            AddAbonent Shota = new AddAbonent("", "", "", "", DD, "", subscriptionByID, AbonentzeGadasacemad, 1);
            abonent.Show();
            
        }
    }


}
