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
    public partial class AddGroup : Form
    {
        private DB dataBase = new DB();

        public AddGroup()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddGroup_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 200;
        }

        private void btnSave_Click(object sender, EventArgs e)
		{
			dataBase.openConn();

			var name = textBox1.Text;
			float priority;
			if (float.TryParse(textBox2.Text, out priority))
			{
				string query = $"INSERT Groups (name, priority) VALUES ('{name}', {priority})";
				SqlCommand command = new SqlCommand(query, dataBase.getConnection());
				command.ExecuteNonQuery();
				MessageBox.Show("Запись добавлена", "Добавлено");
			}
			else
			{
				MessageBox.Show("Неправильный формат ввода приоритета", "Ошибка");
			}

			dataBase.closeConn();
		}

    }
}
