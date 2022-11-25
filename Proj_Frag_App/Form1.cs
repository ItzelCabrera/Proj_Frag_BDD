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
            pnlConA.Visible = pnlConE.Visible = pnlConF.Visible = pnlConG.Visible = false;
            btnGO.Enabled = false;
        }

        private void btnUPDATE_Click(object sender, EventArgs e)
        {
            rbtn1.Text = "Actualizar el stock disponible en un 5% de los productos de cierta categoría en una localidad.";
            rbtn2.Text = "Actualizar la cantidad de productos de una orden.";
            rbtn3.Text = "Actualizar el método de envío de una orden.";
            rbtn4.Text = "Actualizar el correo electrónico de una cliente.";
            rbtn1.Visible = rbtn2.Visible = rbtn3.Visible = rbtn4.Visible = true;
            tipo = 1; 
        }

        private void btnREAD_Click(object sender, EventArgs e)
        {
            rbtn1.Text = "Determinar el total de las ventas de los productos de una categoría para cada territorio.";
            rbtn2.Text = "Determinar el producto más solicitado para la región “Noth America” y en que territorio hay mayor demanda.";
            rbtn3.Text = "Determinar si hay clientes que realizan ordenes en territorios diferentes al que se encuentran.";
            rbtn1.Visible = rbtn2.Visible = rbtn3.Visible = true;
            rbtn4.Visible = false;
            tipo = 2;
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
            pnlConA.Visible = pnlConE.Visible = pnlConF.Visible = pnlConG.Visible = false;

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
                            // CONSULTA
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
                        case 2:
                            // CONSULTA
                            break;
                        case 3:
                            // CONSULTA
                            break;
                    }
                    break;
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("", conn);
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
                                // CONSULTA
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
                                resultado = com.ExecuteNonQuery();
                                conn.Close();
                                break;
                            case 2:
                                // CONSULTA
                                break;
                            case 3:
                                // CONSULTA
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
            }
        }

    }
}
