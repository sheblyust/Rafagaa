using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Rafagaa
{
    public partial class Student : Form
    {
        
        public Student()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=HP-PC;Initial Catalog=Rafaga;User ID=sa;Password=123aA123;Integrated Security=True");
            
            try
            {
                conn.Open();
                string query = "insert into sub (subcriber_name,subcriber_type,subscriber_date,subscriber_end_date,subcriber_phone_number,subcriber_email,amount_paid,remaining_amount) values (@subcriber_name,@subcriber_type,@subscriber_date,@subscriber_end_date,@subcriber_phone_number,@subcriber_email,@amount_paid,@remaining_amount)";
                SqlCommand cmd = new SqlCommand(query, conn);
                if (radioButton2.Checked == true)
                {
                    int phone = int.Parse(s_phone.Text);
                    float paid_a = float.Parse(paid.Text);
                    float remi = float.Parse(remaining.Text);
                    radioButton2.Text = "WEEKLY";
                    cmd.Parameters.AddWithValue("@subcriber_name", s_name.Text);
                    cmd.Parameters.AddWithValue("@subcriber_type", radioButton2.Text);
                    cmd.Parameters.AddWithValue("@subscriber_date", this.start_date.Value);
                    cmd.Parameters.AddWithValue("@subscriber_end_date", this.end_date.Value);
                    cmd.Parameters.AddWithValue("@subcriber_phone_number", phone);
                    cmd.Parameters.AddWithValue("@subcriber_email", s_email.Text);
                    cmd.Parameters.AddWithValue("@amount_paid", paid_a);
                    cmd.Parameters.AddWithValue("@remaining_amount", remi);
                    cmd.ExecuteNonQuery();                   
                    MessageBox.Show("DATA PROCESSED SUCCESSFULLY");
                }
                else if (radioButton3.Checked == true)
                {
                    int phone = int.Parse(s_phone.Text);
                    float paid_a = float.Parse(paid.Text);
                    float remi = float.Parse(remaining.Text);
                    radioButton2.Text = "MONTHLY";
                    cmd.Parameters.AddWithValue("@subcriber_name", s_name.Text);
                    cmd.Parameters.AddWithValue("@subcriber_type", radioButton2.Text);
                    cmd.Parameters.AddWithValue("@subscriber_date", this.start_date.Value);
                    cmd.Parameters.AddWithValue("@subscriber_end_date", this.end_date.Value);
                    cmd.Parameters.AddWithValue("@subcriber_phone_number", phone);
                    cmd.Parameters.AddWithValue("@subcriber_email", s_email.Text);
                    cmd.Parameters.AddWithValue("@amount_paid", paid_a);
                    cmd.Parameters.AddWithValue("@remaining_amount", remi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DATA PROCESSED SUCCESSFULLY");
                }
                
                else
                {
                    MessageBox.Show("CHOOSE ONE FROM SUBSCRIBER TYPE");
                }
                //for display in table
                SqlDataAdapter da = new SqlDataAdapter("select * from sub", conn);
                SqlCommandBuilder cm = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "sub");
                if (ds.Tables["sub"].Rows.Count > 0)
                {

                    dataGridView1.DataSource = ds.Tables["sub"];

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex.ToString());
            }

        }

        private void Student_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=HP-PC;Initial Catalog=Rafaga;User ID=sa;Password=123aA123;Integrated Security=True");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from sub", conn);
                SqlCommandBuilder cm = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "sub");
                if (ds.Tables["sub"].Rows.Count > 0)
                {

                    dataGridView1.DataSource = ds.Tables["sub"];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex.Message);
            }
        }

        private void s_phone_TextChanged(object sender, EventArgs e)
        {

        }

        private void s_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("THIS FILD TAKS ONLY NUMBERS");
            }
          
        }
    }
}
