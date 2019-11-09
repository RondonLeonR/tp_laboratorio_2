using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion

        #region Constructores

        public Profesor()
        {

        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Operadores

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            
                foreach (Universidad.EClases a in i.clasesDelDia)
                {
                    if (a == clase)
                    {
                        retorno = true;
                        break;
                    }
                }
            
            return retorno;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

        #region Metodos

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        protected override string ParticiparEnClase()
        {
            string retorno = "\nCLASES DEL DIA:\n";
            foreach(Universidad.EClases it in this.clasesDelDia)
            {
                retorno += it.ToString() + "\n";
            }
            return retorno;
        }

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
        }

        #endregion
    }
}
