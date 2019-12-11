using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos

        private int legajo;

        #endregion

        #region Constructores

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Universitario)
            {
                retorno = ((Universitario)obj) == this;
            }
            return retorno;
        }

        protected virtual string MostrarDatos()
        {
            return (base.ToString() + "\nLEGAJO NUMERO: " + this.legajo.ToString());
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Operadores

        public static bool operator ==(Universitario pg1 , Universitario pg2)
        {
            bool retorno = false;

                if(pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
                {
                    retorno = true;
                }
                
            return retorno;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
