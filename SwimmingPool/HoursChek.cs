using SPSQLite.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class HoursChek : UserControl
    {

        public string GetHoursLabel { get { return HoursLabel.Text.ToString(); } set { HoursLabel.Text = value; } }
        public string GetAttendanceLabel { get { return AttendLabel.Text.ToString(); } set { AttendLabel.Text = value; } }
        public string GetAttendanceGela { get { return label1.Text.ToString(); } set { label1.Text = value; } }

        public HoursChek()
        {
            InitializeComponent();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }





        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void HoursLabel_Click(object sender, EventArgs e)
        {

        }

        private void AttendLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void გაცდენაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var miss = (int)AttendanceTypes.გააცდინა;

            BackColor = Color.Red;
            

        }

        private void HoursChek_DoubleClick(object sender, EventArgs e)
        {
            if(BackColor!=Color.Gray)
            BackColor = Color.DarkSlateGray;
        }

        private void დასვენებაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.Teal;
        }
    }
}
