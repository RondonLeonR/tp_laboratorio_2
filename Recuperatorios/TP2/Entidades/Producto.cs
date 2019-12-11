using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        #region "Atributos"

        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        #endregion

        #region "Propiedades"

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias
        {
            get;
        }

        #endregion

        #region "Constructor"
        /// <summary>
        /// Inicializa el codigo, marca y color de empaque de un producto.
        /// </summary>
        /// <param name="codigo">El codigo de barras que tendra el producto.</param>
        /// <param name="marca">La marca que tendra el producto.</param>
        /// <param name="color">El color de empaque que tendra el producto.</param>
        public Producto(string codigo, EMarca marca, ConsoleColor color )
        {
            this.codigoDeBarras = codigo;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>Devuelve una cadena de caracteres.</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        #endregion 

        #region "SobreCargas"
        /// <summary>
        /// Muestra los datos de un producto mediante un casteo explicito.
        /// </summary>
        /// <param name="p">El producto a ser mostrado.</param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">Uno de los productos a ser comparado por el codigo de barras.</param>
        /// <param name="v2">Uno de los productos a ser comparado por el codigo de barras.</param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">Uno de los productos a ser comparado por el codigo de barras.</param>
        /// <param name="v2">Uno de los productos a ser comparado por el codigo de barras.</param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }

        #endregion

        #region "Enumerado"
        /// <summary>
        /// Enumerado que posee las distintas marcas que puede tener el producto.
        /// </summary>
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        #endregion
    }
}
