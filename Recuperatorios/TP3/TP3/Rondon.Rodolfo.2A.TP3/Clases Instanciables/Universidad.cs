using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Excepciones;
using Archivos;


namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region Propiedades 

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;   
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {

                this.jornada[i] = value;
                
            }
        }

        #endregion

        #region Constructores

        public Universidad()
        {
            this.Instructores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
        }

        #endregion

        #region Operadores

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            
                foreach(Alumno item in g.Alumnos)
                {
                    if(item == a)
                    {
                        retorno = true;
                        break;
                    }
                }
            
            return retorno;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            
            if(g.Instructores.Contains(i))
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i); 
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesorRet = null;
            
            foreach(Profesor item in u.Instructores)
            {
                if(item == clase)
                {
                    profesorRet = item;
                    break;
                }
            }
            

            if(object.Equals(profesorRet,null))
            {
                throw new SinProfesorException();
            }
            return profesorRet;
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesorRet = null;
            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                     profesorRet = item;
                     break;
                }
            }
            
            if (profesorRet == null)
            {
                throw new SinProfesorException();
            }
            return profesorRet;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor;
            profesor = (g == clase);
            Jornada jornada = new Jornada(clase, profesor);
            foreach(Alumno item in g.Alumnos)
            {
                jornada += item;
            }
            g.Jornadas.Add(jornada);
            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            
            if(u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if(g != i)
            {
                g.Instructores.Add(i);
            }
            return g;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        private static String MostrarDatos(Universidad uni)
        {
            string retorno = "JORNADA:\n";
            foreach(Jornada item in uni.Jornadas)
            {
                 retorno += item.ToString();
            }
            
            return retorno;
        }

        public static bool Guardar(Universidad uni)
        {  
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Universidad.Xml", uni);
        }
       
        public static Universidad Leer(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Universidad.Xml", out uni);
            
            return uni;
        }

        #endregion

        #region Enumerador

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #endregion
    }
}
