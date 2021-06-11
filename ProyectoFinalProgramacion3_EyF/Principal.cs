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



namespace ProyectoFinalProgramacion3_EyF
{
    public partial class Principal : Form
    {
        public listaDoble miLista = new listaDoble();
        Usuario usu;
        usuData usuInfo = new usuData();
        nodoLD nodoList;
        string name, nick, contra, fecha, foto,ruta,ruta2;
        int contador = 0;
        bool banderaPrincipal = true;
        //Data_movies.ClsPelicula miPelicula;
        //Data_movies.ClsPelicula[] auxPeliculaTxt;
        //Data_movies.ClsPelicula[] auxPeliculaTxt2;
        
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
        }

        public void irPerfil()
        {
          
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
            //buscar usuario

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
                StreamWriter escribirDato = new StreamWriter("publicaciones.txt",true);
                escribirDato.WriteLine(ruta);
                escribirDato.Close();


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



        private void Principal_Load(object sender, EventArgs e)
        {
            if (banderaPrincipal == false)
            {
                cargaAvatar();
                publicaciones();
            }
            else
            {
                cargaAvatar();

            }




        }
        public void infoUsuario()
        {
            nodoList = (nodoLD)miLista.mostrar();
            string nuevo = nodoList.datoNodo.ToString();
            string[] palabras = nuevo.Split('&');

            int a = 0;

            TextWriter escribirDato = new StreamWriter("Temp.txt");

            foreach (string words in palabras)
            {
                a++;
                if (a == 5)
                {
                    escribirDato.Write(words);
                }
                else
                    escribirDato.WriteLine(words);
            }
            escribirDato.Close();
        }

        //perfil
        //public void cargarUsuario()
        //{
        //    TextReader leer = new StreamReader("Temp.txt");

        //    name = leer.ReadLine();
        //    nick = leer.ReadLine();
        //    contra = leer.ReadLine();
        //    fecha = leer.ReadLine();
        //    foto = leer.ReadLine();
        //    leer.Close();
        //}

        //public void cargaAvatar()
        //{
        //    panel1.Visible = false;
        //    pictureBox2.WaitOnLoad = false;

        //    cargarUsuario();

        //    pictureBox2.LoadAsync(@"" + avaUser);

        //    label4.Text = usUser;
        //    label5.Text = nomUser;
        //    label6.Text = corrUser;

        //}

    } 
}

