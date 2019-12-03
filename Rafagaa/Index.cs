using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rafagaa
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Index_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            books bo = new books();
            bo.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            libarary li = new libarary();
            li.ShowDialog();
        }
    }
}
