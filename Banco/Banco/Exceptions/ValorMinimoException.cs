using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Exceptions
{
    class ValorMinimoException : Exception
    {
        public ValorMinimoException(string mensagem) : base(mensagem) { }
    }
}
