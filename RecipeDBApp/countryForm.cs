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
    enum RowState
    {
        Existed, New, Modified, ModifiedNew, Deleted
    }
    public partial class countryForm : Form
    {
        DB dataBase = new DB();
        int selectedRow;
        int userIDform;
        public countryForm(int userID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            userIDform = userID;
            if (userIDform != 0)
            {
                btnDel.Visible = false;
                btnUpd.Visible = false;
            }
        }

        private void CreateColumns()
        {
            dataGridCountry.Columns.Add("id", "id");
            dataGridCountry.Columns.Add("name", "Название страны");
            dataGridCountry.Columns.Add("nation", "Национальность блюда");
            dataGridCountry.Columns.Add("isNew", String.Empty);
            dataGridCountry.Columns[3].Visible = false;

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetString(1), rec.GetString(2), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT * FROM Country";
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
            int index = dataGridCountry.CurrentCell.RowIndex;
            dataGridCountry.Rows[index].Visible= false;

            if (dataGridCountry.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridCountry.Rows[index].Cells[3].Value = RowState.Deleted;
                return;
            }
            dataGridCountry.Rows[index].Cells[3].Value = RowState.Deleted;
        }

        private void Update()
        {
            dataBase.openConn();

            for (int i = 0; i < dataGridCountry.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridCountry.Rows[i].Cells[3].Value;

                if (rowState == RowState.Existed) 
                {
                    continue;
                }
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridCountry.Rows[i].Cells[0].Value);
                    var query = $"DELETE FROM Country WHERE id = '{id}'";

                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
              
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridCountry.Rows[i].Cells[0].Value.ToString();
                    var name = dataGridCountry.Rows[i].Cells[1].Value.ToString();
                    var nation = dataGridCountry.Rows[i].Cells[2].Value.ToString();

                    var query = $"UPDATE Country SET name = '{name}', primaryNation = '{nation}' WHERE id = '{id}'";
                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConn();
        }

        private void Change()
        {
            var index = dataGridCountry.CurrentCell.RowIndex;


            var id = textBox1.Text;
            var name = textBox2.Text;
            var nation = textBox3.Text;

            if (dataGridCountry.Rows[index].Cells[0].Value.ToString() != string.Empty) 
            {
                dataGridCountry.Rows[index].SetValues(id, name, nation);
                dataGridCountry.Rows[index].Cells[3].Value = RowState.Modified;
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void countryForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridCountry);

            //selectedRow = dataGridCountry.CurrentCell.RowIndex;

            //if (selectedRow >= 0)
            //{
            //    DataGridViewRow row = dataGridCountry.Rows[selectedRow];

            //    textBox1.Text = row.Cells[0].Value.ToString();
            //    textBox2.Text = row.Cells[1].Value.ToString();
            //    textBox3.Text = row.Cells[2].Value.ToString();
            //}
        }

        private void btnUpdateGrid_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridCountry);
            ClearFields();

        }

        private void countryForm_FormClosed(object sender, FormClosedEventArgs e)
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
            AddCountry add = new AddCountry();
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
                DataGridViewRow row = dataGridCountry.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}
