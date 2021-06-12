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
        public archivos() { 

        }

        public void CargarDatos(ref Usuario[] usuarioArchivo)
        {
            StreamReader reader = new StreamReader("usuarios.txt");
            int size = Convert.ToInt32(reader.ReadLine());
            usuarioArchivo = new Usuario[size];
            for (int i = 0; i < usuarioArchivo.Length; i++)
            {
                usuarioArchivo[i] = new Usuario();
                usuarioArchivo[i].pass = reader.ReadLine();
                usuarioArchivo[i].nickname = reader.ReadLine();
                usuarioArchivo[i].nombreCompleto = reader.ReadLine();
                usuarioArchivo[i].foto = reader.ReadLine();
                usuarioArchivo[i].fecha = reader.ReadLine();
            }
            reader.Close();
        }
        public void AgregarUsuario(ref Usuario[] usuarioArchivo, string nombre, string nick, string contraseña,
            string feecha, string pick)
        {
            StreamWriter escribir = new StreamWriter("usuarios.txt");
            escribir.WriteLine(usuarioArchivo.Length + 1);
            Usuario nuevo = new Usuario();

            for (int i = 0; i < usuarioArchivo.Length; i++)
            {
                escribir.WriteLine(usuarioArchivo[i].pass);
                escribir.WriteLine(usuarioArchivo[i].nickname);
                escribir.WriteLine(usuarioArchivo[i].nombreCompleto);
                escribir.WriteLine(usuarioArchivo[i].foto);
                escribir.WriteLine(usuarioArchivo[i].fecha);

            }
            nuevo.nombreCompleto = nombre;
            nuevo.nickname = nick;
            nuevo.pass = contraseña;
            nuevo.fecha = feecha;nuevo.foto = pick;
            escribir.WriteLine(nuevo.pass);
            escribir.WriteLine(nuevo.nickname);
            escribir.WriteLine(nuevo.nombreCompleto);
            escribir.WriteLine(nuevo.foto);
            escribir.WriteLine(nuevo.fecha); 
            escribir.Close();
        }
    }
}

