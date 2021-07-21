using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Interfaces;

namespace Banco
{
    class RepositorioDeClienteList : IRepositorioDeCliente
    {

        List<Cliente> ListDeCliente;

        public RepositorioDeClienteList()
        {
            ListDeCliente = new List<Cliente>();
        }
        
        public void AdicionaCliente(Cliente cliente)
        {
            ListDeCliente.Add(cliente);
        }

        public Cliente PesquisaCliente(string CPF)
        {
           foreach(Cliente _cliente in ListDeCliente)
            {
             
                if (_cliente.PegarCPF.Equals(CPF))
                {
                    return _cliente;
                }
            }
            return null;
        }

        public void RemoveCliente(Cliente cliente)
        {
            ListDeCliente.Remove(cliente);
        }
    }
}
