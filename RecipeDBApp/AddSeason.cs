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
    public partial class AddSeason : Form
    {
        private DB dataBase = new DB();

        public AddSeason()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataBase.openConn();

            var name = textBox1.Text;
            var dateStart = monthCalendar1.SelectionRange.Start.ToString();
            var dateEnd = monthCalendar2.SelectionRange.Start.ToString();

            string query = $"INSERT Season (name, dateStart, dateEnd) VALUES ('{name}', '{dateStart}', '{dateEnd}')";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись добавлена", "Добавлено");

            dataBase.closeConn();
        }

        private void AddSeason_Load(object sender, EventArgs e)
        {
            // Установка максимальной длины для textBox1, textBox2, textBox3, если это необходимо
            textBox1.MaxLength = 200;
        }
    }
}
