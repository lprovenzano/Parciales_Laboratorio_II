using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public abstract class Medico : Persona
    {
		public delegate void FinAtencionPaciente();
		public event FinAtencionPaciente AtencionFinalizada;

		private Paciente pacienteActual;
		protected static Random tiempoAleatorio;

		public virtual Paciente EstaAtendiendoA
		{
			get
			{
				return this.pacienteActual;
			}
		}

		public virtual Paciente AtenderA
		{
			set
			{
				this.pacienteActual = value;
			}
		}

		public Medico(string nombre, string apellido) : base(nombre, apellido)
		{
		}

		static Medico()
		{
			tiempoAleatorio = new Random();
		}

		protected abstract void Atender();

		public void FinalizarAtencion()
		{
			AtencionFinalizada.Invoke();
			this.pacienteActual = null;
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", this.nombre, this.apellido);
		}
	}
}
