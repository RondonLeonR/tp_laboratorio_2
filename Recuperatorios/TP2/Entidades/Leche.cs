using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        
        #region "Atributos"

        private ETipo tipo;

        #endregion

        #region "Propiedades"

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Por defecto, TIPO será ENTERA. Se inicializa un producto Leche.
        /// </summary>
        /// <param name="marca">Marca del producto.</param>
        /// <param name="patente">Codigo de barras del producto.</param>
        /// <param name="color">Color de empaque del producto.</param>
        public Leche(EMarca marca, string patente, ConsoleColor color) : this(marca, patente, color,ETipo.Entera)
        {
            
        }

        /// <summary>
        /// Se inicializa un producto Leche definiendo el tipo y se inicializa el constructor de la clase padre.
        /// </summary>
        /// <param name="marca">Marca del producto.</param>
        /// <param name="patente">Codigo de barras del producto.</param>
        /// <param name="color">Color de empaque del producto.</param>
        /// <param name="tipo">Tipo de leche.</param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo) : base(patente,marca,color)
        {
            this.tipo = tipo;
        }


        #endregion

        #region "Metodo"
        /// <summary>
        /// Se modifica el metodo "Mostrar" de la clase padre.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region "Enumerado"
        /// <summary>
        /// Enumerado con los tipos de Leche.
        /// </summary>
        public enum ETipo { Entera, Descremada }

        #endregion
    }
}
