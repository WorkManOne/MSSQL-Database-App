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
    public partial class searchCategoryViews : Form
    {
        DB dataBase = new DB();
        public searchCategoryViews()
        {
            InitializeComponent();
            StartPosition= FormStartPosition.CenterScreen;
        }


        private void CreateColumns()
        {
            dataGridSearch.Columns.Add("id", "id");
            dataGridSearch.Columns.Add("name", "Категория блюда");
            dataGridSearch.Columns.Add("howMuch", "Просмотры");
                
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetString(1), 
                         rec.GetInt32(2));
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"EXEC countRecByGroups";
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

            string query = $"Declare @T Table(id INT, name VARCHAR(200), howMuch INT) Insert @T EXEC countRecByGroups Select * from @T WHERE {comboBox1.Text} LIKE '%" + textBoxSearch.Text + "%'";

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

        private void searchCategoryViews_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridSearch);
            comboBox1.SelectedIndex = 0;
        }

        private void searchCategoryViews_FormClosed(object sender, FormClosedEventArgs e)
        {
            adminTools admintools = new adminTools();
            admintools.Show();
        }
    }
}
