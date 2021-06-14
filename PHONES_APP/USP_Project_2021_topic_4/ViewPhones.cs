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
    public partial class ViewPhones : Form
    {
        public ViewPhones()
        {
            InitializeComponent();
            displayData();
        }
        public SqlConnection myConnection;
        public SqlCommand myCommand;
        SqlDataAdapter adapt;
        AddPhone frm = new AddPhone();
        int id = 0;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("грешен избор!");
            }

        }
        private void displayData()
        {

            myConnection = new SqlConnection(frm.cs);
            myConnection.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM Phones", myConnection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
        }
        
        private void deletePhones(int id)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("DELETE Phones WHERE CodePhone=@id", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@id", id);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Успешно изтрихте телефон!");
                displayData();
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
        private void button2_Click(object sender, EventArgs e)
        {
            deletePhones(id);
        }

        private void ViewPhones_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditPhones frm = new EditPhones();
            frm.setPhone(id);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            displayData();
        }
    }
}
