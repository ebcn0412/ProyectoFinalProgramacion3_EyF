using ProyectoFinalProgramacion3_EyF.DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgramacion3_EyF
{
    class usuData {

        listaDoble miLista;

        public usuData()
        {
            miLista = new listaDoble();
        }

        public usuData(listaDoble miLista)
        {
            this.miLista = miLista;
        }
        public void insertarDatoUsuario(Usuario miUsuario)
        {
            miLista.insertarAlFinal(miUsuario);
        }
        public object buscarDatosCompletos(Usuario miUsuario)
        {
            if (miLista.buscarUsuario(miUsuario) != null)
                return miLista.buscarUsuario(miUsuario);
            else
                return null;
        }

        public object buscarUsu(Usuario miUsuario)
        {
            if (miLista.buscarNick(miUsuario.nickname) != null)
                return miLista.buscarNick(miUsuario.nickname);
            else
                return null;
        }
    }
}

