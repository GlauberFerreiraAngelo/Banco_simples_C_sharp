using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Interfaces
{
    interface IRegrasBanco
    {
        public Cliente PesquisarCliente(string CPF);
        public void AdicionarCliente(Cliente cliente);
        public void RemoverCliente(string CPF);
        public void SetRepositorioCliente(RepositorioDeClienteList respositorioCLiente);
        public Conta PesquisaConta(string numeroDeConta);
        public void AdicionarConta(Conta conta);
        public void RemoverConta(string numeroDaConta);
        public void Creditar(string numeroConta, double valor);
        public void Debitar(string numeroConta, double valor);
        public void Transferir(string numeroDaContaDeOrigem, string numeroDaContaDeDestino, double valor);
        public void SetRespositorioConta(RepositorioDeContaList repositorioConta);
        public void RenderJuros(string numero, double taxa);
        public void renderBonus(string numero);
        public List<Conta> ListaContas();
    }
}
