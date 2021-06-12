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
        Usuario usu;
        usuData datoUsuario = new usuData();
        usuData auxDatoUsuario;
        Usuario[] varTex;
        archivos info = new archivos();
        string variable;
        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            usu = new Usuario(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text,variable);

            agregarUsuarioR();

            datoUsuario.insertarDatoUsuario(usu);
                info.CargarDatos(ref varTex);
                info.AgregarUsuario(ref varTex, textBox4.Text, textBox2.Text, textBox1.Text,variable, textBox3.Text);
                MessageBox.Show("La cuenta se ha creado exitosamente !!");
                cerrar();
          

        }
        public void agregarUsuarioR()
        {
            auxDatoUsuario = new usuData();
            info.CargarDatos(ref varTex);
            Usuario miUsuario;

            for (int i = 0; i < varTex.Length; i++)
            {
                miUsuario = new Usuario(varTex[i].pass, varTex[i].nickname, varTex[i].nombreCompleto, varTex[i].foto,
                    varTex[i].fecha);
                auxDatoUsuario.insertarDatoUsuario(miUsuario);
            }
        }

        public void cerrar()
        {
            this.Hide();
            Login inicio = new Login();
            inicio.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                variable = openFileDialog1.FileName;
            }
            pictureBox2.LoadAsync(@"" + variable);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

    }
}
