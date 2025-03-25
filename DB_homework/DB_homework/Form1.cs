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
namespace DB_homework
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=BikeStores;Integrated Security=True");
        public int new_id = 0;
        public Form1()
        {
            InitializeComponent();

            SqlCommand cmd = new SqlCommand("SHOW", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("insertstafemember", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameter = new SqlParameter[5];
            parameter[0] = new SqlParameter("@Fname", SqlDbType.VarChar);
            parameter[0].Value = textBox2.Text;
            parameter[1] = new SqlParameter("@Lname", SqlDbType.VarChar);
            parameter[1].Value = textBox3.Text;
            parameter[2] = new SqlParameter("@Email", SqlDbType.VarChar);
            parameter[2].Value = textBox4.Text;
            parameter[3] = new SqlParameter("@Phone", SqlDbType.VarChar);
            parameter[3].Value = textBox5.Text;
            parameter[4] = new SqlParameter("active", SqlDbType.VarChar);
            if(int.TryParse(textBox6.Text, out _))
            {
                parameter[4].Value = int.Parse(textBox6.Text);
            }
            else
            {
                parameter[4].Value = 1;
            }
            
            com.Parameters.AddRange(parameter);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();

            SqlCommand cmd = new SqlCommand("SHOW", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.cange_lable("Select ID to Updare");
            form.ShowDialog();
            int ID = form.ID_HOLDER();
            new_id = ID;
            if (ID != 0)
            {

                SqlCommand com = new SqlCommand("selectstafemember", conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameter = new SqlParameter[6];
                parameter[0] = new SqlParameter("@ID", SqlDbType.Int);
                parameter[0].Value = ID;
                parameter[1] = new SqlParameter("@Fname", SqlDbType.VarChar, 50);
                parameter[1].Direction = ParameterDirection.Output;
                parameter[2] = new SqlParameter("@Lname", SqlDbType.VarChar, 50);
                parameter[2].Direction = ParameterDirection.Output;
                parameter[3] = new SqlParameter("@Email", SqlDbType.VarChar, 255);
                parameter[3].Direction = ParameterDirection.Output;
                parameter[4] = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
                parameter[4].Direction = ParameterDirection.Output;
                parameter[5] = new SqlParameter("active", SqlDbType.TinyInt);
                parameter[5].Direction = ParameterDirection.Output;

                com.Parameters.AddRange(parameter);
                conn.Open();
                com.ExecuteNonQuery();
                textBox2.Text = parameter[1].Value.ToString();
                textBox3.Text = parameter[2].Value.ToString();
                textBox4.Text = parameter[3].Value.ToString();
                textBox5.Text = parameter[4].Value.ToString();
                textBox6.Text = parameter[5].Value.ToString();
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 form = new Form2();
            form.cange_lable("Select ID to Delete");
            form.ShowDialog();
            int ID = form.ID_HOLDER();
            if (ID != 0 ) 
            {
                try
                {
                    SqlCommand com = new SqlCommand("deletestafemember", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] parameter = new SqlParameter[1];
                    parameter[0] = new SqlParameter("@ID", SqlDbType.Int);
                    parameter[0].Value = ID;
                    com.Parameters.AddRange(parameter);
                    conn.Open();
                    com.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();


                    SqlCommand cmd = new SqlCommand("SHOW", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;

                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                }
                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (new_id != 0)
            {
                SqlCommand com = new SqlCommand("updetestafemember", conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameter = new SqlParameter[6];
                parameter[0] = new SqlParameter("@ID", SqlDbType.Int);
                parameter[0].Value = new_id;
                parameter[1] = new SqlParameter("@Fname", SqlDbType.VarChar);
                parameter[1].Value = textBox2.Text;
                parameter[2] = new SqlParameter("@Lname", SqlDbType.VarChar);
                parameter[2].Value = textBox3.Text;
                parameter[3] = new SqlParameter("@Email", SqlDbType.VarChar);
                parameter[3].Value = textBox4.Text;
                parameter[4] = new SqlParameter("@Phone", SqlDbType.VarChar);
                parameter[4].Value = textBox5.Text;
                parameter[5] = new SqlParameter("active", SqlDbType.TinyInt);
                if (int.TryParse(textBox6.Text, out _))
                {
                    parameter[5].Value = int.Parse(textBox6.Text);
                }
                else
                {
                    parameter[5].Value = 1;
                }

                com.Parameters.AddRange(parameter);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd = new SqlCommand("SHOW", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }
    }
}
