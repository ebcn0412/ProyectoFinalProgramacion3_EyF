﻿using System;
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
        Usuario[] auxTexto;
        archivos info = new archivos();
        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //boton registrar
            usu = new Usuario(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text,"vacio");

            agregarUsuarioR();

            datoUsuario.insertarDatoUsuario(usu);

                //Ingreso de usuario a mi Txt
                info.CargarDatos(ref auxTexto);
                info.AgregarUsuario(ref auxTexto, textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text, "vacio");
                

                MessageBox.Show("La cuenta se ha creado exitosamente !!");
                cerrar();
          

        }
        public void agregarUsuarioR()
        {
            auxDatoUsuario = new usuData();
            info.CargarDatos(ref auxTexto);


            //MostrarTodo(miUsuarioNuevo2);

            Usuario miUsuario;

            for (int i = 0; i < auxTexto.Length; i++)
            {
                miUsuario = new Usuario(auxTexto[i].nombreCompleto, auxTexto[i].nickname, auxTexto[i].pass, auxTexto[i].fecha,
                    auxTexto[i].foto);


                //La informacion es leida del txt y se inserta denuevo a otra lista
                auxDatoUsuario.insertarDatoUsuario(miUsuario);
            }
        }

        public void cerrar()
        {
            this.Hide();
            Form1 inicio = new Form1();
            inicio.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
