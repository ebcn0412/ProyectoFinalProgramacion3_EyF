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
    public partial class Login : Form
    {
        Usuario usu;
        usuData usuInfo = new usuData();
        Usuario[] auxTexto;
        archivos info = new archivos();
        object data;
        bool bandera;
        public Login()
        {
            InitializeComponent();
        }
        public Login(bool recibo)
        {
            InitializeComponent();
            bandera = recibo;
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
                    MessageBox.Show("Bienvenido Usuario", "Login exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    data = usuInfo.buscarDatosCompletos(usu);
                    Principal irA = new Principal(data,bandera);
                    this.Hide();
                    irA.Show();
                }

                else { MessageBox.Show("No esta registrado en nuestros registros", "Error al iniciar", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            
            //boton para agregar
            

        }

        void usuarioInfo()
        {
            info.CargarDatos(ref auxTexto);
            //MostrarTodo(miUsuarioNuevo2);

            Usuario miUsuario;
            for (int index = 0; index < auxTexto.Length; index++)
            {
                miUsuario = new Usuario(auxTexto[index].pass, auxTexto[index].nickname, auxTexto[index].nombreCompleto, auxTexto[index].foto,  auxTexto[index].fecha);
                //Se la informacion leida de un txt se inserta denuevo a otra lista
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
