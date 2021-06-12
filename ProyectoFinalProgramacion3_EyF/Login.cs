using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ProyectoFinalProgramacion3_EyF.ARBOLAVL;


namespace ProyectoFinalProgramacion3_EyF
{
    public partial class Login : Form
    {
        ArbolAvl miArbol = new ArbolAvl();
        Usuario usu;
        usuData usuInfo = new usuData();
        Usuario[] varTex;
        archivos info = new archivos();
        object data;
        bool bandera = false;
        public Login()
        {
            InitializeComponent();
        }

        public Login(bool vieneDePrincipal)
        {
            InitializeComponent();
            if (vieneDePrincipal == true)
            {
                bandera = true;
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    

        private void button1_Click(object sender, EventArgs e)
        {
                //boton para agregar
                usu = new Usuario(textBox2.Text, textBox1.Text);

                usuarioInfo();

                if (usuInfo.buscarDatosCompletos(usu) != null)
                {
                    MessageBox.Show("Bienvenido", "Login exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    data = usuInfo.buscarDatosCompletos(usu);
                    Principal irA = new Principal(data, bandera);
                    this.Hide();
                    irA.Show();
                }

                else { MessageBox.Show("No esta registrado en nuestros registros", "Error al iniciar", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            

        }

        void usuarioInfo()
        {
            info.CargarDatos(ref varTex);
            Usuario miUsuario;
            for (int i = 0; i < varTex.Length; i++)
            {
                miUsuario = new Usuario(varTex[i].pass, varTex[i].nickname, varTex[i].nombreCompleto, varTex[i].foto,  varTex[i].fecha);
                usuInfo.insertarDatoUsuario(miUsuario);
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Hide();
            Registro irRegistro = new Registro();
            irRegistro.Show();

        }


        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
