using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI_Guna2
{
    public partial class Menu : Form //UserControl
    {
        Calculator calc_cont = new Calculator();
        History hist_cont = new History();
        What_is_BMI W_BMI= new What_is_BMI();
        info Info_Page = new info();

        public Menu()
        {
            InitializeComponent();        
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            container(calc_cont);
        }

        private void container(object _form)
        {
            if (guna2Panel3.Controls.Count > 0) guna2Panel3.Controls.Clear();
            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            guna2Panel3.Controls.Add(fm);
            guna2Panel3.Tag = fm;
            guna2Panel3.Controls.Add(fm);
            guna2Panel3.Tag = fm;
            fm.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            container(hist_cont);
            hist_cont.load_db();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            container(W_BMI);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            container(Info_Page);
        }
    }
}
