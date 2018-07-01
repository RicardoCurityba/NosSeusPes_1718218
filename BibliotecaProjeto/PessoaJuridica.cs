using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaProjeto
{
    public class PessoaJuridica : Pessoa
    {
        public String RazaoSocial { get; set; }
        public String CNPJ { get; set; }

        public int IdEndereco { get; set; }

        [ForeignKey("IdEndereco")]
        public Endereco Endereco { get; set; }

        public override string ToString()
        {
            return base.ToString() + "\n Razão Social: " + this.RazaoSocial + "\n CNPJ: " + this.CNPJ + this.Endereco.ToString();
        }
    }
}
