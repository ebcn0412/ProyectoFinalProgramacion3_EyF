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
        nodoLD nodoList;
        string name, nick, contra, fecha, foto;
        bool regreso = true;
        //Data_movies.ClsPelicula miPelicula;
        //Data_movies.ClsPelicula[] auxPeliculaTxt;
        //Data_movies.ClsPelicula[] auxPeliculaTxt2;
        
        public Principal()
        {
            InitializeComponent();
        }
        public Principal(object datoUsuario)
        {
            InitializeComponent();
            miLista.insertarAlFinal(datoUsuario);
            infoUsuario();
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
            Perfil salto = new Perfil();
            salto.Show();
            this.Hide();
        }
        public void irLogin()
        {
            Login salto = new Login(regreso);
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
            cargaAvatar();
    

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

