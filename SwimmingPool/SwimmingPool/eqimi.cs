﻿using SPSQLite.CLASSES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class eqimi : Form
    {
        public eqimi()
        {
            InitializeComponent();
        }

        private void shenaxva_Click(object sender, EventArgs e)
        {
            DoctorServices ds = new DoctorServices();
            ds.Add(new Doctor
            {
                Name = eqimi_saxeli.Text,
                LastName = eqimi_gvari.Text
            });

           

            Close();
        }

        private void gamosvla_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
