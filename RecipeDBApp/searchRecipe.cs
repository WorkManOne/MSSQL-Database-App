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
    public partial class searchRecipe : Form
    {
        DB dataBase = new DB();
        public searchRecipe()
        {
            InitializeComponent();
            StartPosition= FormStartPosition.CenterScreen;
        }


        private void CreateColumns()
        {
            dataGridSearch.Columns.Add("id", "id");
            dataGridSearch.Columns.Add("name", "Рецепт");
            dataGridSearch.Columns.Add("ProductName", "Продукт");
            dataGridSearch.Columns.Add("GroupName", "Категория рецепта");
            dataGridSearch.Columns.Add("CountryName", "Страна");
            dataGridSearch.Columns.Add("nationName", "Национальность рецепта");
            dataGridSearch.Columns.Add("UserName", "Опубликовавший пользователь");
            dataGridSearch.Columns.Add("SeasonName", "Сезон");
            dataGridSearch.Columns.Add("howMuch", "Просмотры");
                
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetString(1), 
                         rec.GetString(2), rec.GetString(3), 
                         rec.GetString(4), rec.GetString(5), 
                         rec.GetString(6), rec.GetString(7), 
                         rec.GetInt32(8));
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT * FROM RecipeFullInfo";
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

            string query = $"SELECT * FROM RecipeFullInfo WHERE {comboBox1.Text} LIKE '%" + textBoxSearch.Text + "%'";

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

        private void searchRecipe_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridSearch);
            comboBox1.SelectedIndex= 0;
        }

        private void searchRecipe_FormClosed(object sender, FormClosedEventArgs e)
        {
            adminTools admintools = new adminTools();
            admintools.Show();
        }
    }
}
