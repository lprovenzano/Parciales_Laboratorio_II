using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final2017
{
	public partial class Form1 : Form
	{
		private MEspecialista medicoEspecialista;
		private MGeneral medicoGeneral;
		Thread mocker;
		private Queue<Paciente> pacientesEnEspera;

		public Form1()
		{
			InitializeComponent();
			this.medicoGeneral = new MGeneral("Luis", "Salinas");
			this.medicoEspecialista = new MEspecialista("Jorge", "Iglesias",
			MEspecialista.Especialidad.Traumatologo);			pacientesEnEspera = new Queue<Paciente>();		}

		private void Form1_Load(object sender, EventArgs e)
		{
			mocker = new Thread(MockPacientes);			mocker.Start();
		}
		private void Form1_Closing(object sender, EventArgs e)
		{
			if (mocker.IsAlive)
				mocker.Abort();
		}

		private void MockPacientes()
		{
			pacientesEnEspera.Enqueue(new Paciente("Luca", "Provenzano"));
			pacientesEnEspera.Enqueue(new Paciente("Loana", "Pranteda"));
			Thread.Sleep(5000);

		}

		private void AtenderPacientes(IMedico medico)
		{
			try
			{
				((Medico)medico).AtenderA = pacientesEnEspera.Dequeue();
				medico.IniciarAtencion(((Medico)medico).EstaAtendiendoA);
				FinAtencion(((Medico) medico).EstaAtendiendoA, ((Medico)medico));
				
			}
			catch (System.InvalidOperationException)
			{
				MessageBox.Show("No hay más pacientes por atender");
			}
		}

		private static void FinAtencion(Paciente p, Medico m)
		{
			MessageBox.Show(string.Format("Finalizó la atención de {0} por {1}!", p.ToString(), m.ToString()));

		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.AtenderPacientes(medicoGeneral);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.AtenderPacientes(medicoEspecialista);
		}
	}
}
