using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Main
{
    public partial class Form1 : Form
    {
        Correo correo; 

        public Form1()
        {
            InitializeComponent();
            this.mtxtTrackingID.Mask = "000-000-0000";
            this.Text = "Correo UTN por Rondon Rodolfo 2 A";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.correo = new Correo();
        }



        private void lstIngresado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstEnViaje_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstEntregado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ActualizarEstados()
        {
            this.lstIngresado.Items.Clear();
            this.lstEnViaje.Items.Clear();
            this.lstEntregado.Items.Clear();

            foreach(Paquete item in this.correo.Paquetes)
            {
                if(item.Estado == EEstado.Ingresado)
                {
                    this.lstIngresado.Items.Add(item);
                }
                else if(item.Estado == EEstado.EnViaje)
                {
                    this.lstEnViaje.Items.Add(item);
                }
                else if(item.Estado == EEstado.Entregado)
                {
                    this.lstEntregado.Items.Add(item);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            p.InformarEstado += this.paq_InformaEstado;

            try
            {
                this.correo += p;
            }
            catch (TrackingIdRepetidoException t)
            {

                MessageBox.Show(t.Message);
            }
            this.ActualizarEstados();
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if(this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });    
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    elemento.MostrarDatos(elemento).Guardar("exit.txt");
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message);
                }
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEntregado.SelectedItem);
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
    }
}
