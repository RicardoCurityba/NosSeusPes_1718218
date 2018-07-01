using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaProjeto
{
    public class Pessoa
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

    }
}
