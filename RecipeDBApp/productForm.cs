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
    //enum RowState
    //{
    //    Existed, New, Modified, ModifiedNew, Deleted
    //}
    public partial class productForm : Form
    {
        DB dataBase = new DB();
        int selectedRow;
        int userIDform;
        public productForm(int userID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            userIDform = userID;
            if (userIDform != 0 )
            {
                btnDel.Visible= false;
                btnUpd.Visible= false;
            }
        }

        private void CreateColumns()
        {
            dataGridView.Columns.Add("id", "id");
            dataGridView.Columns.Add("name", "Название продукта");
            dataGridView.Columns.Add("costForHundred", "Cтоимость за 100 гр");
            dataGridView.Columns.Add("caloriesForHundred", "Каллорий в 100 гр");
            dataGridView.Columns.Add("isNew", String.Empty);
            dataGridView.Columns[4].Visible = false;

        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetString(1), rec.GetFloat(2), rec.GetFloat(3), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT * FROM Product";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConn();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void deleteRow()
        {
            int index = dataGridView.CurrentCell.RowIndex;
            dataGridView.Rows[index].Visible= false;

            if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                return;
            }
            dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
        }

        private void Update()
        {
            dataBase.openConn();

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridView.Rows[i].Cells[4].Value;

                if (rowState == RowState.Existed) 
                {
                    continue;
                }
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);
                    var query = $"DELETE FROM Product WHERE id = '{id}'";

                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
              
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridView.Rows[i].Cells[0].Value.ToString();
                    var name = dataGridView.Rows[i].Cells[1].Value.ToString();
                    var cost = dataGridView.Rows[i].Cells[2].Value.ToString();
                    var calo = dataGridView.Rows[i].Cells[3].Value.ToString();
                    

                    var query = $"UPDATE Product SET name = '{name}', cost = '{cost}', calo = '{calo}' WHERE id = '{id}'";
                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConn();
        }

        private void Change()
        {
            var index = dataGridView.CurrentCell.RowIndex;


            var id = textBox1.Text;
            var name = textBox2.Text;
            float cost;
            float calo;

            if (dataGridView.Rows[index].Cells[0].Value.ToString() != string.Empty) 
            {
                if (float.TryParse(textBox3.Text, out cost))
                {
                    if (float.TryParse(textBox4.Text, out calo))
                    {
                        dataGridView.Rows[index].SetValues(id, name, cost, calo);
                        dataGridView.Rows[index].Cells[4].Value = RowState.Modified;
                    }
                    else MessageBox.Show("Неправильный формат ввода калорий", "Ошибка");
                }
                else MessageBox.Show("Неправильный формат ввода цены", "Ошибка");
            }
        }


        private void productForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView);

            //selectedRow = dataGridView.CurrentCell.RowIndex;

            //if (selectedRow >= 0)
            //{
            //    DataGridViewRow row = dataGridView.Rows[selectedRow];

            //    textBox1.Text = row.Cells[0].Value.ToString();
            //    textBox2.Text = row.Cells[1].Value.ToString();
            //    textBox3.Text = row.Cells[2].Value.ToString();
            //    textBox4.Text = row.Cells[3].Value.ToString();
            //}
        }

        private void btnUpdateGrid_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView);
            ClearFields();

        }

        private void productForm_FormClosed(object sender, FormClosedEventArgs e)
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
            AddProduct add = new AddProduct();
            add.Show();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Update();
            ClearFields();
        }

        private void dataGridCountry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}
