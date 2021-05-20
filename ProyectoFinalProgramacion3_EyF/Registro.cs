using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalProgramacion3_EyF
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lista.BuscarDatos(txtCorreo.Text) == true)
            {
                lista.Crear_Cuentas(txtCorreo.Text, txtContraseña.Text);
                lista.Datos_Modificados();
                this.Visible = false;
                LOGIN LOG = new LOGIN();
                LOG.Show();
            }
            else
            {
                MessageBox.Show("Usuario Duplicado");
                txtCorreo.Text = "";
                txtContraseña.Text = "";
            }

        }
    }
}
