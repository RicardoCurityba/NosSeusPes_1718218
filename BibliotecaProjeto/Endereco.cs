using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaProjeto
{
    public class Endereco
    {

        public int Id { get; set; }
        public String Logradouro { get; set; }
        public int Numero { get; set; }
        public String Complemento { get; set; }
        public String CEP { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public String Pais { get; set; }

        public override string ToString()
        {
            return "\n Logradouro: " + this.Logradouro + "\n Número: " + this.Numero + "\n Complemento: " + this.Complemento + "\n CEP: " + this.CEP + 
                "\n Bairro: " + this.Bairro + "\n Cidade: " + this.Cidade + "\n Estado: " + this.Estado + "\n Pais: " + this.Pais;
        }
    }
}
