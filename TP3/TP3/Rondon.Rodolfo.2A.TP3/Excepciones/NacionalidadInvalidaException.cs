using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException() : this("Se ingreso un DNI incorrecto")
        {

        }

        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
    }
}
