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
    public partial class CostConverterForm : Form
    {
        private DB dataBase = new DB();
        private int selectedRow;

        public CostConverterForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView.Columns.Add("id", "ID");
            dataGridView.Columns.Add("valMain", "Значение основной валюты");
            dataGridView.Columns.Add("valOther", "Значение другой валюты");
            dataGridView.Columns.Add("isNew", String.Empty);
            dataGridView.Columns[3].Visible = false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord rec)
        {
            dgw.Rows.Add(rec.GetInt32(0), rec.GetFloat(1), rec.GetFloat(2), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = "SELECT * FROM CostConverter";
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
                dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                return;
            }
            dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
        }

        private void UpdateData()
        {
            dataBase.openConn();

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridView.Rows[i].Cells[3].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);
                    var query = $"DELETE FROM CostConverter WHERE id = '{id}'";

                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridView.Rows[i].Cells[0].Value.ToString();
                    float valMain;
                    float.TryParse(dataGridView.Rows[i].Cells[1].Value.ToString(), out valMain);
                    float valOther;
                    float.TryParse(dataGridView.Rows[i].Cells[2].Value.ToString(), out valOther);

                    var query = $"UPDATE CostConverter SET valMain = '{valMain}', valOther = '{valOther}' WHERE id = '{id}'";
                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConn();
        }

        private void ChangeData()
        {
            var index = dataGridView.CurrentCell.RowIndex;

            var id = textBox1.Text;
            float valMain;
            float valOther;

            if (dataGridView.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                if (float.TryParse(textBox2.Text, out valMain) && float.TryParse(textBox3.Text, out valOther))
                {
                    dataGridView.Rows[index].SetValues(id, valMain, valOther);
                    dataGridView.Rows[index].Cells[3].Value = RowState.Modified;
                }
                else MessageBox.Show("Неправильный формат ввода значений валют", "Ошибка");
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void costConverterForm_Load(object sender, EventArgs e)
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
            //}
        }

        private void btnUpdateGrid_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView);
            ClearFields();
        }

        private void costConverterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            adminTools adminTools = new adminTools();
            adminTools.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCostConverter addCostConverter = new AddCostConverter();
            addCostConverter.Show();
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

        private void dataGridCostConverter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}
