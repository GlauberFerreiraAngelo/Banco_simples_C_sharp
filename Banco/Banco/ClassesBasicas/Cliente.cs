using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class Cliente
    {
        private String Nome { get; set; }
        private String CPF { get; set; }
        private String RG { get; set; }
        private String Endereco { get; set; }
        private String DataDeNascimento { get; set; }

        public Cliente(String _Nome, String _CPF, String _RG, String _Endereco, String _DataDeNascimento )
        {
            Nome = _Nome;
            CPF = _CPF;
            RG = _RG;
            Endereco = _Endereco;
            DataDeNascimento = _DataDeNascimento;
        }

        public string NomeDoCLiente
        {
            get
            {
                return Nome;
            }
        }
        public string PegarCPF
        {
            get
            {
                return CPF;
            }
        }
        public string RGDoCliente
        {
            get
            {
                return RG;
            }
        }
        public string EnderecoDoCliente
        {
            get
            {
                return Endereco;
            }
        }
        public string DataDeNascimentoDoCliente
        {
            get
            {
                return DataDeNascimento;
            }        }

    }
}
