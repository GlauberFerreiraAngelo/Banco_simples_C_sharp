using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Exceptions
{
    class ContaInexistenteException : Exception
    {
        public ContaInexistenteException(string mensagem) : base(mensagem) { }
    }
}
