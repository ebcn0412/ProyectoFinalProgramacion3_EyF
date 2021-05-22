using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoFinalProgramacion3_EyF
{
    public class archivos
    {
        public archivos() { }
        public void CargarDatos(ref Usuario[] usuarioArchivo)
        {
            StreamReader reader = new StreamReader("usuarios.txt");
            int size = Convert.ToInt32(reader.ReadLine());
            usuarioArchivo = new Usuario[size];
            for (int index = 0; index < usuarioArchivo.Length; index++)
            {
                usuarioArchivo[index] = new Usuario();
                usuarioArchivo[index].nombreCompleto = reader.ReadLine();
                usuarioArchivo[index].nickname = reader.ReadLine();
                usuarioArchivo[index].pass = reader.ReadLine();
                usuarioArchivo[index].fecha = reader.ReadLine();
                usuarioArchivo[index].foto = reader.ReadLine();
            }
            reader.Close();
        }

        //Metodo para agregar un usuario
        public void AgregarUsuario(ref Usuario[] usuarioArchivo, string nombre, string nick, string contraseña,
            string feecha, string pick)
        {
            StreamWriter escribir = new StreamWriter("usuarios.txt");
            escribir.WriteLine(usuarioArchivo.Length + 1);
            Usuario usuNue = new Usuario();

            for (int index = 0; index < usuarioArchivo.Length; index++)
            {
                escribir.WriteLine(usuarioArchivo[index].nombreCompleto);
                escribir.WriteLine(usuarioArchivo[index].nickname);
                escribir.WriteLine(usuarioArchivo[index].pass);
                escribir.WriteLine(usuarioArchivo[index].fecha);
                escribir.WriteLine(usuarioArchivo[index].foto);
            }

            usuNue.nombreCompleto = nombre;usuNue.nickname = nick;usuNue.pass = contraseña;usuNue.fecha = feecha;usuNue.foto = pick;
            escribir.WriteLine(usuNue.nombreCompleto); escribir.WriteLine(usuNue.nickname); escribir.WriteLine(usuNue.pass);
            escribir.WriteLine(usuNue.fecha); escribir.WriteLine(usuNue.foto);
            escribir.Close();
        }

       



        //Metodo para mostrar la informacion de un txt
        public static void MostrarTodo(Usuario[] usuarioArchivo)
        {
            for (int index = 0; index < usuarioArchivo.Length; index++)
            {
                Console.WriteLine("Id: \t\t{0}", index);
                usuarioArchivo[index].MostrarInformacion();
            }

        }




        //Falta Administrador
    }
}

