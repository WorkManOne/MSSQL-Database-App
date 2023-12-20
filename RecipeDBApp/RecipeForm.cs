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
    public partial class RecipeForm : Form
    {
        private DB dataBase = new DB();
        private int selectedRow;
        int userIDform;
        public RecipeForm(int userID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            userIDform = userID;
            if (userIDform != 0)
            {
                //dataGridConv.Visible = false;
                //dataGridUser.Visible = false;
                comboBoxUser.Visible = false;
                //comboBoxConv.Visible = false;
                //textBoxConv.Visible = false;
                textBoxUser.Visible = false;
                if (userIDform != 0)
                {
                    btnAddProduct.Visible = false;
                    btnDelProduct.Enabled = false;
                    btnDel.Enabled = false;
                    btnUpd.Enabled = false;
                    btnUpdAmount.Enabled = false;

                }
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
        private void CreateColumns()
        {
            dataGridView.Columns.Add("id", "ID");
            dataGridView.Columns.Add("name", "Название рецепта");
            dataGridView.Columns.Add("country_id", "ID Страны");
            dataGridView.Columns.Add("caloriesInAll", "Каллорий всего");
            dataGridView.Columns.Add("description", "Описание");
            dataGridView.Columns.Add("moneyCostMain", "Стоимость");
            dataGridView.Columns.Add("moneyCostOther", "Стоимость (в сторонней валюте)");
            dataGridView.Columns.Add("costConverter_id", "ID Конвертера стоимости");
            dataGridView.Columns.Add("season_id", "ID Сезона");
            dataGridView.Columns.Add("publishedDate", "Дата публикации");
            dataGridView.Columns.Add("publishedBy_id", "ID опубликовавшего");
            dataGridView.Columns.Add("group_id", "ID категории");
            dataGridView.Columns.Add("isNew", String.Empty);
            dataGridView.Columns[12].Visible = false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetString(1), 
                         rec.GetInt32(2), rec.GetFloat(3), 
                         rec.GetString(4), rec.GetFloat(5), 
                         rec.GetFloat(6), rec.GetInt32(7), 
                         rec.GetInt32(8), rec.GetDateTime(9),
                         rec.GetInt32(10), rec.GetInt32(11), RowState.ModifiedNew);
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

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string query;
            if (userIDform != 0 && checkBoxMyRecipe.Checked)
            {
                query = $"SELECT * FROM Recipe WHERE publishedBy_id = {userIDform}";
            }
            else
            {
                query = $"SELECT * FROM Recipe";
            }
            
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void DeleteRow()
        {
            int index = dataGridView.CurrentCell.RowIndex;
            dataGridView.Rows[index].Visible = false;

            if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView.Rows[index].Cells[12].Value = RowState.Deleted;
                return;
            }
            dataGridView.Rows[index].Cells[12].Value = RowState.Deleted;
        }

        private void UpdateData()
        {
            dataBase.openConn();
            int index = dataGridView.CurrentCell.RowIndex;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridView.Rows[i].Cells[12].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);
                    var query = $"DELETE FROM Recipe WHERE id = '{id}'";

                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridView.Rows[i].Cells[0].Value.ToString();
                    var name = dataGridView.Rows[i].Cells[1].Value.ToString();
                    var country_id = dataGridView.Rows[i].Cells[2].Value.ToString();
                    var caloriesInAll = dataGridView.Rows[i].Cells[3].Value.ToString();
                    var description = dataGridView.Rows[i].Cells[4].Value.ToString();
                    var moneyCostMain = dataGridView.Rows[i].Cells[5].Value.ToString();
                    var moneyCostOther = dataGridView.Rows[i].Cells[6].Value.ToString();
                    var costConverter_id = dataGridView.Rows[i].Cells[7].Value.ToString();
                    var season_id = dataGridView.Rows[i].Cells[8].Value.ToString();
                    var publishedDate = dataGridView.Rows[i].Cells[9].Value.ToString();
                    var publishedBy_id = dataGridView.Rows[i].Cells[10].Value.ToString();
                    var group_id = dataGridView.Rows[i].Cells[11].Value.ToString();
                    var query = $"UPDATE Recipe SET name = '{name}', country_id = '{country_id}', caloriesInAll = '{caloriesInAll}', description = '{description}', moneyCostMain = '{moneyCostMain}', moneyCostOther = '{moneyCostOther}', costConverter_id = '{costConverter_id}', season_id = '{season_id}', publishedDate = '{publishedDate}', publishedBy_id = '{publishedBy_id}', group_id = '{group_id}' WHERE id = '{id}'";
                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            //for (int i = 0; i < dataGridProducts.Rows.Count; i++)
            //{
            //    var rowState = (RowState)dataGridProducts.Rows[i].Cells[8].Value;

            //    if (rowState == RowState.Existed)
            //    {
            //        continue;
            //    }
            //    if (rowState == RowState.Deleted)
            //    {
            //        var id = Convert.ToInt32(dataGridProducts.Rows[i].Cells[0].Value);
            //        var query = $"DELETE FROM Product_count WHERE id = '{id}'";

            //        SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            //        command.ExecuteNonQuery();
            //    }
            //    if (rowState == RowState.Modified)
            //    {
            //        var id = dataGridProducts.Rows[i].Cells[0].Value.ToString();
            //        var amount = dataGridProducts.Rows[i].Cells[5].Value.ToString();
            //        var query = $"UPDATE Product_count SET amount = '{amount}' WHERE id = '{id}'";
            //        SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            //        command.ExecuteNonQuery();
            //    }
            //    if (rowState == RowState.New)
            //    {
            //        var recid = dataGridView.Rows[index].Cells[0].Value.ToString();
            //        var id = dataGridProducts.Rows[i].Cells[1].Value.ToString();
            //        var amount = dataGridProducts.Rows[i].Cells[5].Value.ToString();
            //        var query = $"EXEC productRecipeCreate '{id}', '{recid}', '{amount}'";
            //        SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            //        command.ExecuteNonQuery();
            //    }
            //}
            dataBase.closeConn();
        }

        private void ChangeData()
        {
            var RecId = textBox1.Text;
            var name = textBox2.Text;
            var index = dataGridView.CurrentCell.RowIndex;
            var country_id = dataGridCountry.Rows[dataGridCountry.CurrentCell.RowIndex].Cells[0].Value;
            var costConverter_id = dataGridConv.Rows[dataGridConv.CurrentCell.RowIndex].Cells[0].Value;
            var season_id = dataGridSeason.Rows[dataGridSeason.CurrentCell.RowIndex].Cells[0].Value;
            var publishedBy_id = dataGridUser.Rows[dataGridUser.CurrentCell.RowIndex].Cells[0].Value;
            var group_id = dataGridGroup.Rows[dataGridGroup.CurrentCell.RowIndex].Cells[0].Value;
            var caloriesInAll = 0;//FIX==============textBox4.Text;
            var description = textBoxDescr.Text;
            var moneyCostMain = 0; //FIX============== textBox6.Text;
            var moneyCostOther = 0; //FIX============= textBox7.Text;
            
            
            var publishedDate = monthCalendar1.SelectionRange.Start.ToString();

            if (dataGridView.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView.Rows[index].SetValues(RecId, name, 
                    country_id, caloriesInAll, description, 
                    moneyCostMain, moneyCostOther, costConverter_id, 
                    season_id, publishedDate, publishedBy_id, group_id);
                dataGridView.Rows[index].Cells[12].Value = RowState.Modified;
            }

            for (int i = 0; i < dataGridProducts.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridProducts.Rows[i].Cells[8].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridProducts.Rows[i].Cells[0].Value);
                    var query = $"DELETE FROM Product_count WHERE id = '{id}'";

                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridProducts.Rows[i].Cells[0].Value.ToString();
                    var amount = dataGridProducts.Rows[i].Cells[5].Value.ToString();
                    var query = $"UPDATE Product_count SET amount = '{amount}' WHERE id = '{id}'";
                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.New)
                {
                    var recid = dataGridView.Rows[index].Cells[0].Value.ToString();
                    var id = dataGridProducts.Rows[i].Cells[1].Value.ToString();
                    var amount = dataGridProducts.Rows[i].Cells[5].Value.ToString();
                    var query = $"EXEC productRecipeCreate '{id}', '{recid}', '{amount}'";
                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            //if (dataGridView.Rows[index].Cells[0].Value.ToString() != string.Empty)
            //{
            //    if (float.TryParse(textBox3.Text, out priority))
            //    {
            //        dataGridView.Rows[index].SetValues(id, name, priority);
            //        dataGridView.Rows[index].Cells[12].Value = RowState.Modified;
            //    }
            //    else MessageBox.Show("Неправильный формат ввода приоритета", "Ошибка");
            //}
        }

        private void ClearFields()
        {
            textBox1.Clear();
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

        private void SearchConv(DataGridView dgw, bool cellClick)
        {
            dgw.Rows.Clear();
            string query;
            if (cellClick)
            {
                query = $"SELECT id, valMain, valOther FROM CostConverter WHERE {comboBoxConv.Text} = {textBoxConv.Text}";
            }
            else
            {
                query = $"SELECT id, valMain, valOther FROM CostConverter WHERE {comboBoxConv.Text} LIKE '%" + textBoxConv.Text + "%'";
            }

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowConv(dgw, reader);
            }
            reader.Close();

        }

        private void SearchSeason(DataGridView dgw, bool cellClick)
        {
            dgw.Rows.Clear();
            string query;
            if (cellClick)
            {
                query = $"SELECT * FROM Season WHERE {comboBoxSeason.Text} = {textBoxSeason.Text}";
            }
            else
            {
                query = $"SELECT * FROM Season WHERE {comboBoxSeason.Text} LIKE '%" + textBoxSeason.Text + "%'";
            }

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowSeason(dgw, reader);
            }
            reader.Close();

        }

        private void SearchGroup(DataGridView dgw, bool cellClick)
        {
            dgw.Rows.Clear();
            string query;
            if (cellClick)
            {
                query = $"SELECT * FROM Groups WHERE {comboBoxGroup.Text} = {textBoxGroup.Text}";
            }
            else
            {
                query = $"SELECT * FROM Groups WHERE {comboBoxGroup.Text} LIKE '%" + textBoxGroup.Text + "%'";
            }

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowGroup(dgw, reader);
            }
            reader.Close();

        }

        private void SearchCountry(DataGridView dgw, bool cellClick)
        {
            dgw.Rows.Clear();
            string query;
            if (cellClick)
            {
                query = $"SELECT * FROM Country WHERE {comboBoxCountry.Text} = {textBoxCountry.Text}";
            }
            else
            {
                query = $"SELECT * FROM Country WHERE {comboBoxCountry.Text} LIKE '%" + textBoxCountry.Text + "%'";
            }

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowCountry(dgw, reader);
            }
            reader.Close();

        }

        private void SearchUser(DataGridView dgw, bool cellClick)
        {
            dgw.Rows.Clear();
            string query;

            if (cellClick)
            {
                query = $"SELECT id, name FROM Users WHERE {comboBoxUser.Text} = {textBoxUser.Text}";
            }
            else
            {
                query = $"SELECT id, name FROM Users WHERE {comboBoxUser.Text} LIKE '%" + textBoxUser.Text + "%'";
            }
            

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowUser(dgw, reader);
            }
            reader.Close();

        }

        private void SearchProduct(DataGridView dgw)
        {
            selectedRow = dataGridView.CurrentCell.RowIndex;

            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[selectedRow];

                var id = row.Cells[0].Value.ToString();
                string query = $"EXEC showProductsOf {id}";

                dgw.Rows.Clear();
                SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                dataBase.openConn();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReadSingleRowProduct(dgw, reader);
                }
                reader.Close();
            }
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

        private void RecipeForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
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
            RefreshDataGrid(dataGridView);
            SearchProductsOnly(dataGridProductsOnly);
            SearchUser(dataGridUser, false);
            SearchCountry(dataGridCountry, false);
            SearchSeason(dataGridSeason, false);
            SearchGroup(dataGridGroup, false);
            SearchConv(dataGridConv, false);
        }

        private void btnUpdateGrid_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView);
            ClearFields();
        }

        private void RecipeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (userIDform != 0)
            {
                userTools user = new userTools(userIDform);
                user.Show();
            }
            else
            {
                adminTools admintools = new adminTools();
                admintools.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRecipe form = new AddRecipe(userIDform);
            form.Show();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            ChangeData();
            ClearFields();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteRow();
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateData();
            ClearFields();
        }

        private void dataGridRecipes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[selectedRow];
                if (userIDform != 0)
                {
                    if (row.Cells[10].Value.ToString() != userIDform.ToString())
                    {
                        dataBase.openConn();
                        
                        var query = $"INSERT ViewedBy VALUES ('{userIDform}', (SELECT id FROM RecipeViewed WHERE recipe_id = {row.Cells[0].Value.ToString()}), '{DateTime.Today}')";
                        SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                        command.ExecuteNonQuery();
                        dataBase.closeConn();
                        btnAddProduct.Visible = false;
                        btnDelProduct.Enabled = false;
                        btnDel.Enabled = false;
                        
                        btnUpd.Enabled = false;
                        btnUpdAmount.Enabled = false;
                    }
                    else
                    {
                        btnAddProduct.Visible = true;
                        btnDelProduct.Enabled = true;
                        btnDel.Enabled = true;
                        
                        btnUpd.Enabled = true;
                        btnUpdAmount.Enabled = true;
                    }
                }
                comboBoxCountry.SelectedIndex = 0;
                comboBoxUser.SelectedIndex = 0;
                comboBoxGroup.SelectedIndex = 0;
                comboBoxSeason.SelectedIndex = 0;
                comboBoxConv.SelectedIndex = 0;
                comboBoxProductsOnly.SelectedIndex = 0;

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBoxDescr.Text = row.Cells[4].Value.ToString();
                textBoxCountry.Text = row.Cells[2].Value.ToString();
                SearchCountry(dataGridCountry, true);
                textBoxConv.Text = row.Cells[7].Value.ToString();
                SearchConv(dataGridConv, true);
                textBoxSeason.Text = row.Cells[8].Value.ToString();
                SearchSeason(dataGridSeason, true);
                textBoxUser.Text = row.Cells[10].Value.ToString();
                SearchUser(dataGridUser, true);
                textBoxGroup.Text = row.Cells[11].Value.ToString();
                SearchGroup(dataGridGroup, true);
                monthCalendar1.SelectionStart = Convert.ToDateTime(row.Cells[9].Value.ToString());
                SearchProduct(dataGridProducts);
                SearchProductsOnly(dataGridProductsOnly);
            }
        }

        private void dataGridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {
            SearchUser(dataGridUser,false);
        }

        private void textBoxCountry_TextChanged(object sender, EventArgs e)
        {
            SearchCountry(dataGridCountry, false);
        }

        private void textBoxSeason_TextChanged(object sender, EventArgs e)
        {
            SearchSeason(dataGridSeason, false);
        }

        private void textBoxGroup_TextChanged(object sender, EventArgs e)
        {
            SearchGroup(dataGridGroup, false);
        }

        private void textBoxConv_TextChanged(object sender, EventArgs e)
        {
            SearchConv(dataGridConv, false);
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
                if ((RowState)dataGridProducts.Rows[index].Cells[8].Value != RowState.New)
                    dataGridProducts.Rows[index].Cells[8].Value = RowState.Deleted;
                else dataGridProducts.Rows[index].Cells[8].Value = RowState.Existed;
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
                    if ((RowState)dataGridProducts.Rows[index].Cells[8].Value != RowState.New)
                        dataGridProducts.Rows[index].Cells[8].Value = RowState.Modified;
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

        private void checkBoxMyRecipe_CheckedChanged(object sender, EventArgs e)
        {
            ClearFields();
            RefreshDataGrid(dataGridView);
        }
    }
}
