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
    public partial class SearchPhoneByYear : Form
    {
        public SearchPhoneByYear()
        {
            InitializeComponent();
        }
        public SqlConnection myConnection;
        public SqlCommand myCommand;
        SqlDataAdapter adapt;
        AddPhone frm = new AddPhone();

        public void qrySearchPhoneByYear()
        {
            string Year = textBox1.Text;
            myConnection = new SqlConnection(frm.cs);
            myConnection.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT z.Brand, z.Model, z.Year, z.Camera, z.RAM, z.BatteryCapacity, z.OS FROM Phones z WHERE z.Year=@Year ORDER BY z.CodePhone   ", myConnection);
            adapt.SelectCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "@Year",
                Value = Year,
                SqlDbType = SqlDbType.NVarChar,
                Size = 40
            });
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
        }


        private void SearchPhoneByYear_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            qrySearchPhoneByYear();
        }
    }
}
