using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgramacion3_EyF.ARBOLAVL
{
    public class Nodo
    {
        protected Object dato;
        protected Nodo izdo;
        protected Nodo dcho;


        public Nodo(Object valor)
        {
            dato = valor;
            izdo = dcho = null;
        }

        public Nodo(Nodo ramaIzdo, Object valor, Nodo ramaDcho)
        {
            this.dato = valor;
            izdo = ramaIzdo;
            dcho = ramaDcho;
        }


        public Object valorNodo()
        {
            return dato;
        }

        public Nodo subArbolIzdo() { return izdo; }
        public Nodo subArbolDrcho() { return dcho; }


        public void nuevoValor(Object d)
        {
            dato = d;
        }


        public void ramaIzdo(Nodo n) { izdo = n; }
        public void ramaDcho(Nodo n) { dcho = n; }
        public string visitarArbol()
        {
            return dato.ToString();
        }
    }
}
