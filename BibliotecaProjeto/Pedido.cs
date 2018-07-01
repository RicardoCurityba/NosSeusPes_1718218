using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaProjeto
{
    public class Pedido
    {
        public int Id { get; set; } = 0;
        public int IdModelo { get; set; }
        [ForeignKey("IdModelo")]
        public ModeloSapato Modelo { get; set; }
        public int Quantidade { get; set; } = 0;
        public int Tamanho { get; set; } = 0;
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Pessoa Cliente { get; set; }
        public decimal Preco { get; set; }
    }
}
