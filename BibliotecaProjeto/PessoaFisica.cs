using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaProjeto
{
    public class PessoaFisica : Pessoa
    {
        public String CPF { get; set; }
        public DateTime Nascimento { get; set; }

        public override string ToString()
        {
            return base.ToString() + "\n CPF: " + this.CPF + "\n Nascimento: " + this.Nascimento.ToString("dd/MM/yyyy");
        }
    }
}
