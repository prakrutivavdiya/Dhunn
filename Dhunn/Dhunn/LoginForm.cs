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
namespace Dhunn
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            label4.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-NROTJL4\MSSQLSERVER01;Initial Catalog=songdb;Integrated Security=True";
            try
            {
                using (con)
                {
                    string command = "Select * from UserData";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    int flag = 0;
                    while (rdr.Read())
                    {
                        if (rdr["UserName"].ToString().Equals(textBox1.Text))
                        {
                            if (rdr["Password"].ToString().Equals(textBox2.Text))
                            {
                                LoginStaticInfo.UserName = textBox1.Text;
                                LoginStaticInfo.Password = textBox2.Text;
                                flag = 1;
                                label4.Text = "login";

                            }
                        }
                    }
                    if (flag == 0)
                    {
                        label4.Text = "wrong username or password";
                    }
                    rdr.Close();
                }

                
                    home_form h = new home_form();
                    h.Visible = true;
                
            }
            catch(Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm f = new RegisterForm();
            f.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
