using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_homework
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBox1.Text, out _)) 
            {
                this.Close();
            }
            else
            {
                textBox1.Text = string.Empty;
            }
        }

        public int ID_HOLDER()
        {
            return (int.Parse(textBox1.Text));
        }

        public void cange_lable(string new_)
        {
            label1.Text = new_;
        }
    }
}
