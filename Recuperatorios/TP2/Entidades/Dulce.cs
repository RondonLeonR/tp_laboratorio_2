using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region "Propiedades"
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        #endregion

        #region "Constructor"
        /// <summary>
        /// Inicializa un producto dulce y se inicializa la clase padre.
        /// </summary>
        /// <param name="marca">Marca que poseera el producto.</param>
        /// <param name="patente">Codigo de barras.</param>
        /// <param name="color">Color de empaque.</param>
        public Dulce(EMarca marca, string patente, ConsoleColor color) : base(patente,marca,color)
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

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
