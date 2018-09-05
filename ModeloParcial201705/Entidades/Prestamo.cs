using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Prestamo
    {
        #region Atributos
        protected float monto;
        protected DateTime vencimiento;
        #endregion

        #region Props

        public float Monto
        {
            get { return this.monto; }
        }

        public DateTime Vencimiento
        {
            get { return this.vencimiento; }
            set { this.vencimiento = value; }
        }
        #endregion

        #region Metodos

        public Prestamo(float monto, DateTime vto)
        {
            this.monto = monto;
            this.vencimiento = vto;
        }

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---------------------------------------");
            sb.AppendLine("Monto: " + Monto);
            sb.AppendLine("Vencimiento: " + Vencimiento.ToString("d:MM:yyyy"));
            sb.AppendLine("---------------------------------------");

            return sb.ToString();
        }

        public static int OrdernarPorFecha(Prestamo p1, Prestamo p2)
        {
            return p1.Vencimiento.CompareTo(p2.Vencimiento);
        }

        public abstract void ExtenderPlazo(DateTime nuevoVencimiento);

        public enum PeriodicidadDePagos
        {
            Mensual,
            Bimestral,
            Trimestral
        }

        public enum TipoDePrestamo
        {
            Pesos,
            Dolares,
            Todos
        }

        #endregion
    }
}
