
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Exceptions;

namespace Banco
{
    class Conta 
    {
        private string Numero { get; set; }
        private string Agencia { get; set; }
        private double Saldo { get; set; }
        private Cliente ClienteDaConta { get; set; }
        private static int ProximoNumero { get; set; }

        public Conta(string _Agencia, double _Saldo, Cliente _ClienteDaConta)
        {
            Numero = "" + ProximoNumero++;
            Agencia = _Agencia;
            Saldo = _Saldo;
            ClienteDaConta = _ClienteDaConta;
        }

        public double SaldoAtual => Saldo;

        public void Creditar(double valor) 
        {
            if (valor < 0) 
            {
                throw new ValorNegativoException("Valor incorreto para operação.");
            } 
            else 
            { 
                Saldo += valor; 
            }
        }

        public void Debitar(double valor)
        {
            if (valor < 0) 
            {
                throw new ValorNegativoException("Valor incorreto para operação.");
            } 
            else 
            { 
                if (Saldo > 0 && Saldo >= valor && valor > 0) 
                { 
                    Saldo -= valor; 
                } 
                else 
                {
                    throw new SaldoInsuficienteException("Saldo insuficiente.");
                } 
            }
        }

        public void Transferir(double valor, Conta destino)
        {
            Debitar(valor);
            destino.Creditar(valor);
        }

        public string pegarNumero
        {
            get{
                return Numero;
            }
        }

        public static int NextNumber
        {
            get
            {
                return ProximoNumero;
            }
        }

        public Cliente ClienteDoBanco
        {
            get
            {
                return ClienteDaConta;
            }
        }

        public string AgenciaDoCliente
        {
            get
            {
                return Agencia;
            }
        }
    }
}
