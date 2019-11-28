using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ObjInstanciado()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        [TestMethod]
        public void IgualdadObj()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Av Falsa 123", "123-456");
            Paquete p2 = new Paquete("Av Falsa 321", "123-456");

            try
            {
                c += p1;
                c += p2;
                Assert.Fail("No deberia agregarlo, tienen el mismo Tracking");
            }
            catch (System.Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
