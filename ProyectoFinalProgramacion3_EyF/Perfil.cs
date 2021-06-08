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

namespace ProyectoFinalProgramacion3_EyF
{
    public partial class Perfil : Form
    {
        string name, nick, contra, fecha, foto;
        public Perfil()
        {
            InitializeComponent();
        }
        public void cargarUsuario()
        {
            TextReader leer = new StreamReader("Temp.txt");
            name = leer.ReadLine();
            nick = leer.ReadLine();
            contra = leer.ReadLine();
            fecha = leer.ReadLine();
            foto = leer.ReadLine();
            leer.Close();
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
            cargaAvatar();
        }
    }
}
