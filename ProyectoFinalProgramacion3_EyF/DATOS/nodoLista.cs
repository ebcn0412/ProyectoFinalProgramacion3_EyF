using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgramacion3_EyF.DATOS
{
    public class nodoLista
    {
        public object dato;
        public nodoLista enlace;

        public nodoLista(object x)
        {
            dato = x;
            enlace = null;
        }

        public nodoLista(object x, nodoLista n)
        {
            dato = x;
            enlace = n;
        }
    }
}
