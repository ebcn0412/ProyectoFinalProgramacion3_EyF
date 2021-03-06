using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgramacion3_EyF.DATOS
{
     public class listaDoble
    {
        public nodoLD inicio, fin, Temp;

        public listaDoble()
        {
            inicio = fin = null;
        }

        /*Metodo para ver si la lista esta vacia*/

        public Boolean Listavacia()
        {
            return inicio == null;
        }

        /*Metodo para agregar nodos al final*/

        public void insertarAlFinal(object n)
        {
            if (!Listavacia())
            {
                fin = new nodoLD(n, null, fin);
                fin.anterioNodo.siguienteNodo = fin;
            }
            /*Esta vacia*/

            else
            {
                inicio = fin = new nodoLD(n);
            }

        }


        public nodoLD buscarUsuario(object codigoUsuario)
        {
            comparador dato;
            dato = (comparador)codigoUsuario;
            return buscarUsuario(dato, inicio);
        }
        protected nodoLD buscarUsuario(comparador codigoUsuario, nodoLD usuario)
        {
            if (usuario == null)
            {
                return null;
            }
            else
            {
                if (codigoUsuario.usuarioIgual(usuario.valorNodo()) && codigoUsuario.contraseñaIgual(usuario.valorNodo()))
                    return usuario;
                else
                    return buscarUsuario(codigoUsuario, usuario.siguienteNodo);
            }

        }
        public nodoLD buscarNick(object codigoUsuario)
        {
            comparador dato;
            dato = (comparador)codigoUsuario;
            return buscarNick(dato, inicio);
        }
        protected nodoLD buscarNick(comparador codigoUsuario, nodoLD usuario)
        {
            if (usuario == null)
            {
                return null;
            }
            else
            {
                if (codigoUsuario.usuarioIgual(usuario.valorNodo()) && codigoUsuario.usuarioBuscar(usuario.valorNodo()))
                    return usuario;
                else
                    return buscarUsuario(codigoUsuario, usuario.siguienteNodo);
            }

        }



        public nodoLD mostrar()
        {
            return (nodoLD)inicio.valorNodo();

        }

    }
}
