using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IArchivos<T>
    {
        T Leer(string nombre);
        bool Guardar(string nombre, T objeto);
    }
}
