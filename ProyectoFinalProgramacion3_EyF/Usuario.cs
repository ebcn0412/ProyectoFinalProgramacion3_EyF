using ProyectoFinalProgramacion3_EyF.DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgramacion3_EyF
{
    public class Usuario : comparador
    {

        //Se crear los atributos necesarios para el ingreso de informacion  
        public string nombreCompleto { get; set; }
        public string nickname { get; set; }
        public string pass { get; set; }
        public string fecha { get; set; }
        public string foto { get; set; }

        public listaEnlazada lista;

        //Constructor vacio
        public Usuario()
        {
            lista = new listaEnlazada();
        }


        //Contructor General
        public Usuario(string nombre, string nick, string contraseña, string vFecha, string pick)
        {
            this.nombreCompleto = nombre;
            this.nickname = nick;
            this.pass = contraseña;
            this.fecha = vFecha;
            this.foto = pick;
        }

        public Usuario(string contraseñaUsu, string usu)
        {

            this.nickname = usu;
            this.pass = contraseñaUsu;

        }


        //Compara que la contraseña introducida se igual a la introducida
        public bool contraseñaIgual(object q)
        {
            Usuario us2 = (Usuario)q;
            if (pass.CompareTo(us2.pass) == 0)
                return true;
            else
                return false;
        }

        public bool usuarioIgual(object q)
        {
            Usuario us2 = (Usuario)q;
            if (nickname.CompareTo(us2.nickname) == 0)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return "" + nickname + "" + "&" + nombreCompleto + "&" + pass + "&" + fecha + "&" + foto;
        }


        public object MostrarInformacion()
        {
            return nickname + pass;
        }
    }
}
