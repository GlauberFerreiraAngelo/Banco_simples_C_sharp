using System;
using Banco.Interfaces;
using Banco.RegrasDoBanco;
using System.Text.RegularExpressions;
using Banco.Exceptions;

namespace Banco
{
    
    class Program
    {
        static IRegrasBanco  Banco = new RegrasDeNegocioDoBanco(new RepositorioDeClienteList(), new RepositorioDeContaList());
        

        static void Main(string[] args)
        {
            Cliente _cliente;
            Conta _conta;
            string leitura;
            int opcao = 0;

            do
            {
                
                do
                {
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=================================================");
                    Console.WriteLine("=                                               =");
                    Console.WriteLine("=        Digite [1] para abrir conta            =");
                    Console.WriteLine("=        Digite [2] para fecha conta            =");
                    Console.WriteLine("=        Digite [3] para transferir             =");
                    Console.WriteLine("=        Digite [4] para creditar               =");
                    Console.WriteLine("=        Digite [5] para debitar                =");
                    Console.WriteLine("=        Digite [6] para cadastrar cliente      =");
                    Console.WriteLine("=        Digite [7] dados do cliente            =");
                    Console.WriteLine("=        Digite [8] operações com conta         =");
                    Console.WriteLine("=        Digite [9] para sair                   =");
                    Console.WriteLine("=                                               =");
                    Console.WriteLine("=================================================");

                    Console.ForegroundColor = ConsoleColor.Green;

                    leitura = Console.ReadLine();

                    if (Regex.IsMatch(leitura, @"^[0-9]+$"))
                    {
                        opcao = int.Parse(leitura);
                        
                        if ((opcao > 9) || (opcao < 1))
                        {
                            Console.WriteLine("Opção inválida! número digitado não esta na lista.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida! digite um numero.");
                        opcao = 0;
                    }
                 
                }
                while ((opcao > 9) || (opcao < 1));


                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        string ProximoNumeroDaConta, Agencia, CPF;
                        double Saldo = 0;
                                               
                        ProximoNumeroDaConta = Convert.ToString(Conta.NextNumber);
                        Console.WriteLine("O número da conta é: " + ProximoNumeroDaConta);

                        Console.WriteLine("Digite a agencia do cliente: ");
                        Agencia = Console.ReadLine();

                        Console.WriteLine("Digite o CPF: ");
                        CPF = Console.ReadLine();

                        do
                        {
                            try
                            {
                                Console.WriteLine("Digite o valor para depositar [valor minimo 10]: ");
                                Saldo = double.Parse(Console.ReadLine());
                                if (Saldo < 10)
                                {
                                    throw new SaldoInsuficienteException("Saldo esta abaixo do valor minimo.");
                                }
                            }
                            catch (SaldoInsuficienteException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            

                        }
                        while (Saldo < 10);

                        try
                        {
                            _cliente = Banco.PesquisarCliente(CPF);

                            do
                            {

                                Console.WriteLine("Qual tipo de conta o cliente esta interessado?");
                                Console.WriteLine("[1] - Conta corrente");
                                Console.WriteLine("[2] - Conta poupança");
                                Console.WriteLine("[3] - Conta bonificada");

                                leitura = Console.ReadLine();

                                if (Regex.IsMatch(leitura, @"^[0-9]+$"))
                                {
                                    opcao = int.Parse(leitura);

                                    if ((opcao > 3) || (opcao < 1))
                                    {
                                        Console.WriteLine("Opção inválida! número digitado não esta na lista.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Opção inválida! digite um numero.");
                                    opcao = 0;
                                }
                                

                            }
                            while ((opcao > 3) || (opcao < 1));

                            switch (opcao)
                            {
                                case 1:
                                    _conta = new Conta(Agencia, Saldo, _cliente);
                                    Banco.AdicionarConta(_conta);
                                    Console.WriteLine("Conta criada.");
                                    break;
                                case 2:
                                    _conta = new ContaPoupanca(Agencia, Saldo, _cliente);
                                    Banco.AdicionarConta(_conta);
                                    Console.WriteLine("Conta poupança criada.");
                                    break;
                                case 3:
                                    _conta = new ContaBonificada(Agencia, Saldo, _cliente);
                                    Banco.AdicionarConta(_conta);
                                    Console.WriteLine("Conta bonificada criada.");
                                    break;
                            }
                                                            
                        }
                        catch(ClienteInexistenteException ex){
                            Console.WriteLine(ex.Message);
                        }
                        catch (ContaJaExistenteException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }


                        break;
                    case 2:
                        Console.Clear();

                        Console.WriteLine("Para fecha a conta digite numero da conta: ");
                        leitura = Console.ReadLine();

                        try
                        {
                            Banco.RemoverConta(leitura);
                            Console.WriteLine("Conta removida do banco com sucesso.");
                        }
                        catch (ContaInexistenteException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        Console.Clear();

                        string NumeroContaOrigem, NumeroContaDestino;
                        double Valortransferido;

                        Console.WriteLine("Digite a conta de origem: ");
                        NumeroContaOrigem = Console.ReadLine();

                        Console.WriteLine("Digite a conta de destino: ");
                        NumeroContaDestino = Console.ReadLine();

                        Console.WriteLine("Digite o valor da transferencia: ");
                        Valortransferido = double.Parse(Console.ReadLine());

                        try
                        {
                            Conta contaOrigem = Banco.PesquisaConta(NumeroContaOrigem);
                            Conta contaDestino = Banco.PesquisaConta(NumeroContaDestino);

                            Banco.Transferir(NumeroContaOrigem, NumeroContaDestino, Valortransferido );

                            Console.WriteLine("Valor da conta dos clientes: ");
                            Console.WriteLine("O novo saldo da conta de origem eh: " + contaOrigem.SaldoAtual);
                            Console.WriteLine("O novo saldo da conta de destino eh: " + contaDestino.SaldoAtual);
                        }
                        catch (ContaInexistenteException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (SaldoInsuficienteException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (ValorNegativoException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 4:
                        Console.Clear();
                        
                        Console.WriteLine("Digite o número da conta: ");
                        string NumeroDaConta = Console.ReadLine();

                        Console.WriteLine("Digite o valor a ser creditado: ");
                        double ValorASerCreditado = double.Parse(Console.ReadLine());

                        try
                        {
                            Banco.Creditar(NumeroDaConta, ValorASerCreditado);
                            Console.WriteLine("Valor creditado com sucesso.");
                            _conta = Banco.PesquisaConta(NumeroDaConta);
                            Console.WriteLine("O novo saldo da conta é: "+ _conta.SaldoAtual);
                        }
                        catch (ContaInexistenteException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (ValorNegativoException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 5:
                        Console.Clear();

                        Console.WriteLine("Digite o número da conta.");
                        string NumeroDaContaDebitar = Console.ReadLine();
                        Console.WriteLine("Digite o valor a ser debitado: ");
                        double ValorDebitor = double.Parse(Console.ReadLine());

                        Conta _contaCreditar;

                        try
                        {
                            _contaCreditar = Banco.PesquisaConta(NumeroDaContaDebitar);
                            Banco.Debitar(NumeroDaContaDebitar, ValorDebitor);

                            Console.WriteLine("Valor debitado com sucesso.");
                            Console.WriteLine("O novo saldo da conta é: " + _contaCreditar.SaldoAtual);
                        }
                        catch (ContaInexistenteException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(SaldoInsuficienteException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (ValorNegativoException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 6:
                        Console.Clear();

                        string NomeDoCliente, CPFDoCliente, RGDoCliente, EnderecoDoCliente, DataDeNascimentoDoCliente; 
                        
                        Console.WriteLine("Digite nome do cliente: ");
                        NomeDoCliente = Console.ReadLine();

                        Console.WriteLine("Digite o CPF: ");
                        CPFDoCliente = Console.ReadLine();
                                                
                        Console.WriteLine("Digite o RG: ");
                        RGDoCliente = Console.ReadLine();

                        Console.WriteLine("Digite o endereço do cliente: ");
                        EnderecoDoCliente = Console.ReadLine();

                        Console.WriteLine("Digite a data de nascimento: ");
                        DataDeNascimentoDoCliente = Console.ReadLine();

                        _cliente = new Cliente(NomeDoCliente, CPFDoCliente, RGDoCliente, EnderecoDoCliente, DataDeNascimentoDoCliente);

                        Console.Clear();
                        /*Adiciona o cliente na lista ou lança uma axceção indicando que o cliente já existe*/
                        try
                        {
                            Banco.AdicionarCliente(_cliente);
                           
                        }
                        catch (ClienteJaExistenteException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;                                               
                    case 7:
                        Console.Clear();

                        Console.WriteLine("Os clientes são: ");
                        ListarContas();
                    
                        break;
                    case 8:
                        Console.Clear();
                        
                        Console.WriteLine("Digite número para operações bancarias:");
                        Console.WriteLine("[1] - para render juros na conta poupança.");
                        Console.WriteLine("[2] - para da uma bonificação a conta bonificada.");
                        int NumeroDaOperacao = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o número da conta.");
                        string NumeroDaContaBancaria = Console.ReadLine();

                        switch (NumeroDaOperacao)
                        {
                            case 1:
                                Console.WriteLine("Digite a taxa");
                                double Taxa = double.Parse(Console.ReadLine());
                                Taxa = Taxa / 100;

                                try
                                {
                                    Banco.RenderJuros(NumeroDaContaBancaria, Taxa);
                                    Console.WriteLine("Operação completa.");
                                }
                                catch(ContaInexistenteException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch(TipoContaInvalidaException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch(ValorNegativoException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                                break;

                            case 2:

                                try
                                {
                                    Banco.renderBonus(NumeroDaContaBancaria);
                                    Console.WriteLine("Operação completa.");
                                }
                                catch(ContaInexistenteException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch(TipoContaInvalidaException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (ValorNegativoException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                                break;
                        }

                        break;
                    default:
                        Console.WriteLine("Fim do programa tenha um bom dia.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }




            }
            while (opcao != 9) ;

           

        }

        public static void ListarContas()
        {
            foreach (Conta _conta in Banco.ListaContas())
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Nome do cliente é: " + _conta.ClienteDoBanco.NomeDoCLiente);
                Console.WriteLine("CPF do cliente é: " + _conta.ClienteDoBanco.PegarCPF);
                Console.WriteLine("RG do cliente é: " + _conta.ClienteDoBanco.RGDoCliente);
                Console.WriteLine("Endereço do cliente é: " + _conta.ClienteDoBanco.EnderecoDoCliente);
                Console.WriteLine("Data de Nascimento do Cliente é: " + _conta.ClienteDoBanco.DataDeNascimentoDoCliente);
                Console.WriteLine("Número da conta é: " + _conta.pegarNumero);
                Console.WriteLine("Agência do cliente é: " + _conta.AgenciaDoCliente);
                Console.WriteLine("Saldo do cliente é: " + _conta.SaldoAtual);
                Console.WriteLine("------------------------------------------------------");
            }
        }
    }
}
