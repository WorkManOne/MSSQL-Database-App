using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace RecipeDBApp
{
    public partial class AddCostConverter : Form
    {
        private DB dataBase = new DB();

        public AddCostConverter()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddCostConverter_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataBase.openConn();

            var valMain = textBox1.Text;
            var valOther = textBox2.Text;

            float parsedValMain, parsedValOther;

            if (float.TryParse(valMain, out parsedValMain) && float.TryParse(valOther, out parsedValOther))
            {
                string query = $"INSERT CostConverter (valMain, valOther) VALUES ('{parsedValMain}', '{parsedValOther}')";
                SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена", "Добавлено");
            }
            else
            {
                MessageBox.Show("Неправильный формат ввода значений валют", "Ошибка");
            }

            dataBase.closeConn();
        }
    }
}


