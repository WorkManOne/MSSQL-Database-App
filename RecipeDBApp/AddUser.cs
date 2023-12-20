using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace RecipeDBApp
{
    public partial class AddUser : Form
    {
        private DB dataBase = new DB();

        public AddUser()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataBase.openConn();

            var name = textBox1.Text;
            var registeredAt = monthCalendar1.SelectionRange.Start.ToString();
            var pass = textBox4.Text;
			int amountPublished;
			if (int.TryParse(textBox3.Text, out amountPublished))
			{
				string query = $"INSERT Users (name, registeredAt, amountPublished, pass) VALUES ('{name}', '{registeredAt}', '{amountPublished}', '{pass}')";
				SqlCommand command = new SqlCommand(query, dataBase.getConnection());
				command.ExecuteNonQuery();
				MessageBox.Show("Запись добавлена", "Добавлено");
			}
			else
			{
				MessageBox.Show("Неправильный формат ввода кол-ва опубликованных рецептов", "Ошибка");
			}
            

            dataBase.closeConn();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            // Установка максимальной длины для textBox1, textBox4, textBox5, если это необходимо
            textBox1.MaxLength = 200;
            // textBox4.MaxLength = 200;
            // textBox5.MaxLength = 200;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }
    }
}
