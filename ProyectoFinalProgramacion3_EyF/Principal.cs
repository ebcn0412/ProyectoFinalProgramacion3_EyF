using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.IO;
using ProyectoFinalProgramacion3_EyF.DATOS;
using ProyectoFinalProgramacion3_EyF;
using ProyectoFinalProgramacion3_EyF.ARBOLAVL;

namespace ProyectoFinalProgramacion3_EyF
{
    public partial class Principal : Form
    {
        public listaDoble miLista = new listaDoble();
        Usuario usu;
        usuData usuInfo = new usuData();
        nodoLD nodoList;
        string name, nick, contra, fecha, foto,ruta,ruta2,
            s1,s2,s3,p1,p2,p3;
        int contador = 0;
        bool banderaPrincipal = true;        
        public Principal()
        {
            InitializeComponent();
        }
        public Principal(object datoUsuario,bool bandera)
        {
            InitializeComponent();
            miLista.insertarAlFinal(datoUsuario);
            infoUsuario();
            if (bandera == true)
            {
                banderaPrincipal = false;
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
        public void cargaAvatar()
        {
            panel1.Visible = false;
            pictureBox2.WaitOnLoad = false;
            cargarUsuario();
            pictureBox2.LoadAsync(@"" + foto);
            pictureBox8.LoadAsync(@"" + foto);
            label3.Text = nick;
            label4.Text = name;

        }

        public void irPerfil()
        {
            Perfil salto = new Perfil();
            salto.Show();
            this.Hide();
        }
        public void irLogin()
        {
            Login salto = new Login(banderaPrincipal);
            salto.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            irPerfil();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            irPerfil();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            irLogin();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            irLogin();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            irLogin();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            irLogin();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (banderaPrincipal == false)
                {
                    contador = 3;
                }
                else
                {
                    contador++;
                }
                string ruta = openFileDialog1.FileName;
                StreamWriter info = new StreamWriter("publicaciones.txt",true);
                info.WriteLine(ruta);
                info.Close();


                switch (contador)
                {
                    case 1:
                        pictureBox5.LoadAsync(@"" + ruta);
                        pictureBox5.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case 2:
                        pictureBox6.LoadAsync(@"" + ruta);
                        pictureBox6.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case 3:
                        pictureBox7.LoadAsync(@"" + ruta);
                        pictureBox7.BorderStyle = BorderStyle.FixedSingle;
                        break;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            irPerfil();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            irPerfil();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 salto = new Form1();
            salto.Show();
            this.Hide();
            


        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            irPerfil();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            irLogin();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            irLogin();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            irPerfil();
        }

        public void cargarPublicaciones()
        {
            TextReader leer = new StreamReader("publicaciones.txt");
            ruta = leer.ReadLine();
            ruta2 = leer.ReadLine();
            leer.Close();
        }
        public void publicaciones()
        {
            pictureBox2.WaitOnLoad = false;
            cargarPublicaciones();
            pictureBox5.LoadAsync(@"" + ruta);
            pictureBox5.BorderStyle = BorderStyle.FixedSingle;
            pictureBox6.LoadAsync(@"" + ruta2);
            pictureBox6.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            irPerfil();
        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;

        }
        public void cargarSuger()
        {
            TextReader leer = new StreamReader("sugerencias.txt");
            s1 = leer.ReadLine();
            p1 = leer.ReadLine();
            s2 = leer.ReadLine();
            p2 = leer.ReadLine();
            s3 = leer.ReadLine();
            p3 = leer.ReadLine();
            leer.Close();
        }
        public void suger()
        {
            cargarSuger();
            pictureBox17.LoadAsync(@"" + p1);
            pictureBox20.LoadAsync(@"" + p2);
            pictureBox21.LoadAsync(@"" + p3);
            label6.Text = s1;
            label7.Text = s2;
            label8.Text=s3;
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            if (banderaPrincipal == false)
            {
                cargaAvatar();
                publicaciones();
                suger();
            }
            else
            {
                cargaAvatar();
                suger();

            }

        }
        public void infoUsuario()
        {
            nodoList = (nodoLD)miLista.mostrar();
            string nuevo = nodoList.datoNodo.ToString();
            string[] palabras = nuevo.Split('&');

            int a = 0;

            TextWriter info = new StreamWriter("Temp.txt");

            foreach (string words in palabras)
            {
                a++;
                if (a == 5)
                {
                    info.Write(words);
                }
                else
                    info.WriteLine(words);
            }
            info.Close();
        }
    } 
}

