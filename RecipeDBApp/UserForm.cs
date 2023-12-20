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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace RecipeDBApp
{
    public partial class UserForm : Form
    {
        private DB dataBase = new DB();
        private int selectedRow;

        public UserForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridUser.Columns.Add("id", "ID");
            dataGridUser.Columns.Add("name", "Имя пользователя");
            dataGridUser.Columns.Add("registeredAt", "Дата регистрации");
            dataGridUser.Columns.Add("amountPublished", "Количество публикаций");
            dataGridUser.Columns.Add("pass", "Пароль");
            dataGridUser.Columns.Add("isNew", String.Empty);
            dataGridUser.Columns[5].Visible = false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetString(1), rec.GetDateTime(2), rec.GetInt32(3), rec.GetString(4), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = "SELECT * FROM Users";
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
            int index = dataGridUser.CurrentCell.RowIndex;
            dataGridUser.Rows[index].Visible = false;

            if (dataGridUser.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridUser.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }
            dataGridUser.Rows[index].Cells[5].Value = RowState.Deleted;
        }

        private void UpdateData()
        {
            dataBase.openConn();

            for (int i = 0; i < dataGridUser.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridUser.Rows[i].Cells[5].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridUser.Rows[i].Cells[0].Value);
                    var query = $"DELETE FROM Users WHERE id = '{id}'";

                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridUser.Rows[i].Cells[0].Value.ToString();
                    var name = dataGridUser.Rows[i].Cells[1].Value.ToString();
                    var registeredAt = dataGridUser.Rows[i].Cells[2].Value.ToString();
                    var amountPublished = dataGridUser.Rows[i].Cells[3].Value.ToString();
                    var pass = dataGridUser.Rows[i].Cells[4].Value.ToString();

                    var query = $"UPDATE Users SET name = '{name}', registeredAt = '{registeredAt}', amountPublished = '{amountPublished}', pass = '{pass}' WHERE id = '{id}'";
                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConn();
        }

        private void ChangeData()
        {
            var index = dataGridUser.CurrentCell.RowIndex;

            var id = textBox1.Text;
            var name = textBox2.Text;
            var registeredAt = monthCalendar1.SelectionRange.Start.ToString();
            var amountPublished = textBox4.Text;
            var pass = textBox5.Text;

            if (dataGridUser.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridUser.Rows[index].SetValues(id, name, registeredAt, amountPublished, pass);
                dataGridUser.Rows[index].Cells[5].Value = RowState.Modified;
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            monthCalendar1.SelectionStart = DateTime.Today;
            textBox4.Clear();
            textBox5.Clear();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridUser);

            selectedRow = dataGridUser.CurrentCell.RowIndex;

            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridUser.Rows[selectedRow];
                monthCalendar1.SelectionStart = Convert.ToDateTime(row.Cells[2].Value.ToString());
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnUpdateGrid_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridUser);
            ClearFields();
        }

        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            adminTools adminTools = new adminTools();
            adminTools.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
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

        private void dataGridUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridUser.Rows[selectedRow];
                monthCalendar1.SelectionStart = Convert.ToDateTime(row.Cells[2].Value.ToString());
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}
