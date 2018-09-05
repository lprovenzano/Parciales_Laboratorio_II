using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Dao : IArchivos<Votacion>
    {
        public Votacion Leer(string nombre)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(string nombre, Votacion objeto)
        {
            try
            {
                string formatoQuery = string.Format("insert into Votaciones (nombreLey, afirmativos, negativos, abstenciones, nombreAlumno) values ('{0}', {1}, {2}, {3}, 'Luca Provenzano')", objeto.NombreLey, objeto.Afirmativos, objeto.Negativos, objeto.Abstencion);
                using (SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=" + nombre + ";Integrated Security=True"))
                {
                    SqlCommand command = new SqlCommand(formatoQuery, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
