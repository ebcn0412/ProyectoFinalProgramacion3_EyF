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
    public partial class Seguidores : Form
    {
        string ruta, ruta2, ruta3, ruta4, ruta5, ruta6, ruta7, ruta8, ruta9, ruta10, ruta11, ruta12, ruta13, ruta14;
        string us1, us2, us3, us4, us5, us6, us7, us8, us9, us10, us11, us12, us13, us14;
        public Seguidores()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void cargarSeguidores()
        {
            TextReader leer = new StreamReader("seguidos.txt");
            ruta = leer.ReadLine();
            us1 = leer.ReadLine();
            ruta2 = leer.ReadLine();
            us2 = leer.ReadLine();
            ruta3 = leer.ReadLine();
            us3 = leer.ReadLine();
            ruta4 = leer.ReadLine();
            us4 = leer.ReadLine();
            ruta5 = leer.ReadLine();
            us5 = leer.ReadLine();
            ruta6 = leer.ReadLine();
            us6 = leer.ReadLine();
            ruta7 = leer.ReadLine();
            us7 = leer.ReadLine();
            ruta8 = leer.ReadLine();
            us8 = leer.ReadLine();
            ruta9 = leer.ReadLine();
            us9 = leer.ReadLine();
            ruta10 = leer.ReadLine();
            us10 = leer.ReadLine();
            ruta11 = leer.ReadLine();
            us11 = leer.ReadLine();
            ruta12 = leer.ReadLine();
            us12 = leer.ReadLine();
            ruta13 = leer.ReadLine();
            us13 = leer.ReadLine();
            ruta14 = leer.ReadLine();us14 = leer.ReadLine();
            leer.Close();
        }

        public void cargarDatos()
        {
            pictureBox2.WaitOnLoad = false;
            cargarSeguidores();
            pictureBox1.LoadAsync(@"" + us1); pictureBox2.LoadAsync(@"" + us2); pictureBox3.LoadAsync(@"" + us3); pictureBox4.LoadAsync(@"" + us4);
            pictureBox5.LoadAsync(@"" + us5); pictureBox6.LoadAsync(@"" + us6); pictureBox7.LoadAsync(@"" + us7); pictureBox8.LoadAsync(@"" + us8); pictureBox9.LoadAsync(@"" + us9);
            pictureBox10.LoadAsync(@"" + us10); pictureBox11.LoadAsync(@"" + us11); pictureBox12.LoadAsync(@"" + us12); pictureBox13.LoadAsync(@"" + us13); pictureBox14.LoadAsync(@"" + us14);
            label17.Text = ruta; label2.Text = ruta2; label3.Text = ruta3; label4.Text = ruta4; label5.Text = ruta5; label10.Text = ruta6; label7.Text = ruta7; label9.Text = ruta8; label11.Text = ruta9; label12.Text = ruta10;
            label13.Text = ruta11; label14.Text = ruta12; label15.Text = ruta13; label16.Text = ruta14; 
        }

        private void Seguidores_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
