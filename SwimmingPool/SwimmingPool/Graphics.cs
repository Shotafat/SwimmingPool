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
    public partial class Graphics : Form
    {
        public DateTime ThisMonday { get; set; }
        public DateTime MeoreMonday { get; set; }
        public DateTime MesameMonday { get; set; }
        public DateTime MeotxeMonday { get; set; }

        AddAbonent abonent = new AddAbonent();


        public Graphics()
        {
            InitializeComponent();

            MeoreMonday = ThisMonday.AddDays(7);
            MesameMonday = ThisMonday.AddDays(14);
            MeotxeMonday = ThisMonday.AddDays(21);

            dataGridViewFirst.DataSource = null;
            ThisMonday = abonent.GetCurrentMonday(DateTime.Now);

            abonent.grafiki(dataGridViewFirst);
            abonent.grafiki(dataGridView2);
            abonent.grafiki(dataGridView3);
            abonent.grafiki(dataGridViewFourth);

            abonent.gridFillter(dataGridViewFirst, ThisMonday);
            abonent.gridFillter(dataGridView2, MeoreMonday);
            abonent.gridFillter(dataGridView3, MesameMonday);
            abonent.gridFillter(dataGridViewFourth,MeotxeMonday);

            
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
            ThisMonday = ThisMonday.AddMonths(1);

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
            ThisMonday = ThisMonday.AddMonths(-1);

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
            var ContextMenustrip =currStrip.Owner as ContextMenuStrip;
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
    }

    
}
