using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Interfaces
{
    interface IRepositorioDeConta
    {
        public void AdicionaConta(Conta conta);
        public void RemoveConta(Conta conta);
        public Conta PesquisaConta(string numeroDeConta);
        public List<Conta> getConta();
    }
}
