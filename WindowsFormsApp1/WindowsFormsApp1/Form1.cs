using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 5000;
        }

        //Таймер необходимый для перехода на следующую форму (через 5 секунд)
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }
    }
}
