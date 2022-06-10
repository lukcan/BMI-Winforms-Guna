using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BMI_Guna2
{
    public partial class Calculator : Form
    {
        private double height = 0;
        private double bmi = 0;
        private double weight = 0;
        public Calculator()
        {
            InitializeComponent();
        }

        List<Ziak> zoznam = new List<Ziak>();

        private void height_TextChanged(object sender, EventArgs e)
        {
            double tmpHeight = 0;
            try
            {
                tmpHeight = Convert.ToDouble(heightbox.Text);
                height = tmpHeight;
                heightbox.ForeColor = Color.Black;
            }
            catch (Exception _)
            {
                heightbox.ForeColor = Color.Red;
            }
        }

        private void weight_TextChanged(object sender, EventArgs e)
        {
            double tmpWeight = 0;
            try
            {
                tmpWeight = Convert.ToDouble(weightbox.Text);
                weight = tmpWeight;
                weightbox.ForeColor = Color.Black;
            }
            catch (Exception _)
            {
                weightbox.ForeColor = Color.Red;
            }
        }

        private void calculateBMI()
        {
            bmi = weight / Math.Pow(height / 100, 2);            
        }

        private void calculate_button_Click(object sender, EventArgs e)
        {
            calculateBMI();
            // TODO bmi here 

            if (radiobutton_male.Checked || radiobutton_female.Checked)
            {
                result1.Text = bmi.ToString("#.##");
                result1.ForeColor = Color.Black;
            }
            else
            {
                result1.ForeColor = Color.Red;
                result1.Text = "Choose your gender";
                return;
            }
                result2.ForeColor = Color.Black;
                result2.Text = " ";

            if (radiobutton_female.Checked)
            {
                if (0 < bmi && bmi < 18.5)
                {
                    result2.Text = "You´re underweight"; 
                }
                else if (18.501 < bmi && bmi < 24.9)
                {
                    result2.Text = "You´re normal ";
                }
                else if (24.901 < bmi && bmi < 29.9)
                {
                    result2.Text = "You´re overweight";
                }
                else if (29.901 < bmi && bmi < 34.9)
                {
                    result2.Text = "You´re obese";
                }
                else if (34.901 < bmi)
                {
                    result2.Text = "You´re extremly obese";
                }
            }

            if (radiobutton_male.Checked)
            {
                if (0 < bmi && bmi < 18.5)
                {
                    result2.Text = "You´re underweight";
                }
                else if (18.501 < bmi && bmi < 24.9)
                {
                    result2.Text = "You´re normal ";
                }
                else if (24.901 < bmi && bmi < 29.9)
                {
                    result2.Text = "You´re overweight";
                }
                else if (29.901 < bmi && bmi < 34.9)
                {
                    result2.Text = "You´re obese";
                }
                else if (34.901 < bmi)
                {
                    result2.Text = "You´re extremly obese";
                }
            }

            load_db();
            Ziak tmp = new Ziak();
            tmp.Height = heightbox.Text;
            tmp.Weight = weightbox.Text;
            tmp.Gender = radiobutton_male.Checked ? "Male" : "Female";
            tmp.Bmi = (float)bmi;
            tmp.Result = result2.Text;
            zoznam.Add(tmp);
            save_db();
        }

        void save_db()
        {

            string fileName = "../../my_db.json";
            string jsonString = JsonSerializer.Serialize(zoznam);
            File.WriteAllText(fileName, jsonString);
        }

        void load_db()
        {
            string fileName = "../../my_db.json";
            string jsonString = File.ReadAllText(fileName);
            if (jsonString.Length > 0)
                zoznam = JsonSerializer.Deserialize<List<Ziak>>(jsonString);
        }

    }    
}
