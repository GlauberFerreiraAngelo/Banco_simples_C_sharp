using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class ContaBonificada : Conta
    {
        private double Bonus { get; set; }

        public ContaBonificada(string agencia, double saldo, Cliente clienteDaConta) : base(agencia, saldo, clienteDaConta)
        {            
        }

        public void Creditar(double valor)
        {
            Bonus += (valor * 0.01);
            base.Creditar(valor);
        }

        public void RenderBonus()
        {
            base.Creditar(Bonus);
            Bonus = 0;
        }

    }
}
