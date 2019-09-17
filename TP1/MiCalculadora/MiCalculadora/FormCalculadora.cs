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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
            

        }

        private void Limpiar()
        {
            this.txtNum1.Text = "0";
            this.txtNum2.Text = "0";
            this.lblResultado.Text = "0";
            this.cmbOperador.SelectedItem = "+";

        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Text = "Calculadora de Rodolfo Rondon del curso 2ºA";
            this.lblResultado.Text = "0";
            this.cmbOperador.SelectedItem = ("+");
        }

        private static double Operar(string numero1, string numero2,string operador)
        {
            double resultado = 0;
            
            Numero numA = new Numero(numero1);
            Numero numB = new Numero(numero2);

            resultado = Calculadora.Operar(numA, numB, operador);
       
            return resultado;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = FormCalculadora.Operar(this.txtNum1.Text, this.txtNum2.Text, this.cmbOperador.Text);
            this.lblResultado.Text = resultado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblResultado_Click(object sender, EventArgs e)
        {
            
        }

        private void txtNum2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            this.lblResultado.Text = num.BinarioDecimal(this.lblResultado.Text);
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            this.lblResultado.Text = num.DecimalBinario(this.lblResultado.Text);
        }
    }
}
