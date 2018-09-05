using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Entidades
{
    public class MGeneral : Medico, IMedico
    {
		public MGeneral(string nombre, string apellido) : base(nombre, apellido)
		{

		}

		public void IniciarAtencion(Paciente p)
		{
			AtencionFinalizada += Atender;
			Thread t = new Thread(Atender);
			t.Start();
		}

		protected override void Atender()
		{
			Thread.Sleep(tiempoAleatorio.Next(1500, 2200));
			FinalizarAtencion();
		}
	}
}
