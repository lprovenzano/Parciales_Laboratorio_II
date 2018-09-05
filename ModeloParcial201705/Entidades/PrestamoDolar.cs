using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PrestamoDolar : Prestamo
    {
        #region Atributos
        private PeriodicidadDePagos periodicidad;
        #endregion

        #region Propiedades
        public float Interes
        {
            get
            {
                return CalcularInteres();
            }
        }
        public PeriodicidadDePagos Periodicidad
        {
            get
            {
                return this.periodicidad;
            }
        }
        #endregion

        #region Metodos

        private float CalcularInteres()
        {
            if (this.periodicidad == PeriodicidadDePagos.Mensual)
                return this.monto * 0.25F;
            else if (this.periodicidad == PeriodicidadDePagos.Bimestral)
                return this.monto * 0.35F;
            else
                return this.monto * 0.4F;
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            int diferenciaVencimiento =(int)(nuevoVencimiento - Vencimiento).TotalDays;
            
            float recargo = 2.5F * diferenciaVencimiento;

            this.monto += recargo;
            this.vencimiento = nuevoVencimiento;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.Mostrar());
            sb.AppendLine("Periodicidad: " + Periodicidad.ToString());
            sb.AppendLine("Interes: " + Interes + "U$D");

            return sb.ToString();
        }

        public PrestamoDolar(float monto, DateTime vencimiento, PeriodicidadDePagos periodicidad)
            : base(monto, vencimiento)
        {
            this.periodicidad = periodicidad;
        }

        public PrestamoDolar(Prestamo p, PeriodicidadDePagos periodicidad)
            : this(p.Monto, p.Vencimiento, periodicidad)
        {
        }



        #endregion

    }
}
