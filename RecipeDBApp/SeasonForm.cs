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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace RecipeDBApp
{
    public partial class SeasonForm : Form
    {
        private DB dataBase = new DB();
        private int selectedRow;
        int userIDform;
        public SeasonForm(int userID)
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
            dataGridSeason.Columns.Add("id", "ID");
            dataGridSeason.Columns.Add("name", "Название");
            dataGridSeason.Columns.Add("dateStart", "Дата начала");
            dataGridSeason.Columns.Add("dateEnd", "Дата окончания");
            dataGridSeason.Columns.Add("isNew", String.Empty);
            dataGridSeason.Columns[4].Visible = false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetString(1), rec.GetDateTime(2).ToShortDateString(), rec.GetDateTime(3).ToShortDateString(), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = "SELECT * FROM Season";
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
            int index = dataGridSeason.CurrentCell.RowIndex;
            dataGridSeason.Rows[index].Visible = false;

            if (dataGridSeason.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridSeason.Rows[index].Cells[4].Value = RowState.Deleted;
                return;
            }
            dataGridSeason.Rows[index].Cells[4].Value = RowState.Deleted;
        }

        private void UpdateData()
        {
            dataBase.openConn();

            for (int i = 0; i < dataGridSeason.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridSeason.Rows[i].Cells[4].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridSeason.Rows[i].Cells[0].Value);
                    var query = $"DELETE FROM Season WHERE id = '{id}'";

                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridSeason.Rows[i].Cells[0].Value.ToString();
                    var name = dataGridSeason.Rows[i].Cells[1].Value.ToString();
                    var dateStart = dataGridSeason.Rows[i].Cells[2].Value.ToString();
                    var dateEnd = dataGridSeason.Rows[i].Cells[3].Value.ToString();

                    var query = $"UPDATE Season SET name = '{name}', dateStart = '{dateStart}', dateEnd = '{dateEnd}' WHERE id = '{id}'";
                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConn();
        }

        private void ChangeData()
        {
            var index = dataGridSeason.CurrentCell.RowIndex;

            var id = textBox1.Text;
            var name = textBox2.Text;
            var dateStart = monthCalendar1.SelectionRange.Start.ToString();
            var dateEnd = monthCalendar2.SelectionRange.Start.ToString();

            if (dataGridSeason.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridSeason.Rows[index].SetValues(id, name, dateStart, dateEnd);
                dataGridSeason.Rows[index].Cells[4].Value = RowState.Modified;
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            monthCalendar1.SelectionStart = DateTime.Today;
            monthCalendar2.SelectionStart = DateTime.Today;
        }

        private void SeasonForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridSeason);

            //selectedRow = dataGridSeason.CurrentCell.RowIndex;

            //if (selectedRow >= 0)
            //{
            //    DataGridViewRow row = dataGridSeason.Rows[selectedRow];

            //    textBox1.Text = row.Cells[0].Value.ToString();
            //    textBox2.Text = row.Cells[1].Value.ToString();
            //    monthCalendar1.SelectionStart = Convert.ToDateTime(row.Cells[2].Value.ToString());
            //    monthCalendar2.SelectionStart = Convert.ToDateTime(row.Cells[3].Value.ToString());
            //}
        }

        private void btnUpdateGrid_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridSeason);
            ClearFields();
        }

        private void SeasonForm_FormClosed(object sender, FormClosedEventArgs e)
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
            AddSeason addSeason = new AddSeason();
            addSeason.Show();
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

        private void dataGridSeason_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridSeason.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                monthCalendar1.SelectionStart = Convert.ToDateTime(row.Cells[2].Value.ToString());
                monthCalendar2.SelectionStart = Convert.ToDateTime(row.Cells[3].Value.ToString());
            }
        }
    }
}
