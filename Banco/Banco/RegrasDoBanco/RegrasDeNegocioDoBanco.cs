using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Interfaces;
using Banco.Exceptions;

namespace Banco.RegrasDoBanco
{
    class RegrasDeNegocioDoBanco : IRegrasBanco
    {
        private IRepositorioDeCliente RepositorioCliente;
        private IRepositorioDeConta RepositorioConta;

        public RegrasDeNegocioDoBanco(IRepositorioDeCliente _RepositorioCliente, IRepositorioDeConta _repositorioConta)
        {
            RepositorioCliente = _RepositorioCliente;
            RepositorioConta = _repositorioConta;
        }

        public void AdicionarCliente(Cliente cliente)
        {
            try
            {
                PesquisarCliente(cliente.PegarCPF);
                throw new ClienteJaExistenteException("Cliente ja existe.");
            }
            catch(ClienteInexistenteException ex)
            {
                RepositorioCliente.AdicionaCliente(cliente);
            }
        }

        public void AdicionarConta(Conta conta)
        {
            try
            {
                PesquisaConta(conta.pegarNumero);
                throw new ContaJaExistenteException("Conta ja existe.");
            }
            catch(ContaInexistenteException ex)
            {
                RepositorioConta.AdicionaConta(conta);
            }
        }

        public void Creditar(string numeroConta, double valor)
        {
            Conta _conta = PesquisaConta(numeroConta);
            _conta.Creditar(valor);
        }

        public void Debitar(string numeroConta, double valor)
        {
            Conta _conta = PesquisaConta(numeroConta);
            _conta.Debitar(valor);
        }

        public List<Conta> ListaContas()
        {
            return RepositorioConta.getConta();
        }

        public Conta PesquisaConta(string numeroDeConta)
        {
            Conta _conta = RepositorioConta.PesquisaConta(numeroDeConta);
            if (_conta == null)
            {
                throw new ContaInexistenteException("Conta não existente.");
            }
            else
            {
                return _conta;
            }
        }

        public Cliente PesquisarCliente(string CPF)
        {
            Cliente _cliente = RepositorioCliente.PesquisaCliente(CPF);
            if(_cliente == null)
            {
                throw new ClienteInexistenteException("Cliente não existe.");
            }
            else
            {
                return _cliente;
            }
        }

        public void RemoverCliente(string CPF)
        {
            Cliente _cliente = PesquisarCliente(CPF);
            RepositorioCliente.RemoveCliente(_cliente);
        }

        public void RemoverConta(string numeroDaConta)
        {
            Conta _conta = PesquisaConta(numeroDaConta);
            RepositorioConta.RemoveConta(_conta);
        }

        public void renderBonus(string numero)
        {
            Conta _conta = PesquisaConta(numero);

            if (_conta is ContaBonificada)
            {
                ContaBonificada _contaBonificada = (ContaBonificada)_conta;
                _contaBonificada.RenderBonus();
            }
            else
            {
                throw new TipoContaInvalidaException("Essa conta não eh conta bonificada.");
            }
        }

        public void RenderJuros(string numero, double taxa)
        {
            Conta _conta = PesquisaConta(numero);

            if (_conta is ContaPoupanca)
            {
                ContaPoupanca _contaPoupanca = (ContaPoupanca)_conta;
                _contaPoupanca.RenderJuros(taxa);
            }
            else
            {
                throw new TipoContaInvalidaException("Essa conta não eh conta poupança.");
            }
            
        }

        public void SetRepositorioCliente(RepositorioDeClienteList respositorioCLiente)
        {
            this.RepositorioCliente = respositorioCLiente;
        }

        public void SetRespositorioConta(RepositorioDeContaList repositorioConta)
        {
            this.RepositorioConta = repositorioConta;
        }

        public void Transferir(string numeroDaContaDeOrigem, string numeroDaContaDeDestino, double valor)
        {
            Conta contaOrigem = PesquisaConta(numeroDaContaDeOrigem);
            Conta contaDestino = PesquisaConta(numeroDaContaDeDestino);
            contaOrigem.Transferir(valor, contaDestino);
        }
    }
}
