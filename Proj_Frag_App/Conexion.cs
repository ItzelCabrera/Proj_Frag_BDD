using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proj_Frag_App
{
    class Conexion
    {
        public static SqlConnection conectaSQL()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=master;Integrated Security=true");
            return conn;
        }

        public void desconectaSQL(SqlConnection conn)
        {
            conn.Close();
        }
    }
}
