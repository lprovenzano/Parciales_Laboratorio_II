using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Financiera
    {
        #region Atributos
        private List<Prestamo> listaDePrestamos;
        private string razonSocial;
        #endregion

        #region Props

        public float InteresesEnDolares
        {
            get
            {
                return CalcularInteresGanado(Prestamo.TipoDePrestamo.Dolares);
            }
        }

        public float InteresesEnPesos
        {
            get
            {
                return CalcularInteresGanado(Prestamo.TipoDePrestamo.Pesos);
            }
        }

        public float InteresesTotales
        {
            get
            {
                return CalcularInteresGanado(Prestamo.TipoDePrestamo.Todos);
            }
        }

        public List<Prestamo> ListaDePrestamo
        {
            get
            {
                return listaDePrestamos;
            }
        }

        public string RazonSocial
        {
            get
            {
                return this.RazonSocial;
            }
        }

        #endregion

        #region Metodos

        private float CalcularInteresGanado(Prestamo.TipoDePrestamo tipoPrestamo)
        {
            float interesDolar = 0, interesPesos = 0;

            if (tipoPrestamo == Prestamo.TipoDePrestamo.Dolares)
            {
                return interesDolar += ListaDePrestamo.Where(x => x is PrestamoDolar).Sum(x => ((PrestamoDolar)x).Interes);
            }
            else if (tipoPrestamo == Prestamo.TipoDePrestamo.Pesos)
            {
                return interesPesos += ListaDePrestamo.Where(x => x is PrestamoPesos).Sum(x => ((PrestamoPesos)x).Interes);
            }
            else
            {
                interesDolar += ListaDePrestamo.Where(x => x is PrestamoDolar).Sum(x => ((PrestamoDolar)x).Interes);
                interesPesos += ListaDePrestamo.Where(x => x is PrestamoPesos).Sum(x => ((PrestamoPesos)x).Interes);

                return interesDolar + interesPesos;
            }
        }

        //Ctors
        private Financiera()
        {
            listaDePrestamos = new List<Prestamo>();
        }

        public Financiera(string razonSocial)
            : this()
        {
            this.razonSocial = razonSocial;
        }

        #endregion

        #region Sobrecarga

        public void OrdenarPrestamos()
        {
            ListaDePrestamo.Sort(Prestamo.OrdernarPorFecha);
        }


        public static explicit operator string(Financiera f1)
        {
            

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Razon Social: " + f1.razonSocial);
            sb.AppendLine("Interes total: " + f1.InteresesTotales);
            sb.AppendLine("Interes en Pesos ($): " + f1.InteresesEnPesos);
            sb.AppendLine("Interes en Dolares (U$D): " + f1.InteresesEnDolares);

            foreach (Prestamo item in f1.ListaDePrestamo)
            {
                sb.AppendLine(item.Mostrar());
            }

            return sb.ToString();
        }

        public static string Mostrar(Financiera f1)
        {
            //f1.OrdenarPrestamos();
            return (string)f1;
        }


        public static Financiera operator +(Financiera f1, Prestamo p1)
        {
            if (!(f1 == p1))
            {
                f1.ListaDePrestamo.Add(p1);
                return f1;
            }
            else
            {
                return f1;
            }
        }

        public static bool operator ==(Financiera f1, Prestamo p1)
        {
            return (f1.ListaDePrestamo.Contains(p1));
        }

        public static bool operator !=(Financiera f1, Prestamo p1)
        {
            return (!(f1.ListaDePrestamo.Contains(p1)));
        }
        #endregion
    }
}
