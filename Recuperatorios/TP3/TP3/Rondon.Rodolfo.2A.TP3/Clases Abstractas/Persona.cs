using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #endregion

        #region Propiedades

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        public Persona() 
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad): this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre + "\nNACIONALIDAD: " + this.Nacionalidad.ToString() + "\n";
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int ret = 0;
            if(nacionalidad == ENacionalidad.Argentino)
            {
                if(dato >= 1 && dato <= 89999999)
                {
                    ret = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se concide con el numero de DNI");

                }
            }
            else if(nacionalidad == ENacionalidad.Extranjero)
            {
                if(dato >= 90000000 && dato <= 99999999)
                {
                    ret = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se concide con el numero de DNI");

                }
            }
            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if( dato != null && dato.Length > 0 && dato.Length < 9 )
            {
                int.TryParse(dato , out dni);
                dni = this.ValidarDni(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException("Dni invalido");
            }
            return dni;
        }

        private string ValidarNombreApellido(string dato)
        {
            
            if(dato != null && dato != "")
            {
                foreach(char i in dato)
                {
                    if(!char.IsLetter(i))
                    {
                        dato = "";
                        break;
                    }
                }
            }
            return dato;
        }

        #endregion

        #region Enumerador

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion
    }
}
