using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region "Propiedades"
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        #endregion

        #region "Constructor".

        /// <summary>
        /// Inicializa un producto Snack y se inicializa la clase padre.
        /// </summary>
        /// <param name="marca">Marca del producto.</param>
        /// <param name="patente">Codigo de barras del producto.</param>
        /// <param name="color">Color de empaque del producto.</param>
        public Snacks(EMarca marca, string patente, ConsoleColor color) : base(patente, marca, color)
        {
        }

        #endregion

        #region "Metodos"
        /// <summary>
        /// Se modifica el metodo "Mostrar" de la clase padre.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
