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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int cont = 0;
        int dato = 0;
        int datb = 0;
        int cont2 = 0;

        DibujarAVL arbolAVL = new DibujarAVL(null);
        DibujarAVL arbolAVL_Letra = new DibujarAVL(null);
        Graphics g;

        private void Form1_Paint(object sender, PaintEventArgs en)
        {
            en.Graphics.Clear(this.BackColor);
            en.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            en.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = en.Graphics;

            arbolAVL.DibujarArbol(g, this.Font, Brushes.White, Brushes.Black, Pens.White, datb, Brushes.Black);
            datb = 0;

            if (pintaR == 1)
            {
                arbolAVL.color(g, this.Font, Brushes.White, Brushes.Yellow, Pens.Blue, arbolAVL.Raiz, post.Checked, Ino.Checked, pre.Checked);
            }
            if (pintaR == 2)
            {
                arbolAVL.colorearB(g, this.Font, Brushes.White, Brushes.Red, Pens.White, arbolAVL.Raiz, int.Parse(valor.Text));
            }
            pintaR = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            errores.Clear();
            try
            {
                StreamReader reader = new StreamReader("arbol.txt");
                for (int i = 0; i < 106; i++)
                {
                    dato = int.Parse(reader.ReadLine());
                    arbolAVL.insertar(dato);
                    valor.Clear();
                    valor.Focus();
                    lblaltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    cont++;
                    Refresh();
                    Refresh();
                }
                reader.Close();
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message);
                errores.SetError(valor, "Debe ser numerico");
            }
        }
        int pintaR = 0;


        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "Valor obligatorio");
            }
            else
            {
                try
                {
                    datb = int.Parse(valor.Text);
                    arbolAVL.buscar(datb);
                    pintaR = 2;
                    Refresh();
                    valor.Clear();
                }
                catch (Exception)
                {
                    errores.SetError(valor, "Debe ser numerico");
                }
            }
        }

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "Valor obligatorio");

            }
            else
            {
                try
                {
                    dato = int.Parse(valor.Text);
                    valor.Clear();
                    arbolAVL.Eliminar(dato);
                    if (arbolAVL.Raiz != null)
                        lblaltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    Refresh();
                    Refresh();
                    cont2++;

                }
                catch (Exception ms)
                {

                    errores.SetError(valor, "Debe ser numerico");
                }
            }
            Refresh(); Refresh(); Refresh();
        }

        private void pre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Principal salto = new Principal();
            salto.Show();
            this.Hide();
        }
        private void pre_Click(object sender, EventArgs e)
        {
            pintaR = 1;
            this.Refresh();
        }
    }
}

