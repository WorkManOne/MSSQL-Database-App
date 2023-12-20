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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RecipeDBApp
{
    public partial class AddRecipe : Form
    {
        private DB dataBase = new DB();
        private int selectedRow;
        int userIDform;

        public AddRecipe(int userID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            userIDform = userID;
            if (userIDform != 0)
            {
                //dataGridConv.Visible = false;
                dataGridUser.Visible = false;
                comboBoxUser.Visible = false;
                //comboBoxConv.Visible = false;
                //textBoxConv.Visible = false;
                textBoxUser.Visible = false;
            }

        }
        private void CreateColumnsUser()
        {
            dataGridUser.RowHeadersWidth = 20;
            dataGridUser.Columns.Add("id", "ID");
            dataGridUser.Columns[0].Width = 50;
            dataGridUser.Columns.Add("name", "Имя пользователя");
        }

        private void CreateColumnsConv()
        {
            dataGridConv.RowHeadersWidth = 20;
            dataGridConv.Columns.Add("id", "ID");
            dataGridConv.Columns[0].Width = 50;
            dataGridConv.Columns.Add("valMain", "Коэф. основной валюты");
            dataGridConv.Columns.Add("valOther", "Коэф. сторонней валюты");
        }

        private void CreateColumnsGroup()
        {
            dataGridGroup.RowHeadersWidth = 20;
            dataGridGroup.Columns.Add("id", "ID");
            dataGridGroup.Columns[0].Width = 50;
            dataGridGroup.Columns.Add("name", "Категория");
            dataGridGroup.Columns.Add("priority", "Приоритет");
        }
        private void CreateColumnsSeason()
        {
            dataGridSeason.RowHeadersWidth = 20;
            dataGridSeason.Columns.Add("id", "ID");
            dataGridSeason.Columns[0].Width = 50;
            dataGridSeason.Columns.Add("name", "Сезон");
            dataGridSeason.Columns.Add("dateStart", "Начало сезона");
            dataGridSeason.Columns.Add("dateEnd", "Конец сезона");
        }
        private void CreateColumnsCountry()
        {
            dataGridCountry.RowHeadersWidth = 20;
            dataGridCountry.Columns.Add("id", "ID");
            dataGridCountry.Columns[0].Width = 50;
            dataGridCountry.Columns.Add("name", "Страна");
            dataGridCountry.Columns.Add("primaryNation", "Национальность");
        }
        private void CreateColumnsProducts()
        {
            dataGridProducts.RowHeadersWidth = 20;
            dataGridProducts.Columns.Add("id", "ID подсчета");
            dataGridProducts.Columns.Add("idProd", "ID продукта");
            dataGridProducts.Columns.Add("name", "Продукт");
            dataGridProducts.Columns.Add("costForHundred", "Цена за 100 гр");
            dataGridProducts.Columns.Add("caloriesForHundred", "Каллорий в 100 гр");
            dataGridProducts.Columns.Add("amount", "Кол-во в гр");
            dataGridProducts.Columns.Add("cost", "Цена");
            dataGridProducts.Columns.Add("calories", "Всего каллорий");
            dataGridProducts.Columns.Add("isNew", String.Empty);
            dataGridProducts.Columns[8].Visible = false;
        }

        private void CreateColumnsProductsOnly()
        {
            dataGridProductsOnly.RowHeadersWidth = 20;
            dataGridProductsOnly.Columns.Add("id", "ID");
            dataGridProductsOnly.Columns[0].Width = 50;
            dataGridProductsOnly.Columns.Add("name", "Продукт");
            dataGridProductsOnly.Columns.Add("costForHundred", "Цена за 100 гр");
            dataGridProductsOnly.Columns.Add("caloriesForHundred", "Каллорий в 100 гр");
        }

        private void ReadSingleRowUser(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetString(1));
        }

        private void ReadSingleRowGroup(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetString(1), rec.GetFloat(2));
        }

        private void ReadSingleRowCountry(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetString(1), rec.GetString(2));
        }

        private void ReadSingleRowSeason(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetString(1), rec.GetDateTime(2), rec.GetDateTime(3));
        }
        private void ReadSingleRowConv(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetFloat(1), rec.GetFloat(2));
        }
        private void ReadSingleRowProduct(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetInt32(1), rec.GetString(2), 
                        rec.GetFloat(3), rec.GetFloat(4), rec.GetFloat(5), rec.GetFloat(6), rec.GetFloat(7), RowState.ModifiedNew);
        }
        private void ReadSingleRowProductsOnly(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetString(1), rec.GetFloat(2), rec.GetFloat(3));
        }


        private void ClearFields()
        {
            textBox2.Clear();
            textBoxAmount.Clear();
            textBoxConv.Clear();
            textBoxCountry.Clear();
            textBoxDescr.Clear();
            textBoxGroup.Clear();
            textBoxProductsOnly.Clear();
            textBoxSeason.Clear();
            textBoxUser.Clear();
        }

        private void SearchConv(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string query = $"SELECT id, valMain, valOther FROM CostConverter WHERE {comboBoxConv.Text} LIKE '%" + textBoxConv.Text + "%'";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowConv(dgw, reader);
            }
            reader.Close();

        }

        private void SearchSeason(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string query = $"SELECT * FROM Season WHERE {comboBoxSeason.Text} LIKE '%" + textBoxSeason.Text + "%'";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowSeason(dgw, reader);
            }
            reader.Close();

        }

        private void SearchGroup(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string query = $"SELECT * FROM Groups WHERE {comboBoxGroup.Text} LIKE '%" + textBoxGroup.Text + "%'";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowGroup(dgw, reader);
            }
            reader.Close();

        }

        private void SearchCountry(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string query = $"SELECT * FROM Country WHERE {comboBoxCountry.Text} LIKE '%" + textBoxCountry.Text + "%'";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowCountry(dgw, reader);
            }
            reader.Close();

        }

        private void SearchUser(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string query = $"SELECT id, name FROM Users WHERE {comboBoxUser.Text} LIKE '%" + textBoxUser.Text + "%'";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowUser(dgw, reader);
            }
            reader.Close();

        }

        private void SearchProductsOnly(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT * FROM Product WHERE {comboBoxProductsOnly.Text} LIKE '%" + textBoxProductsOnly.Text + "%'";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowProductsOnly(dgw, reader);
            }
            reader.Close();
        }

        private void AddRecipe_Load(object sender, EventArgs e)
        {
            CreateColumnsUser();
            CreateColumnsConv();
            CreateColumnsCountry();
            CreateColumnsGroup();
            CreateColumnsSeason();
            CreateColumnsProducts();
            CreateColumnsProductsOnly();
            comboBoxCountry.SelectedIndex = 0;
            comboBoxUser.SelectedIndex = 0; 
            comboBoxGroup.SelectedIndex = 0;
            comboBoxSeason.SelectedIndex = 0;
            comboBoxConv.SelectedIndex = 0;
            comboBoxProductsOnly.SelectedIndex = 0;
            SearchProductsOnly(dataGridProductsOnly);
            SearchUser(dataGridUser);
            SearchCountry(dataGridCountry);
            SearchSeason(dataGridSeason);
            SearchGroup(dataGridGroup);
            SearchConv(dataGridConv);
        }

        private void AddRecipe_FormClosed(object sender, FormClosedEventArgs e)
        {
            //RecipeForm form = new RecipeForm();
            //form.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataBase.openConn();

            var name = textBox2.Text;
            var country_id = dataGridCountry.Rows[dataGridCountry.CurrentCell.RowIndex].Cells[0].Value;
            var costConverter_id = dataGridConv.Rows[dataGridConv.CurrentCell.RowIndex].Cells[0].Value;
            var season_id = dataGridSeason.Rows[dataGridSeason.CurrentCell.RowIndex].Cells[0].Value;
            int publishedBy_id;
            if (userIDform != 0)
            {
                publishedBy_id = userIDform;
            }
            else
            {
                publishedBy_id = int.Parse(dataGridUser.Rows[dataGridUser.CurrentCell.RowIndex].Cells[0].Value.ToString());
            }
            
            var group_id = dataGridGroup.Rows[dataGridGroup.CurrentCell.RowIndex].Cells[0].Value;
            var caloriesInAll = 0;//FIX==============textBox4.Text;
            var description = textBoxDescr.Text;
            var moneyCostMain = 0; //FIX============== textBox6.Text;
            var moneyCostOther = 0; //FIX============= textBox7.Text;


            var publishedDate = monthCalendar1.SelectionRange.Start.ToString();

            var query = $"INSERT Recipe VALUES ('{name}', '{country_id}', '{caloriesInAll}', '{description}', '{moneyCostMain}', '{moneyCostOther}', '{costConverter_id}', '{season_id}', '{publishedDate}', '{publishedBy_id}', '{group_id}')";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            var recid = reader.GetInt32(0);
            reader.Close();

            for (int i = 0; i < dataGridProducts.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridProducts.Rows[i].Cells[8].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }
                if (rowState == RowState.New)
                {
                    var id = dataGridProducts.Rows[i].Cells[1].Value.ToString();
                    var amount = dataGridProducts.Rows[i].Cells[5].Value.ToString();
                    query = $"EXEC productRecipeCreate '{id}', '{recid}', '{amount}'";
                    command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Запись добавлена", "Добавлено");
            dataBase.closeConn();
        }


        private void dataGridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {
            SearchUser(dataGridUser);
        }

        private void textBoxCountry_TextChanged(object sender, EventArgs e)
        {
            SearchCountry(dataGridCountry);
        }

        private void textBoxSeason_TextChanged(object sender, EventArgs e)
        {
            SearchSeason(dataGridSeason);
        }

        private void textBoxGroup_TextChanged(object sender, EventArgs e)
        {
            SearchGroup(dataGridGroup);
        }

        private void textBoxConv_TextChanged(object sender, EventArgs e)
        {
            SearchConv(dataGridConv);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var id = dataGridProductsOnly.Rows[dataGridProductsOnly.CurrentCell.RowIndex].Cells[0].Value;
            var name = dataGridProductsOnly.Rows[dataGridProductsOnly.CurrentCell.RowIndex].Cells[1].Value;
            float caloriesForHundred = float.Parse(dataGridProductsOnly.Rows[dataGridProductsOnly.CurrentCell.RowIndex].Cells[3].Value.ToString());
            float costForHundred = float.Parse(dataGridProductsOnly.Rows[dataGridProductsOnly.CurrentCell.RowIndex].Cells[2].Value.ToString());
            float amount;
            if (float.TryParse(textBoxAmount.Text, out amount))
            {
                dataGridProducts.Rows.Add();
                var index = dataGridProducts.Rows.Count - 1;
                dataGridProducts.Rows[index].SetValues("", id, name,
                               caloriesForHundred, costForHundred, amount, (float)Math.Round(amount * costForHundred / 100.0, 2), (float)Math.Round(amount * caloriesForHundred / 100.0, 2), RowState.New);
            }
            else
            {
                MessageBox.Show("Неправильный формат ввода количества", "Ошибка");
            }

        }

        private void DeleteProduct()
        {
            int index = dataGridProducts.CurrentCell.RowIndex;
            dataGridProducts.Rows[index].Visible = false;
            if (dataGridProducts.Rows[index].Cells[0].Value.ToString() != string.Empty || dataGridProducts.Rows[index].Cells[1].Value.ToString() != string.Empty)
            {
                dataGridProducts.Rows[index].Cells[8].Value = RowState.Existed;
            }
           
        }

        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            DeleteProduct(); 
        }


        private void ChangeProductAmount()
        {
            var index = dataGridProducts.CurrentCell.RowIndex;
            float amount;

            if (dataGridProducts.Rows[index].Cells[0].Value.ToString() != string.Empty || dataGridProducts.Rows[index].Cells[1].Value.ToString() != string.Empty)
            {
                if (float.TryParse(textBoxAmount.Text, out amount))
                {
                    dataGridProducts.Rows[index].Cells[5].Value = amount;
                }
                else
                {
                    MessageBox.Show("Неправильный формат ввода количества", "Ошибка");
                }
            }
        }

        private void btnUpdAmount_Click(object sender, EventArgs e)
        {
            ChangeProductAmount();
        }

        private void textBoxProductsOnly_TextChanged(object sender, EventArgs e)
        {
            SearchProductsOnly(dataGridProductsOnly);
        }
    }
}
