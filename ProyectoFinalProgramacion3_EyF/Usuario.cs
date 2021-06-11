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
        //public Usuario(string nick)
        //{
        //    this.nickname = nick;
        //}

        //Contructor General
        public Usuario(string contraseña, string nick, string nombre, string pick, string vFecha )
        {
            this.pass = contraseña;
            this.nickname = nick;
            this.nombreCompleto = nombre;
            this.foto = pick;
            this.fecha = vFecha;

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

        public bool usuarioBuscar(object q)
        {
            Usuario us2 = (Usuario)q;
            if (nickname.CompareTo(us2.nickname) == 0)
                return true;
            else
                return false;
        }

        //cambio
        public bool igualQue(object q)
        {
            Usuario objEstu = (Usuario)q;
            return int.Parse(pass) == int.Parse(objEstu.pass);
        }

        public bool mayorIgualQue(object q)
        {
            Usuario objEstu = (Usuario)q;
            return int.Parse(pass) >= int.Parse(objEstu.pass);
        }

        public bool mayorQue(object q)
        {
            Usuario objEstu = (Usuario)q;
            return int.Parse(pass) > int.Parse(objEstu.pass);
        }

        public bool menorIgualQue(object q)
        {
            Usuario objEstu = (Usuario)q;
            return int.Parse(pass) <= int.Parse(objEstu.pass);
        }

        public bool menorQue(object q)
        {
            Usuario objEstu = (Usuario)q;
            return int.Parse(pass) < int.Parse(objEstu.pass);
        }

        public override string ToString()
        {
            return "" + pass + "" + "&" + nickname + "&" + nombreCompleto + "&" + foto + "&" + fecha;
        }


        public object MostrarInformacion()
        {
            return nickname + pass;
        }
    }
}
