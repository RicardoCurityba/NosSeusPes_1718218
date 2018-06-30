using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaProjeto
{
    public class ModeloSapato
    {
        public int Id { get; set; } = 0;
        public String Nome { get; set; } = "";
        public bool Cadarco { get; set; } = false;
        public String Material { get; set; } = "";
        public String Cor { get; set; } = "";
        public Decimal Preco { get; set; } = 0.0m;
        public byte[] Foto { get; set; }
        public ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
