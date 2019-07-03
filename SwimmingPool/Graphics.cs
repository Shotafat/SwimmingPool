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

        Dictionary<DataGridView, List<GridFormat>> HelperDict = new Dictionary<DataGridView, List<GridFormat>>();
        Helper h = new Helper();
        List<GridFormat> CheckedDayList = new List<GridFormat>();
        string DatagridviewName;

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

            DrawGrid(HelperDict);
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

            DrawGrid(HelperDict);
        }

        public void SetDefaultGridColor(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            ////grid.DataSource = null;
            //grid.Rows[0].DefaultCellStyle.SelectionBackColor = Color.Snow;
            //grid.Rows[0].DefaultCellStyle.SelectionForeColor = Color.DodgerBlue;
        }

        public void GridCellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void DrawGrid(Dictionary<DataGridView, List<GridFormat>> dic)
        {
            if (dic.Count > 0)
            {
                //  var currentGrid = CheckedList.Where(d => d.Day >= abonent.CurrentWeekDays[0] && d.Day <= abonent.CurrentWeekDays[abonent.CurrentWeekDays.Count - 1]).ToList();

                foreach (var item in dic)
                {
                    var dd_Mon = Convert.ToDateTime(item.Key.Rows[0].Cells[1].Value);
                    var dd_Sun = Convert.ToDateTime(item.Key.Rows[0].Cells[7].Value);
                    var CheckedDays = item.Value.Where(d => d.Day.DayOfYear >= dd_Mon.DayOfYear && d.Day.DayOfYear < dd_Sun.DayOfYear).ToList();

                    foreach (var days in CheckedDays)
                    {
                        item.Key.Rows[days.X].Cells[days.Y].Style.SelectionBackColor = Color.DarkSlateGray;
                        item.Key.Rows[days.X].Cells[days.Y].Style.BackColor = Color.DarkSlateGray;
                        item.Key.Rows[days.X].Cells[days.Y].Style.ForeColor = Color.White;
                        item.Key.Rows[days.X].Cells[days.Y].Style.SelectionForeColor = Color.White;
                    }
                }
            }
            else
                return;
        }

        private void DatagridClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView DGV = sender as DataGridView;

            if (DGV.Columns[e.ColumnIndex].HeaderText == "კვირა")
            {
                DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].DataGridView.DefaultCellStyle.SelectionBackColor = Color.White;
                DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                return;
            }
            if (e.ColumnIndex != 0 && e.RowIndex != 0)
            {
                if (DatabaseConnection.Conn.Table<SPSQLite.CapacityDB>().Last().MaximumCapacity <= Convert.ToInt16(DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    MessageBox.Show("ლიმიტი ამოწურულია");
                }
            }

            //   abonent.AssignCurrentWeek(ThisMonday);
            if (e.ColumnIndex != 0 && e.RowIndex != 0)
            {
                var r = e.RowIndex;
                var c = e.ColumnIndex;

                int Hour = (e.RowIndex + 8);
                var Date = DGV.Rows[0].Cells[e.ColumnIndex];
                var day = Convert.ToDateTime(Date.FormattedValue.ToString());
                DateTime FinalDate = new DateTime();
                string _FinalDate = "";
                if (Hour < 10)
                {
                    _FinalDate = $"{day.ToString("dd/MM/yyyy")} 0{Hour}:00";
                }
                else
                {
                    _FinalDate = $"{day.ToString("dd/MM/yyyy")} {Hour}:00";
                }

                //       MessageBox.Show("წინ ROW " + cell.RowIndex + " COLINDEX: " + cell.ColumnIndex + " " + _FinalDate + " SIGRDZE " + dataGridView1.SelectedCells.Count);

                FinalDate = DateTime.ParseExact(_FinalDate, "dd/MM/yyyy HH:mm", CultureInfo.CurrentUICulture);
                //   Dates.Add(FinalDate);
                //________________________

                GridFormat f = new GridFormat();

                f.X = e.RowIndex;
                f.Y = e.ColumnIndex;
                f.Day = FinalDate;
                f.IsChecked = true;

                var K = HelperDict.FirstOrDefault(k => k.Key == DGV);

                if (K.Key == null)
                {
                    var list = new List<GridFormat>();
                    list.Add(f);
                    HelperDict.Add(DGV, list);
                    var obj = HelperDict.Where(g => g.Key == DGV).Select(v => v.Value);

                    DGV.Rows[f.X].Cells[f.Y].Style.SelectionBackColor = Color.DarkSlateGray;
                    DGV.Rows[f.X].Cells[f.Y].Style.ForeColor = Color.White;
                }

                else
                {
                    var item = HelperDict.Where(g => g.Key == DGV).Select(v => v.Value);
                    foreach (var i in item)
                    {
                    bool value = i.Any(o => o.Day.DayOfYear == f.Day.DayOfYear && o.Y == f.Y && o.X == f.X);
                    bool value2 = i.Any(x => x.Day.DayOfYear == f.Day.DayOfYear && x.Y == f.Y && x.X != f.X);

                    if (value2)
                    {
                        var OriginObj = i.Where(x => x.Day.DayOfYear == f.Day.DayOfYear && x.Y == f.Y && x.X != f.X).FirstOrDefault();
                        var _id = i.IndexOf(OriginObj);

                        DGV.Rows[OriginObj.X].Cells[OriginObj.Y].Style.SelectionBackColor = Color.White;
                        DGV.Rows[OriginObj.X].Cells[OriginObj.Y].Style.BackColor = Color.White;
                        DGV.Rows[OriginObj.X].Cells[OriginObj.Y].Style.ForeColor = Color.Gray;
                        DGV.Rows[OriginObj.X].Cells[OriginObj.Y].Style.SelectionForeColor = Color.Gray;

                        i[_id] = f;
                        return;
                    }

                    else if (value)
                    {
                        var result = i.Where(x => x.Day.DayOfYear == f.Day.DayOfYear && x.X == f.X && x.Y == f.Y).FirstOrDefault();
                        i.Remove(result);
                        if (f.X != -1)
                        {
                            DGV.Rows[f.X].Cells[f.Y].Style.SelectionBackColor = Color.White;
                            DGV.Rows[f.X].Cells[f.Y].Style.BackColor = Color.White;
                            DGV.Rows[f.X].Cells[f.Y].Style.ForeColor = Color.Gray;
                            DGV.Rows[f.X].Cells[f.Y].Style.SelectionForeColor = Color.Gray;
                        }
                    }

                    else
                    {
                        i.Add(f);
                    }
                 }

             }
                //DGV.Rows[f.X].Cells[f.Y].Style.SelectionBackColor = Color.DarkSlateGray;
                //DGV.Rows[f.X].Cells[f.Y].Style.ForeColor = Color.White;

         }
            var testDic = HelperDict;
            DrawGrid(HelperDict);
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
            //AbonentisKonstruqtorisDeitebi();
            this.Close();
            DateTime DD = Convert.ToDateTime("01/01/1980 12:00");
            var subscriptionByID = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>().Where(x => x.IDnumber == "A001").FirstOrDefault();

            List<GridFormat> AbonentzeGadasacemad = new List<GridFormat>();
            foreach (var item in HelperDict.Select(x => x.Value))
            {
                AbonentzeGadasacemad.AddRange(item);
            }

            //var AbonentzeGadasacemad = HelperDict.Select(x => x.Value).FirstOrDefault();
            List<DateTime> list = new List<DateTime>(); 
            list.AddRange(AbonentzeGadasacemad.Select(x=>x.Day));
            list.Sort();

            //AbonentzeGadasacemad = AbonentzeGadasacemadGridFormat.Select(x => x.Day).ToList();
            if (list.Count > 0)
            {
                AddAbonent Shota = new AddAbonent("", "", "", "", DD, "", subscriptionByID, list, list.Count, true, true);
                Shota.CheckedDayList = AbonentzeGadasacemad.Select(x=>x).OrderBy(y=>y.Day).ToList();
                Shota.DrawGrid();

                Form1 form = new Form1();
                Shota.ShowDialog();
                if (Shota.DialogResult == DialogResult.OK)
                {
                    form.initData();
                }
            }
            else
            {
                AddAbonent Shota = new AddAbonent();
                Form1 form = new Form1();
                Shota.ShowDialog();
                if (Shota.DialogResult == DialogResult.OK)
                {
                    form.initData();
                }
            }
        }
    }

    public class Helper
    {
        public DataGridView grid { get; set; } = new DataGridView();
        public List<GridFormat> GridCheckedObj { get; set; } = new List<GridFormat>();
    }
}
