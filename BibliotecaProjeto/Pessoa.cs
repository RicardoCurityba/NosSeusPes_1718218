using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaProjeto
{
    public class Pessoa
    {
        public int Id { get; set; } = 0;
        public String Nome { get; set; } = "";
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public override string ToString()
        {
            return " Id: " + this.Id + "\n Nome: " + this.Nome;
        }
    }
}
