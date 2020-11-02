﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }
        System.Windows.Forms.Timer t;
        void t_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 10;

            if (progressBar1.Value >= 100) t.Stop();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
           
        }
    }

}
