using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class ContaPoupanca : Conta
    {
        public ContaPoupanca(string _Agencia, double _Saldo, Cliente _ClienteDaConta):base(_Agencia, _Saldo, _ClienteDaConta)
        {
        }

        public void RenderJuros(double taxa)
        {
            double saldo = SaldoAtual;
            this.Creditar(saldo * taxa);
        }
    }
}
