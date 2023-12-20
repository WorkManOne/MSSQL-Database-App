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

namespace RecipeDBApp
{
    public partial class login : Form
    {
        DB dataBase = new DB();
        public login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxUsername.MaxLength = 200;
            textBoxPassword.MaxLength = 200;    
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;   

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable tb = new DataTable();

            string query = $"SELECT id, name, pass FROM Users WHERE name = '{username}' and pass = '{password}'";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(tb);
            

            if (tb.Rows.Count == 1) {
                int id = int.Parse(tb.Rows[0][0].ToString());
                if (id == 1)
                {
                    MessageBox.Show("Успешный вход! Загружена панель администратора.", "Вход");
                    adminTools admin = new adminTools();
                    this.Hide();
                    admin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Успешный вход!", "Вход");
                    userTools user = new userTools(id);
                    this.Hide();
                    user.ShowDialog();
                }
                
            }
            else MessageBox.Show("Такого пользователя не существует.", "Ошибка");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register reg = new register();
            reg.Show();
            this.Hide();
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
