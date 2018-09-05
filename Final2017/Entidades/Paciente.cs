using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
	public class Paciente : Persona
	{
		private int turno;
		private static int ultimoTurnoDado=0;

		public int Turno
		{
			get
			{
				return this.turno;
			}
		}

		public Paciente(string nombre, string apellido) : base(nombre, apellido)
		{
			ultimoTurnoDado +=1;
			this.turno = ultimoTurnoDado;
		}

		private Paciente(string nombre, string apellido, int turno) : this(nombre, apellido)
		{
			this.turno = turno;
		}

		public override string ToString()
		{
			return string.Format("Turno Nº{0}: {2}, {1}", Turno, this.apellido, this.nombre);
		}
	}

}

