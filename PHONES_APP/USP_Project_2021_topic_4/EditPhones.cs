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
    public partial class EditPhones : Form
    {
        public EditPhones()
        {
            InitializeComponent();
        }
        public SqlConnection myConnection;
        public SqlCommand myCommand;
        SqlDataAdapter adapt;
        AddPhone frm = new AddPhone();
        int id = 0;

        private void EditPhones_Load(object sender, EventArgs e)
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
                updatePhones(new Phones(CodePhone, Brand, Model, Year, Camera, RAM, BatteryCapacity, OS));
                MessageBox.Show("Успешно редактирахте телефон!");
                
                
            }
            
        }
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
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]"))
            {
                MessageBox.Show("Камерата на телефонът трябва да е число! /MP/");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "[^0-9]"))
            {
                MessageBox.Show("RAM паметта на телефонът трябва да е число!");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, "[^0-9]"))
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
        public void setPhone(int id)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("SELECT * FROM Phones WHERE CodePhone=@id", myConnection);
                myCommand.Parameters.AddWithValue("@id", id);
                myCommand.Connection.Open();
                using (SqlDataReader rdr = myCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        textBox1.Text = rdr["CodePhone"].ToString();
                        textBox1.Enabled = false;
                        textBox2.Text = rdr["Brand"].ToString();
                        textBox3.Text = rdr["Model"].ToString();
                        textBox4.Text = rdr["Year"].ToString();
                        textBox5.Text = rdr["Camera"].ToString();
                        textBox6.Text = rdr["RAM"].ToString();
                        textBox7.Text = rdr["BatteryCapacity"].ToString();
                        textBox8.Text = rdr["OS"].ToString();

                    }
                }
                myCommand.Connection.Close();
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
        private void updatePhones(Phones phone)
        {
            myConnection = new SqlConnection(frm.cs);
            myCommand = new SqlCommand("UPDATE Phones SET Brand = @Brand, Model = @Model, Year = @Year, " +
            " Camera = @Camera, RAM = @RAM, BatteryCapacity = @BatteryCapacity, OS=@OS Where CodePhone = @id", myConnection);
            myCommand.Parameters.AddWithValue("@id", phone.CodePhone);
            myCommand.Parameters.AddWithValue("@Brand", phone.Brand);
            myCommand.Parameters.AddWithValue("@Model", phone.Model);
            myCommand.Parameters.AddWithValue("@Year", phone.Year);
            myCommand.Parameters.AddWithValue("@Camera", phone.Camera);
            myCommand.Parameters.AddWithValue("@RAM", phone.RAM);
            myCommand.Parameters.AddWithValue("@BatteryCapacity", phone.BatteryCapacity);
            myCommand.Parameters.AddWithValue("@OS", phone.OS);
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Dispose();

            }
        }
    }
}
