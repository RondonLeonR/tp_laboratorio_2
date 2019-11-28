using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformarEstado;

        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.Estado = EEstado.Ingresado;
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        public void MockCicloDeVida()
        {
            Thread.Sleep(4000);//pausa el subproceso 4 seg.
            this.Estado = EEstado.EnViaje;
            this.InformarEstado(this, EventArgs.Empty);

            Thread.Sleep(4000);//pausa el subproceso 4 seg.
            this.Estado = EEstado.Entregado;
            this.InformarEstado(this, EventArgs.Empty);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if(p1.TrackingID == p2.TrackingID)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public delegate void DelegadoEstado(Paquete p, EventArgs e);
    }
}
