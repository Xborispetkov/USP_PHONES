using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USP_Project_2021_topic_4
{
    public partial class AddPhone : Form
    {
        public AddPhone()
        {
            InitializeComponent();
        }

        public string cs = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Boris Petkov\\Desktop\\USP_GIT\\USP_Project_2021_topic_4\\USP_Project_2021_topic_4\\Database1.mdf;Integrated Security = True";
        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);

        private bool checkValues()

        {
       
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Кодът на телефонът трябва да е число!");
                return false;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Въведете данни в поле марка!");
                return false;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Въведете данни в поле модел!");
                return false;
            }
            if (Int32.Parse(textBox4.Text) < 2010)
            {
                MessageBox.Show("Въведете правилна година за телефона /след 2010/");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]") || textBox5.Text == "")
            {
                MessageBox.Show("Камерата на телефонът трябва да е число! /MP/");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "[^0-9]") || textBox6.Text == "")
            {
                MessageBox.Show("RAM паметта на телефонът трябва да е число!");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, "[^0-9]") || textBox7.Text == "")
            {
                MessageBox.Show("Капацитетът на батерията трябва да бъде число! /mAh/");
                return false;
            }
            
            if (textBox8.Text == "")
            {
                MessageBox.Show("Въведете данни в поле операционна система!");
                return false;
            }
           return true; 
         }

        public void insertPhones(Phones Phones)
        {
            try
            {
                myConnection = new SqlConnection(cs);
                myCommand = new SqlCommand("INSERT INTO Phones(CodePhone, Brand, Model, Year, Camera, RAM, BatteryCapacity, OS) Values(@CodePhone, @Brand, @Model, @Year, @Camera, @RAM, @BatteryCapacity, @OS)", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@CodePhone", Phones.CodePhone);
                myCommand.Parameters.AddWithValue("@Brand", Phones.Brand);
                myCommand.Parameters.AddWithValue("@Model", Phones.Model);
                myCommand.Parameters.AddWithValue("@Year", Phones.Year);
                myCommand.Parameters.AddWithValue("@Camera", Phones.Camera);
                myCommand.Parameters.AddWithValue("@RAM", Phones.RAM);
                myCommand.Parameters.AddWithValue("@BatteryCapacity", Phones.BatteryCapacity);
                myCommand.Parameters.AddWithValue("@OS", Phones.OS);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void изходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ViewPhones form = new ViewPhones();
            //form.Show();
        }

        private void AddPhone_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkValues())
            {
                int CodePhone = Int32.Parse(textBox1.Text);
                string Brand = textBox2.Text;
                string Model = textBox3.Text;
                int Year = Int32.Parse(textBox4.Text);
                int Camera = Int32.Parse(textBox5.Text);
                int RAM = Int32.Parse(textBox6.Text);
                int BatteryCapacity = Int32.Parse(textBox7.Text);
                string OS = textBox8.Text;
                insertPhones(new Phones(CodePhone, Brand, Model, Year, Camera, RAM, BatteryCapacity, OS));
                MessageBox.Show("Успешно добавихте телефон!");
                Clear();

            }
        }

        private void търсиТелефонПоОпределенФилтърToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // SearchPhoneByBrand form = new SearchPhoneByBrand();
           // form.Show();
        }

        private void търсиТелефонПоГодинаToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // SearchPhoneByYear form = new SearchPhoneByYear();
           // form.Show();

        }

        private void търсиТелеофонПоКамераToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // SearchPhoneByCamera form = new SearchPhoneByCamera();
           // form.Show();

        }

        private void търсиТелефонПоRAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // SearchPhoneByRam form = new SearchPhoneByRam();
           // form.Show();
        }

       
    }
}
