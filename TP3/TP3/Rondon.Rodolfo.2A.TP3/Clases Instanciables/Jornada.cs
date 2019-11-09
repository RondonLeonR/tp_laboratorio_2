﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

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

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region Constructores

        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion

        #region Operadores

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in j.Alumnos)
            {
                if(item == a)
                {
                    retorno = true;
                    break;
                }
             }
            
            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(a == j.Clase)
            {
                if (j != a)
                {
                    j.Alumnos.Add(a);

                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }      
            return j;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            int flag = 1;
            string retorno = "CLASE DE " + this.Clase.ToString() + " POR " + this.Instructor.ToString() + " \n\nALUMNOS: \n";
            
                foreach(Alumno al in this.Alumnos)
                {
                    
                        retorno += al.ToString() + "\n";
                flag = 0;
                }
            if(flag == 1)
            {
                retorno += "No hay alumnos para esta clase.\n";
            }

            retorno += "<------------------------------------------------>\n ";
            return retorno;
        }


        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto t = new Texto();
            retorno = t.Guardar(@"C:\Users\user\Desktop\TPs 2A\tp_laboratorio_2\Rondon, Rodolfo 2A-TP 3 (Recuperatorio)\Formato de Archivos\Jornadas.txt", jornada.ToString());
            return retorno;
        }


        public static string Leer()
        {
            Texto text = new Texto();
            text.Leer(@"C:\Users\user\Desktop\TPs 2A\tp_laboratorio_2\Rondon, Rodolfo 2A-TP 3 (Recuperatorio)\Formato de Archivos\Jornadas.txt", out string datos);
            return datos;
        }

        #endregion

    }
}
