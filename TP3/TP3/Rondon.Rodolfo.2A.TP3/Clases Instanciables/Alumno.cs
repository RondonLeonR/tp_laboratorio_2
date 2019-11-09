using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion

        #region Constructores

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma,EEstadoCuenta.AlDia)
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.estadoCuenta = estadoCuenta;
            this.claseQueToma = claseQueToma;
        }

        #endregion

        #region Operadores 

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        protected override string MostrarDatos()
        {
            string est = this.estadoCuenta.ToString();
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                 est = "Cuota al Dia";
            }
            return base.MostrarDatos() + "\n\nESTADO DE CUENTA: " + est + this.ParticiparEnClase();
        }

        protected override string ParticiparEnClase()
        {
            return "\nTOMA CLASE DE " + this.claseQueToma;
        }

        #endregion

        #region Enumerados 

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion
    }
}
