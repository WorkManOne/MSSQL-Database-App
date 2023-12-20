using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RecipeDBApp
{
    internal class DB
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-K2KD3O6\SQLEXPRESS;Initial Catalog=RecipeDB;Integrated Security=True");

        public void openConn()
        {
            if (conn.State == System.Data.ConnectionState.Closed) 
            {
                conn.Open();
            }
        }

        public void closeConn()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return conn;
        }
    }
}
