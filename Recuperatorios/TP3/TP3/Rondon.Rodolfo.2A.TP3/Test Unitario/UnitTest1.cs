using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;
using Excepciones;

namespace Test_Unitario
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Alumno con datos validos
        /// </summary>
        [TestMethod]
        public void DniValido()
        {
            
            Alumno a = new Alumno(2, "Pedrin", "lll", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            int.Equals(12345678, a.DNI); 
            
        }

        /// <summary>
        /// Alumno con datos invalidos.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniError()
        {
            try
            {
                Alumno a = new Alumno(1, "Pedrin", "lll", "0", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail("El DNI es invalido");
            }
            catch (Exception e)
            {

                throw new DniInvalidoException();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void ValidaNoRepeticion()
        {
            Universidad u = new Universidad();
            Alumno a1 = new Alumno(1, "Pedrin", "Lopez", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(1, "Pedrin", "Lopez", "11112222", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            try
            {
                u += a1;
                u += a2;
                Assert.Fail("El mismo legajo, deberia ser invalido");
            }
            catch (Exception e)
            {
                throw new AlumnoRepetidoException();
                throw;
            }
        }

    }
}
