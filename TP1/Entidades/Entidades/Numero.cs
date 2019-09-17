using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedades

        private string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }

        #endregion

        #region Constructor

        public Numero() : this(0)
        {

        }

        public Numero(double numero) : this(numero.ToString())
        {
            
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        #region Operadores
        public static double operator -(Numero n1,Numero n2)
        {
            double retorno;
            retorno = n1.numero - n2.numero;
            return retorno;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double retorno;
            retorno = n1.numero + n2.numero;
            return retorno;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double retorno;
            retorno = n1.numero * n2.numero;
            return retorno;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double retorno;
           
            retorno = n1.numero / n2.numero;

            return retorno;
        }
        #endregion

        #region Metodos

        private double ValidarNumero(string strNumero)
        {
           
            if(Double.TryParse(strNumero, out double resultado) == false)
            {
                resultado = 0;
            }
            
            return resultado; 
        }

        public string DecimalBinario(double numero)
        {
            return this.DecimalBinario(numero.ToString());
        }

        public string DecimalBinario(string numero)
        {
            string retorno = "Valor Invalido";

            if(int.TryParse(numero, out int numDecimal))
            {
                retorno = "";

                if(numDecimal > 0)
                {
                    while (numDecimal > 0)
                    {
                        retorno = (numDecimal % 2) + retorno;
                        numDecimal = numDecimal / 2;
                    }
                    
                }
                else if(numDecimal == 0)
                {
                    retorno = "0";
                }  
            }
           
            return retorno;
        }

        public string BinarioDecimal(string binario)
        {

            string retorno = " ";

            double nroDecimal = 0;

            for (int i = binario.Length - 1, l = 0; i >= 0 ; i-- , l++)
            {

                if (binario[i] == '.' || binario[i] == ',')
                {
                      nroDecimal = 0;
                      l = 0;
                      i--; 
                }
                if (!(binario[i] == '0' || binario[i] == '1'))
                {
                    retorno = "Valor Inválido";
                    break;
                }
                else
                {
                    nroDecimal += (double)(double.Parse(binario[i].ToString()) * Math.Pow(2, l));
                }
                 
                retorno = nroDecimal.ToString(); 
            }


            return retorno;
        }

        


        #endregion

    }
}
