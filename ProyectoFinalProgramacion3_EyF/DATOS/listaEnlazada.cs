using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgramacion3_EyF.DATOS
{
    public class listaEnlazada
    {
        public nodoLista cabeza;
        public nodoLista primero;
        public int numeroElementos = 0;

        public listaEnlazada()
        {
            cabeza = null;
            numeroElementos = 0;
        }

        public listaEnlazada insertarDatoCabeza(object entrada)
        {
            nodoLista nuevo;
            nuevo = new nodoLista(entrada);
            nuevo.enlace = primero;
            primero = nuevo;
            numeroElementos++;
            return this;
        }
    }
}
