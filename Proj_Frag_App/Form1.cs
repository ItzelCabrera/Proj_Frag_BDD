using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Proj_Frag_App
{
    public partial class frmPRINCIPAL : Form
    {
        int consulta = 0;
        int tipo = 0;
        SqlConnection conn;

        public frmPRINCIPAL()
        {
            InitializeComponent();
            conn = Conexion.conectaSQL();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbtn1.Visible = rbtn2.Visible = rbtn3.Visible = rbtn4.Visible = false;
            pnlConA.Visible = pnlConC.Visible = pnlConE.Visible = pnlConF.Visible = pnlConG.Visible = false;
            btnGO.Enabled = false;
        }

        private void btnUPDATE_Click(object sender, EventArgs e)
        {
            rbtn1.Text = "Actualizar el stock disponible en un 5% de los productos de cierta categoría en una localidad.";
            rbtn2.Text = "Actualizar la cantidad de productos de una orden.";
            rbtn3.Text = "Actualizar el método de envío de una orden.";
            rbtn4.Text = "Actualizar el correo electrónico de una cliente.";
            rbtn1.Visible = rbtn2.Visible = rbtn3.Visible = rbtn4.Visible = true;
            hide_options();
            tipo = 1; 
        }

        private void btnREAD_Click(object sender, EventArgs e)
        {
            rbtn1.Text = "Determinar el total de las ventas de los productos de una categoría para cada territorio.";
            rbtn2.Text = "Determinar el producto más solicitado para la región “Noth America” y en que territorio hay mayor demanda.";
            rbtn3.Text = "Determinar si hay clientes que realizan ordenes en territorios diferentes al que se encuentran.";
            rbtn1.Visible = rbtn2.Visible = rbtn3.Visible = true;
            rbtn4.Visible = false;
            hide_options();
            tipo = 2;

        }

        public void hide_options() {
            rbtn1.Checked = rbtn2.Checked = rbtn3.Checked = rbtn4.Checked = false;
            pnlConA.Visible = pnlConC.Visible = pnlConE.Visible = pnlConF.Visible = pnlConG.Visible = false;
        }

        private void rbtn1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn1.Checked == true)
            {
                rbtn2.Checked = rbtn3.Checked = rbtn4.Checked = false;
                consulta = 1;
            }
            pnl_Refresh();
        }

        private void rbtn2_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtn2.Checked == true)
            {
                rbtn1.Checked = rbtn3.Checked = rbtn4.Checked = false;
                consulta = 2;
            }
            pnl_Refresh();
        }

        private void rbtn3_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtn3.Checked == true)
            {
                rbtn2.Checked = rbtn1.Checked = rbtn4.Checked = false;
                consulta = 3;
            }
            pnl_Refresh();
        }

        private void rbtn4_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtn4.Checked == true)
            {
                rbtn2.Checked = rbtn3.Checked = rbtn1.Checked = false;
                consulta = 4;
            }
            pnl_Refresh();
        }

        public void pnl_Refresh() 
        {
            pnlConA.Visible = pnlConC.Visible = pnlConE.Visible = pnlConF.Visible = pnlConG.Visible = false;
            dataGV.DataSource = null;
            if (tipo != 0 && consulta !=0)
            {
                btnGO.Enabled = true;
            }
            else
            {
                btnGO.Enabled = false;
            }

            switch (tipo)
            {
                case 1:
                    // UPDATE
                    switch (consulta)
                    {
                        case 1:
                            // CONSULTA C
                            pnlConC.Visible = true;
                            break;
                        case 2:
                            // CONSULTA E
                            pnlConE.Visible = true;
                            break;
                        case 3:
                            // CONSULTA F
                            pnlConF.Visible = true;
                            break;
                        case 4:
                            // CONSULTA G
                            pnlConG.Visible = true;
                            break;
                    }
                    break;
                case 2:
                    // READ
                    switch (consulta)
                    {
                        case 1:
                            // CONSULTA A
                            pnlConA.Visible = true;
                            break;
                    }
                    break;
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("", conn);
            DataSet ds = new DataSet();
            String select = "";
            int resultado = 0;

            try
            {
                switch (tipo)
                {
                    case 1:
                        // UPDATE 
                        switch (consulta)
                        {
                            case 1:
                                // CONSULTA C
                                com.CommandText = "cc_updateLocation";
                                com.CommandType = CommandType.StoredProcedure;
                                com.Parameters.AddWithValue("@cat", txtCC1.Text).Direction = ParameterDirection.Input;
                                com.Parameters.AddWithValue("@localidad", txtCC2.Text).Direction = ParameterDirection.Input;
                                conn.Open();
                                resultado = com.ExecuteNonQuery();
                                conn.Close();
                                //vaciar el resultado en el datagrid
                                select = "select * from[LS_AW_PRODUCTION].AW_Production.Production.ProductInventory as pii " +
                                    "where pii.LocationID = " + txtCC2.Text +
                                    "ProductID in (" +
                                    "select ProductID" +
                                    "from[LS_AW_PRODUCTION].AW_Production.Production.ProductSubcategory" +
                                    "where ProductCategoryID = " + txtCC1.Text + ")";
                                var dataAdapter_C= new SqlDataAdapter(select, conn);
                                dataAdapter_C.Fill(ds);
                                dataGV.ReadOnly = true;
                                dataGV.DataSource = ds.Tables[0];
                                break;
                            case 2:
                                // CONSULTA E
                                com.CommandText = "ce_updateSales";
                                com.CommandType = CommandType.StoredProcedure;
                                com.Parameters.AddWithValue("@qty", txtCE1.Text).Direction = ParameterDirection.Input;
                                com.Parameters.AddWithValue("@salesID", txtCE2.Text).Direction = ParameterDirection.Input;
                                com.Parameters.AddWithValue("@productID", txtCE3.Text).Direction = ParameterDirection.Input;
                                conn.Open();
                                resultado = com.ExecuteNonQuery();
                                conn.Close();
                                //vaciar el resultado en el datagrid
                                select = "select * from [LS_AW_SALES].AW_Sales.Sales.SalesOrderDetail " +
                                    "where SalesOrderID = "+ txtCE2.Text + " and ProductID = " + txtCE3.Text;
                                var dataAdapter_E = new SqlDataAdapter(select, conn);
                                dataAdapter_E.Fill(ds);
                                dataGV.ReadOnly = true;
                                dataGV.DataSource = ds.Tables[0];
                                break;
                            case 3:
                                // CONSULTA F
                                com.CommandText = "cf_updateShip"; 
                                com.CommandType = CommandType.StoredProcedure;
                                com.Parameters.AddWithValue("@method", txtCF1.Text).Direction = ParameterDirection.Input;
                                com.Parameters.AddWithValue("@salesID", txtCF2.Text).Direction = ParameterDirection.Input;
                                conn.Open();
                                resultado = com.ExecuteNonQuery();
                                conn.Close();
                                //vaciar el resultado en el datagrid
                                select = "select * from [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader where SalesOrderID = " + txtCF2.Text;
                                var dataAdapter_F = new SqlDataAdapter(select, conn);
                                dataAdapter_F.Fill(ds);
                                dataGV.ReadOnly = true;
                                dataGV.DataSource = ds.Tables[0];
                                break;
                            case 4:
                                // CONSULTA G
                                com.CommandText = "cg_updateEmail";
                                com.CommandType = CommandType.StoredProcedure;
                                com.Parameters.AddWithValue("@customerID", txtCG1.Text).Direction = ParameterDirection.Input;
                                com.Parameters.AddWithValue("@newEmail", txtCG2.Text).Direction = ParameterDirection.Input;
                                conn.Open();
                                resultado = com.ExecuteNonQuery();
                                conn.Close();
                                //vaciar el resultado en el datagrid
                                select = "select * from [LS_AW_OTHERS].AW_Others.Person.EmailAddress where BusinessEntityID = " +
                                    "(select PersonID from [LS_AW_SALES].AW_Sales.Sales.Customer where CustomerID = " + txtCG1.Text + ")";
                                var dataAdapter_G = new SqlDataAdapter(select, conn);
                                dataAdapter_G.Fill(ds);
                                dataGV.ReadOnly = true;
                                dataGV.DataSource = ds.Tables[0];
                                break;
                        }
                        break;
                    case 2:
                        // READ
                        switch (consulta)
                        {
                            case 1:
                                // CONSULTA A
                                com.CommandText = "ca_selectTotalProd";
                                com.CommandType = CommandType.StoredProcedure;
                                com.Parameters.AddWithValue("@cat", txtCA1.Text).Direction = ParameterDirection.Input;
                                conn.Open();
                                com.ExecuteNonQuery();
                                resultado = 1;
                                conn.Close();
                                //vaciar el resultado en el datagrid
                                var dataAdapter_G = new SqlDataAdapter(com);
                                dataAdapter_G.Fill(ds);
                                dataGV.ReadOnly = true;
                                dataGV.DataSource = ds.Tables[0];
                                break;
                            case 2:
                                // CONSULTA B
                                com.CommandText = "cb_selectMostProd";
                                com.CommandType = CommandType.StoredProcedure;
                                conn.Open();
                                com.ExecuteNonQuery();
                                resultado = 1;
                                conn.Close();
                                //vaciar el resultado en el datagrid
                                var dataAdapter_B = new SqlDataAdapter(com);
                                dataAdapter_B.Fill(ds);
                                dataGV.ReadOnly = true;
                                dataGV.DataSource = ds.Tables[0];
                                break;
                            case 3:
                                // CONSULTA D
                                com.CommandText = "cd_TerritoryCli";
                                com.CommandType = CommandType.StoredProcedure;
                                conn.Open();
                                com.ExecuteNonQuery();
                                resultado = 1;
                                conn.Close();
                                //vaciar el resultado en el datagrid
                                var dataAdapter_D = new SqlDataAdapter(com);
                                dataAdapter_D.Fill(ds);
                                dataGV.ReadOnly = true;
                                dataGV.DataSource = ds.Tables[0];
                                break;
                        }
                        break;
                }

                if (resultado > 0)
                {
                    MessageBox.Show("Consulta Ejecutada Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrio un Error en la Ejecución", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }
            
    }
}
