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
    public partial class home_form : Form
    {
        List<Button> songs = new List<Button>();
        
        public home_form()
        {
            InitializeComponent();
        }

        private void home_form_Load(object sender, EventArgs e)
        {
            songs.Clear();
            label3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            songs.Clear();
            int top_int = 90;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-NROTJL4\MSSQLSERVER01;Initial Catalog=songdb;Integrated Security=True";
            using (con)
            {
                string command = "Select * from Song where Genre='old bollywood'";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                { Button b = new Button();
                    b.Text = rdr["SongName"].ToString();
                    b.Name = rdr["SongLink"].ToString();
                    b.Top = top_int;
                    top_int += 50;
                    b.Width=400;
                    b.Height = 43;
                    b.Padding = new Padding(5);
                    b.Click += new EventHandler(this.btn_click);
                    songs.Add(b);
                    this.Controls.Add(b);
                }
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            songs.Clear();
            int top_int = 90;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-NROTJL4\MSSQLSERVER01;Initial Catalog=songdb;Integrated Security=True";
            using (con)
            {
                string command = "Select * from Song where Genre='new bollywood'";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    b.Text = rdr["SongName"].ToString();
                    b.Name = rdr["SongLink"].ToString();
                    b.Top = top_int;
                    top_int += 50;
                    b.Width = 400;
                    b.Height = 43;
                    b.Padding = new Padding(5);
                    b.Click += new EventHandler(this.btn_click);
                    songs.Add(b);
                    this.Controls.Add(b);
                    
                }
            }
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            songs.Clear();
            int top_int = 90;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-NROTJL4\MSSQLSERVER01;Initial Catalog=songdb;Integrated Security=True";
            using (con)
            {
                string command = "Select * from Song where Genre='instrumental'";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    b.Text = rdr["SongName"].ToString();
                    b.Name = rdr["SongLink"].ToString();
                    b.Top = top_int;
                    top_int += 50;
                    b.Width = 400;
                    b.Height = 43;
                    b.Padding = new Padding(5);
                    b.Click += new EventHandler(this.btn_click);
                    songs.Add(b);
                    this.Controls.Add(b);
                }
            }
        }
        void btn_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            LoginStaticInfo.SongName = b.Text;
            LoginStaticInfo.SongLink = b.Name;
            PlaySongForm p = new PlaySongForm();
            p.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label3.Text = "LoggedOut...";
            System.Threading.Thread.Sleep(3000);
            this.Visible = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FeedBackForm f = new FeedBackForm();
            f.Visible = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(LoginStaticInfo.UserName.Equals("admin"))
            {
                SongCRUD s = new SongCRUD();
                s.Visible = true;
                this.Visible = false;
            }
            else
            {
                label3.Text = "Sorry... this is allowed only for admin";
            }
        }
    }
}
