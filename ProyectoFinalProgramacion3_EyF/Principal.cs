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

        private void Principal_Load(object sender, EventArgs e)
        {
            cargarUsuario();
    

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

    } 
}

