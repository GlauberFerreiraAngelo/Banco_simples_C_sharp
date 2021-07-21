using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Exceptions
{
    class ContaJaExistenteException : Exception
    {
        public ContaJaExistenteException(string mensagem) : base(mensagem) {}
    }
}
