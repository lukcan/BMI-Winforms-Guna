using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace BMI_Guna2
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        public void load_db()
        {
            string fileName = "../../my_db.json";
            string jsonString = File.ReadAllText(fileName);
            List<Ziak> zoznam = new List<Ziak>();
            if (jsonString.Length > 0) { 
            zoznam = JsonSerializer.Deserialize<List<Ziak>>(jsonString);
            aktualizujVypis(zoznam);
        }
        }

        void aktualizujVypis(List<Ziak> zoznam)
        {
            richTextBox1.Clear();

            for (int i = zoznam.Count - 1; i >= 0; i--)
            {
                var t = zoznam[i];
                richTextBox1.Text += $"Date {t.Date} Height: { t.Height} Weight {t.Weight} Gender {t.Gender} Bmi {t.Bmi} Bmi {t.Result}\n";// "Height " + t.Height + "  Weight " + t.Weight + "  Gender " + t.Gender + " Bmi " + t.Bmi + "\n";
            }

            zoznam.Reverse();
            guna2DataGridView1.DataSource = zoznam;
        }

        private void History_Load(object sender, EventArgs e)
        {
            load_db();
            guna2DataGridView1.Columns["Bmi"].DefaultCellStyle.Format = "N2";
        }
    }
}
