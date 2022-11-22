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
            rbtn1.Text = "Actualizar el stock disponible en un 5% de los productos de la categoría que se provea como argumento de entrada en una 
localidad que se provea como entrada en la instrucción de actualización. "                                                                                                                                                                                                                      
            rbtn1.Visible = rbtn2.Visible = rbtn3.Visible = rbtn4.Visible = true;
        }

        private void btnREAD_Click(object sender, EventArgs e)
        {

        }
    }
}
