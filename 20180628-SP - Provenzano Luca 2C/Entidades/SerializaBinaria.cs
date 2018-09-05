using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SerializaBinaria : IArchivos<Votacion>
    {

        public Votacion Leer(string nombre)
        {
            try
            {
                FileStream fs = new FileStream(nombre, FileMode.Open);
                BinaryFormatter ser = new BinaryFormatter();
                Votacion obj = (Votacion)ser.Deserialize(fs);
                fs.Close();
                return obj;
            }
            catch (Exception e)
            {
                throw new ErrorArchivoException("Error en el archivo (Exception propia)", e);
            }
        }

        public bool Guardar(string nombre, Votacion objeto)
        {
            try
            {
                FileStream fs = new FileStream(nombre, FileMode.Create);
                BinaryFormatter ser = new BinaryFormatter();
                ser.Serialize(fs, objeto);
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ErrorArchivoException("Error en el archivo (Exception propia)", e);
            }
        }
    }
}
