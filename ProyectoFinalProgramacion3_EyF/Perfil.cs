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
using ProyectoFinalProgramacion3_EyF.DATOS;

namespace ProyectoFinalProgramacion3_EyF
{
    public partial class Perfil : Form
    {
        string name, nick, contra, fecha, foto, ruta,ruta2,ruta3;
        Usuario usu = new Usuario();
        Usuario var;
        bool cambio = true;
        public Perfil()
        {
            InitializeComponent();
        }
        public Perfil(bool banderaPerfil)
        {
            InitializeComponent();
            if (banderaPerfil == false)
            {
                cambio = false;
            }
        }
        public void cargarUsuario()
        {
            TextReader leer = new StreamReader("Temp.txt");
            contra = leer.ReadLine();
            nick = leer.ReadLine();
            name = leer.ReadLine();
            foto = leer.ReadLine();
            fecha = leer.ReadLine();
            leer.Close();
        }
        public void cargarPublicaciones()
        {
            TextReader leer = new StreamReader("publicaciones.txt");
            ruta = leer.ReadLine();
            ruta2 = leer.ReadLine();
            leer.Close();
        }
        public void cargarPublicaciones2()
        {
            TextReader leer = new StreamReader("publicaciones.txt");
            ruta = leer.ReadLine();
            ruta2 = leer.ReadLine();
            ruta3 = leer.ReadLine();
            leer.Close();
        }
        public void publicaciones()
        {
            pictureBox2.WaitOnLoad = false;
            cargarPublicaciones();
            pictureBox3.LoadAsync(@"" + ruta);
            pictureBox4.LoadAsync(@"" + ruta2);
        }
        public void publicaciones2()
        {
            pictureBox2.WaitOnLoad = false;
            cargarPublicaciones2();
            pictureBox3.LoadAsync(@"" + ruta3);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal salto = new Principal();
            salto.Show();
            this.Hide();
        }

        public void cargaAvatar()
        {
            pictureBox2.WaitOnLoad = false;
            cargarUsuario();
            pictureBox2.LoadAsync(@"" + foto);
            label1.Enabled = true;
            label1.Text = nick;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ////boton de buscar

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            if (cambio ==true)
            {
                cargaAvatar();
                publicaciones();
            }
            else
            {
                cargaAvatar();
                publicaciones2();
            }


        }
    }
}
