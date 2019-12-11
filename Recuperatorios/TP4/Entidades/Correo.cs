using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        public Correo()
        {
            this.Paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        public void FinEntregas()
        {
            foreach(Thread item in this.mockPaquetes)
            {
                item.Abort();
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> aux = ((Correo)elementos).paquetes;
            string retorno = "";
            foreach(Paquete item in aux)
            {
                retorno += item.ToString() + " (" + item.Estado.ToString() + ")\n";
            }
            return retorno;
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            int bandera = 1;
            foreach(Paquete item in c.Paquetes)
            {
                if(item == p)
                {
                    bandera = -1;
                    throw new TrackingIdRepetidoException("Paquete repetido");
                }
            }

            if(bandera == 1)
            {
                c.Paquetes.Add(p);
                Thread h = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(h);
                h.Start();
            }
            return c;
        }
    }
}
