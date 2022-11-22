using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj_Frag_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbtn1.Visible = rbtn2.Visible = rbtn3.Visible = rbtn4.Visible = false;
        }

        private void btnUPDATE_Click(object sender, EventArgs e)
        {
            rbtn1.Text = "Actualizar el stock disponible en un 5% de los productos de cierta categoría en una localidad.";
            rbtn2.Text = "Actualizar la cantidad de productos de una orden.";
            rbtn3.Text = "Actualizar el método de envío de una orden.";
            rbtn4.Text = "Actualizar el correo electrónico de una cliente.";
            rbtn1.Visible = rbtn2.Visible = rbtn3.Visible = rbtn4.Visible = true;
        }

        private void btnREAD_Click(object sender, EventArgs e)
        {
            rbtn1.Text = "Determinar el total de las ventas de los productos de una categoría para cada territorio.";
            rbtn2.Text = "Determinar el producto más solicitado para la región “Noth America” y en que territorio hay mayor demanda.";
            rbtn3.Text = "Determinar si hay clientes que realizan ordenes en territorios diferentes al que se encuentran.";
            rbtn1.Visible = rbtn2.Visible = rbtn3.Visible = true;
            rbtn4.Visible = false;
        }
    }
}
