using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Exceptions
{
    class TipoContaInvalidaException : Exception
    {
        public TipoContaInvalidaException(string mensagem) : base(mensagem) { }
    }
}
