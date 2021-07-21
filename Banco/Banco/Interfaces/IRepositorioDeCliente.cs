using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Interfaces
{
    interface IRepositorioDeCliente
    {
        public void AdicionaCliente(Cliente cliente);
        public void RemoveCliente(Cliente cliente);
        public Cliente PesquisaCliente(string CPF);
    }
}
