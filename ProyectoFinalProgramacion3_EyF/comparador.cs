using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalProgramacion3_EyF
{
    public interface comparador
    {
        bool usuarioIgual(object q);
        bool contraseñaIgual(object q);
        bool usuarioBuscar(object q);

    }
}
