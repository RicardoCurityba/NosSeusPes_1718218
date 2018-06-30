using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaProjeto
{
    public class Estoque
    {
        public int Id { get; set; }
        public int IdModelo { get; set; }
        [ForeignKey("IdModelo")]
        public ModeloSapato Modelo { get; set; }
        public int Tamanho { get; set; }
        public int Quantidade { get; set; }

    }
}
