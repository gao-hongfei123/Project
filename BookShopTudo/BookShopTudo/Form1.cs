using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopTudo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private int num = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            num++;
           
            progressBar1.Value = num;
            
            label3.Text = progressBar1.Value.ToString() + "%";
            if (num == 100)
            {
                timer1.Stop();
                this.Hide();
                Login login = new Login();
                login.Show();
                
            }


        }
    }
}
