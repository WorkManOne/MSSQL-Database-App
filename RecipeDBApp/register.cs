using System;
using System.Collections;
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
    public partial class register : Form
    {
        DB dataBase = new DB();
        public register()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void register_Load(object sender, EventArgs e)
        {
            textBoxUsername.MaxLength = 200;
            textBoxPassword.MaxLength = 200;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            
            DataTable tb = new DataTable();
            string query = $"SELECT * FROM Users WHERE name = '{username}'";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь с таким именем уже существует.", "Ошибка");
            }
            else
            {
                query = $"INSERT Users (name, registeredAt, amountPublished, pass) VALUES ('{username}', '{DateTime.Today.ToString("dd.MM.yyyy")}', 0, '{password}');";
                command = new SqlCommand(query, dataBase.getConnection());

                dataBase.openConn();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Вы зарегистрированы.", "Регистрация");
                    login login = new login();
                    this.Hide();
                    login.ShowDialog();
                }
                else MessageBox.Show("Ошибка регистрации, аккаунт не был зарегистрирован.", "Ошибка");
                dataBase.closeConn();
            }

        }
    }
}
