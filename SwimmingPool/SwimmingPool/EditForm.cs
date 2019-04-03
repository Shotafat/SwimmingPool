﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSQLite.CLASSES.Services;

namespace SwimmingPool
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }
       
     

        private void button1_Click(object sender, EventArgs e)
        {
           
            var gela =  ServiceInstances.Service().CreateObject(int.Parse(textBox2.Text), double.Parse(textBox3.Text));
            ServiceInstances.Service().GetSubscriptionPriceServices().Edit(gela);
            DialogResult = DialogResult.OK;
            Close();

        }

      
    }
}
