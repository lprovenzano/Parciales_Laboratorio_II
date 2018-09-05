using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Entidades
{
    public class MEspecialista : Medico, IMedico
	{
		private Especialidad especialidad;

		public MEspecialista(string nombre, string apellido, Especialidad e) : base(nombre, apellido)
		{
			this.especialidad = e;
		}

		public void IniciarAtencion(Paciente p)
		{
			AtencionFinalizada += Atender;
			Thread t = new Thread(Atender);
			t.Start();
		}

		protected override void Atender()
		{
			Thread.Sleep((tiempoAleatorio.Next(5000, 10000)));
			FinalizarAtencion();
		}

		public enum Especialidad
		{
			Traumatologo,
			Odontologo
		}

		
    }
}
