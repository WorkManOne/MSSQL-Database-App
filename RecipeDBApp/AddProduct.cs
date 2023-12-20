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
    public partial class AddProduct : Form
    {
        DB dataBase = new DB();
        public AddProduct()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 200;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataBase.openConn();

            var name = textBox1.Text;
            float cost;
            float calo;

            if (float.TryParse(textBox2.Text, out cost))
            {
                if (float.TryParse(textBox3.Text, out calo))
                {
                    string query = $"INSERT Product (name, costForHundred, caloriesForHundred) VALUES ('{name}', '{cost}', '{calo}')";
                    SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись добавлена", "Добавлено");
                }
                else MessageBox.Show("Неправильный формат ввода калорий", "Ошибка");
            }
            else MessageBox.Show("Неправильный формат ввода цены", "Ошибка");
            
            dataBase.closeConn();
        }
    }
}
