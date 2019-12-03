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
    public partial class libarary : Form
    {
       
        SqlCommand cmd;
    
        public libarary()
        {
            InitializeComponent();
        }

        private void libarary_Load(object sender, EventArgs e)
        {
            sub_type.Items.Add("DAILY");
            sub_type.Items.Add("WEEKLY");
            sub_type.Items.Add("MONTHLY");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=HP-PC;Initial Catalog=Rafaga;User ID=sa;Password=123aA123;Integrated Security=True");
            try
            {
                conn.Open();
                if (sub_type.Text == "DAILY")
                { 
                    string query = "insert into atendance (card_number,subscriber_name,subscriber_type,entry_time,exit_time,amount_paid) values (@card_number,@subscriber_name,@subscriber_type,@entry_time,@exit_time,@amount_paid)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@card_number", card_num.Text);
                    cmd.Parameters.AddWithValue("@subscriber_name", sub_name.Text);
                    cmd.Parameters.AddWithValue("@subscriber_type", sub_type.Text);
                    cmd.Parameters.AddWithValue("@entry_time", this.enter_date.Value);
                    cmd.Parameters.AddWithValue("@exit_time", this.exit_date.Value);
                    cmd.Parameters.AddWithValue("@amount_paid", pay.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DATA PROCESSED SUCCESSFULLY");
                }
                else
                {
                   
                    string query = "insert into atendance (card_number,subscriber_name,subscriber_type,entry_time,exit_time) values (@card_number,@subscriber_name,@subscriber_type,@entry_time,@exit_time)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@card_number", card_num.Text);
                    cmd.Parameters.AddWithValue("@subscriber_name", sub_name.Text);
                    cmd.Parameters.AddWithValue("@subscriber_type", sub_type.Text);
                    cmd.Parameters.AddWithValue("@entry_time", this.enter_date.Value);
                    cmd.Parameters.AddWithValue("@exit_time", this.exit_date.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DATA PROCESSED SUCCESSFULLY");
                }
                card_num.Clear();
                sub_name.Clear();
                sub_type.Text = "";
                pay.Clear(); 
                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex.ToString());
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            displayPanal.Visible = true;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panel2.Visible = true;
                pictureBox2.Visible = true;
                MessageBox.Show("ENTER THE CARD NUMBER AND HIS/HER NAME AND PRESS THE SEARCH SIGN");
            }
        }

        private void sub_name_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=HP-PC;Initial Catalog=Rafaga;User ID=sa;Password=123aA123;Integrated Security=True");
            try
            {
                conn.Open();
               
                Dataset ds_Ledger = Ledger.GetLedgerList_ForAutoComplete();

                if (ds_Ledger.Tables[0].Rows.Count <= 0) return;

                var dt = ds_Ledger.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    namesCollection.Add(Convert.ToString(dr["DESCRIPTION"])); // Fill Items To TextBox Collection
                }

                sub_name.AutoCompleteMode = AutoCompleteMode.Suggest;
                sub_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
                sub_name.AutoCompleteCustomSource = namesCollection;

                         conn.Close();
            }
           catch(Exception ex)
            {
               MessageBox.Show("ERROR"+ ex.Message);
           }
        }
    }
}
