using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NormDBChecker
{
    public partial class UsersList : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["Users"].ToString();
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        NpgsqlDataAdapter da;

        public UsersList()
        {
            InitializeComponent();
        }

        private void UsersList_Load(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection(conStr);

            con.Open();
            //string sql = ("SELECT * FROM users");
            string sql = ("SELECT login as \"Логин\", password as \"Пароль\", fio as \"ФИО\", name as \"Роль\" FROM users\r\njoin roles r on r.id = role");
            da = new NpgsqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            da.Update(ds);
        }
    }
}
