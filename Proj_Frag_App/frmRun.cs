using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Proj_Frag_App
{
    public partial class frmRun : Form
    {
        public frmRun()
        {
            InitializeComponent();
        }

        private void frmRun_Load(object sender, EventArgs e)
        {

        }

        private void btnDist_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Conexion.conectaSQL();
            SqlCommand com = new SqlCommand("", conn);
            com.CommandText = "crear_servidores";
            com.CommandType = CommandType.StoredProcedure;

            String ds_1 = Interaction.InputBox("INGRESE EL DATA SOURCE PARA [AW_PRODUCTION]", "DATA SOURCE 1", "servername.database.windows.net").ToString();
            String ds_2 = Interaction.InputBox("INGRESE EL DATA SOURCE PARA [AW_SALES]", "DATA SOURCE 2", "servername.database.windows.net").ToString();
            String ds_3 = Interaction.InputBox("INGRESE EL DATA SOURCE PARA [AW_OTHERS]", "DATA SOURCE 3", "servername.database.windows.net").ToString();
            String usu = Interaction.InputBox("INGRESE EL USUARIO DE AZURE", "CREDENCIALES", " ").ToString();
            String passw = Interaction.InputBox("INGRESE LA PASSWORD DEL USUARIO", "CREDENCIALES", " ").ToString();

            com.Parameters.AddWithValue("@ds_1", ds_1).Direction = ParameterDirection.Input;
            com.Parameters.AddWithValue("@ds_2", ds_2).Direction = ParameterDirection.Input;
            com.Parameters.AddWithValue("@ds_3", ds_3).Direction = ParameterDirection.Input;
            com.Parameters.AddWithValue("@usu", usu).Direction = ParameterDirection.Input;
            com.Parameters.AddWithValue("@passw", passw).Direction = ParameterDirection.Input;
            try{
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
                ExecSQLfile ex = new ExecSQLfile();
                ex.runSqlScriptFile("../storedProcedures.sql");

                frmPRINCIPAL fC = new frmPRINCIPAL();
                this.Hide();
                fC.Show();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }

            
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Conexion.conectaSQL();
            SqlCommand com = new SqlCommand("", conn);
            com.CommandText = "crear_servidores_local";
            com.CommandType = CommandType.StoredProcedure;

            String ds_1 = Interaction.InputBox("INGRESE EL DATA SOURCE PARA [AW_PRODUCTION]", "DATA SOURCE 1", ".").ToString();
            String ds_2 = Interaction.InputBox("INGRESE EL DATA SOURCE PARA [AW_SALES]", "DATA SOURCE 2", ".").ToString();
            String ds_3 = Interaction.InputBox("INGRESE EL DATA SOURCE PARA [AW_OTHERS]", "DATA SOURCE 3", ".").ToString();

            com.Parameters.AddWithValue("@ds_1", ds_1).Direction = ParameterDirection.Input;
            com.Parameters.AddWithValue("@ds_2", ds_2).Direction = ParameterDirection.Input;
            com.Parameters.AddWithValue("@ds_3", ds_3).Direction = ParameterDirection.Input;
            try
            {
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
                ExecSQLfile ex = new ExecSQLfile();
                ex.runSqlScriptFile("../storedProcedures.sql");

                frmPRINCIPAL fC = new frmPRINCIPAL();
                this.Hide();
                fC.Show();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }
    }
}
