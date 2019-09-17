using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            operador = ValidarOperador(operador);
            if(!object.Equals(num1,null) && !object.Equals(num2,null))
            {
                switch(operador)
                {
                    case "+":
                        {
                            retorno = num1 + num2;
                            break;
                        }
                    case "-":
                        {
                            retorno = num1 - num2;
                            break;
                        }
                    case "*":
                        {
                            retorno = num1 * num2;
                            break;
                        }
                    case "/":
                        {
                            if(num2.ToString() == "0")
                            {
                                retorno = double.MinValue;
                            }
                            else
                            {
                                retorno = num1 / num2;
                            }
                                                        
                            break;
                        }
                }
            }
            return retorno;
        }


        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if(operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                retorno = operador;
            }
            return retorno;
        }

    }
}
