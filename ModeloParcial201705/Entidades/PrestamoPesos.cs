using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PrestamoPesos : Prestamo
    {

        #region Atributos
        private float porcentajeInteres;
        #endregion

        #region Propiedades
        public float Interes
        {
            get
            {
                return CalcularInteres();
            }
        }
        #endregion

        #region Metodos

        private float CalcularInteres()
        {
            return ((this.monto * this.porcentajeInteres) / 100);
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            int diferenciaVencimiento = (int)(nuevoVencimiento - Vencimiento).TotalDays;
            float recargo = 0.25F * diferenciaVencimiento;
            
            this.porcentajeInteres += recargo;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.Mostrar());
            sb.AppendLine("Porcentaje interes: " + this.porcentajeInteres.ToString() + "%");
            sb.AppendLine("Interes: $" + Interes);

            return sb.ToString();
        }


        public PrestamoPesos(float monto, DateTime vencimiento, float interes)
            : base(monto, vencimiento)
        {
            this.porcentajeInteres = interes;
        }

        public PrestamoPesos(Prestamo p, float interes)
            : this(p.Monto, p.Vencimiento, interes)
        {
        }

        #endregion

    }
}
