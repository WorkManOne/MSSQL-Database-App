using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeDBApp
{
    public partial class searchViewedRecByUser : Form
    {
        DB dataBase = new DB();
        public searchViewedRecByUser()
        {
            InitializeComponent();
            StartPosition= FormStartPosition.CenterScreen;
        }


        private void CreateColumns()
        {
            dataGridSearch.Columns.Add("dateViwed", "Дата просмотра");
            dataGridSearch.Columns.Add("id", "ID Пользователя");
            dataGridSearch.Columns.Add("userName", "Имя пользователя");
            dataGridSearch.Columns.Add("idRecipeViewed", "ID строки количества просмотров");
            dataGridSearch.Columns.Add("name", "Имя рецепта");
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetDateTime(0), rec.GetInt32(1), rec.GetString(2),
                         rec.GetInt32(3), rec.GetString(4));
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT * FROM UserViewedRecipe";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT * FROM UserViewedRecipe WHERE {comboBox1.Text} LIKE '%" + textBoxSearch.Text + "%'";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridSearch);
        }

        private void searchViewedRecByUser_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridSearch);
            comboBox1.SelectedIndex = 0;
        }

        private void searchViewedRecByUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            adminTools admintools = new adminTools();
            admintools.Show();
        }
    }
}
