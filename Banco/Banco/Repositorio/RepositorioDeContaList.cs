using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Interfaces;

namespace Banco
{
    class RepositorioDeContaList : IRepositorioDeConta
    {
        List<Conta> contas;

        public RepositorioDeContaList() 
        {
            contas = new List<Conta>();
        }

        public void AdicionaConta(Conta conta)
        {
            contas.Add(conta);
        }

        public List<Conta> getConta()
        {
            return contas;
        }

        public Conta PesquisaConta(string numeroDeConta)
        {
            foreach(Conta _conta in contas)
            {
                if (_conta.pegarNumero.Equals(numeroDeConta))
                {
                    return _conta;
                }
            }
            return null;
        }

        public void RemoveConta(Conta conta)
        {
            contas.Remove(conta);
        }
    }
}
