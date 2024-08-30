using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Npgsql;

namespace NormDBChecker
{
    public partial class Form1 : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["Users"].ToString();

        //Dictionary<string, string> users = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();

            //using (var cn = NpgsqlDataSource.Create(conStr))
            //{
            //    cn.OpenConnection();
            //    var sql = "select * from users";
            //    var cmd = cn.CreateCommand(sql);
            //    var dr = cmd.ExecuteReader();

            //    while (dr.Read())
            //    {
            //        users.Add(dr["login"].ToString(), dr["password"].ToString());
            //    }
            //    cn.Dispose();
            //    dr.Dispose();
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cmbLoginList.Items.AddRange(users.Keys.ToArray());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //cmbLoginList.Text = string.Empty;
            tbLogin.Text = string.Empty;
            tbPassword.Text = string.Empty;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            /* if(users.TryGetValue(cmbLoginList.Text, out string password) && password == tbPassword.Text)
             {
                 MessageBox.Show("Доступ получен");

                 using (var cn = NpgsqlDataSource.Create(conStr))
                 {
                     cn.OpenConnection();
                     var sql = "select role from users where login = cmbLoginList.Text";
                     var cmd = cn.CreateCommand(sql);

                     var sql = "select * from course where faculty_id = @id ORDER BY course_id";

                     var cmd = cn.CreateCommand(sql);
                     cmd.Parameters.AddWithValue("@id", id);

                     var dr = cmd.ExecuteReader();

                     while (dr.Read())
                     {
                         users.Add(dr["login"].ToString(), dr["password"].ToString());
                     }
                     cn.Dispose();
                     dr.Dispose();
                 }
             }
             else
             { MessageBox.Show("В доступе отказано! Обратитесь к администратору."); }
         }*/

            int role = -1;

            using (var cn = NpgsqlDataSource.Create(conStr))
            {
                cn.OpenConnection();
                var sql = "select \"role\" from users where login like @login and \"password\" like @password";

                var cmd = cn.CreateCommand(sql);
                //cmd.Parameters.AddWithValue("@login", cmbLoginList.Text);
                cmd.Parameters.AddWithValue("@login", tbLogin.Text);
                cmd.Parameters.AddWithValue("@password", tbPassword.Text);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    role = Int16.Parse(dr["role"].ToString());
                }
                cn.Dispose();
                dr.Dispose();
            }

            if (role == 1)
            {
                //MessageBox.Show("Admin");
                AdminForm adm = new AdminForm();
                adm.ShowDialog();
            }
            else if (role == 2)
            {
                MessageBox.Show("Teacher");
            }
            else if (role == 3)
            {
                MessageBox.Show("Student");
            }
            else
            {
                MessageBox.Show("В доступе отказано! Обратитесь к администратору.");
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
