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
    public partial class AddCountry : Form
    {
        DB dataBase = new DB();
        public AddCountry()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddCountry_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 200;
            textBox2.MaxLength = 200;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataBase.openConn();

            var name = textBox1.Text;
            var nation = textBox2.Text;

            string query = $"INSERT Country (name, primaryNation) VALUES ('{name}', '{nation}')";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись добавлена", "Добавлено");

            dataBase.closeConn();
        }
    }
}
