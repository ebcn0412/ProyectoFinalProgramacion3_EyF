using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgramacion3_EyF.DATOS
{
    public class nodoLD
    {
        //Se crea dos variables de tipo nodo publico
        public nodoLD siguienteNodo;
        public nodoLD anterioNodo;

        //Variable para la insercion de la informacion
        public object datoNodo;

        //Contructores

        public nodoLD(object datoEntrada)
        {
            datoNodo = datoEntrada;
            siguienteNodo = anterioNodo = null;
        }

        public nodoLD(object datoEntrada, nodoLD principioNodo, nodoLD ultimoNodo)
        {
            datoNodo = datoEntrada;
            siguienteNodo = principioNodo;
            anterioNodo = ultimoNodo;
        }



        public object valorNodo()
        {
            return datoNodo;
        }
        public string visitar()
        {
            return datoNodo.ToString();
        }
    }
}
