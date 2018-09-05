using System;

namespace Entidades
{
    public abstract class Persona
    {
		protected string apellido;
		protected string nombre;

		public Persona(string nombre, string apellido)
		{
			this.apellido = apellido;
			this.nombre = nombre;
		}
    }
}
