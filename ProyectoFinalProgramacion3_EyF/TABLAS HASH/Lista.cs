using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgramacion3_EyF.TABLAS_HASH
{
    class Lista
    {
        public Nodo inicio;

        public Lista()
        {
            inicio = null;
        }

        public Lista insertarinicio(Object vDato)
        {
            Nodo nuevo;
            nuevo = new Nodo(vDato);
            nuevo.Enlace = inicio;
            inicio = nuevo;
            return this;
        }

        public Object BuscarNodo(Object pValor)
        {
            Nodo dato = inicio;
            int posicion = 1;

            //converId = temp.Dato = Juan = 108104;
            while (dato != null && !converId(dato.Dato.ToString()).Equals(pValor))
            {
                dato = dato.Enlace;
                posicion++;
            }
            //return (temp == null) ? null : converId(temp.Dato.ToString());
            return (dato == null) ? null : dato.Dato;
        }

        public string converId(string user)
        {
            byte[] asscInt = Encoding.ASCII.GetBytes(user);
            string cadena = "";
            foreach (byte item in asscInt)
            {
                cadena = cadena + item;
            }
            return cadena;
        }

        public String MuestraLista()
        {
            Nodo dato = inicio;
            String resultado = "";
            while (dato != null)
            {
                resultado = resultado + dato.Dato + ";";
                dato = dato.Enlace;
            }
            return resultado;
        }
    }
}
