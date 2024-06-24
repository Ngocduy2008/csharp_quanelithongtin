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
using System.Runtime.CompilerServices;

namespace csharp_quanelithongtin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = SqlConnection (@"Data Source=LAB1-MAY7\MISASME2022;Initial Catalog=QuanLiThongTin;Integrated Security=True;Encrypt=False");
        private void opencon()
        {
            if (conn.State==ConnectionState.Closed)
            {
                conn .Open();
            }
        }
        private void clonecon()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        private Boolean exe(string cmd)
        {
            opencon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd,con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;  
                throw;
            }
            clonecon();
            return check;
        }
        private DataTable red(string cmd) 
        {
            opencon ();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            clonecon();
            return dt;
        }
        private void load()
        {
            DataTable dt = red("SELLECT * FROM Quanlithongtin");

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
