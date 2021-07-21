using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Exceptions
{
    class ValorNegativoException : Exception
    {
        public ValorNegativoException(string mensagem) : base(mensagem) { }
    }
}
