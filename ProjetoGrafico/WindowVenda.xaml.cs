using BibliotecaProjeto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetoGrafico
{
    /// <summary>
    /// Lógica interna para WindowVenda.xaml
    /// </summary>
    public partial class WindowVenda : Window, INotifyPropertyChanged
    {
        private BancoDeDadosSapato_1718218 ctx = new BancoDeDadosSapato_1718218();
        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoPedido)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        private ICollection<Pedido> _Pedidos = new List<Pedido>();
        public ICollection<Pedido> Pedidos
        {
            get
            {
                return _Pedidos;
            }
            set
            {
                _Pedidos = value;
                this.NotifyPropertyChanged("Pedidos");
            }
        }
        private ICollection<Pessoa> _Pessoas = new List<Pessoa>();
        public ICollection<Pessoa> Pessoas
        {
            get
            {
                return _Pessoas;
            }
            set
            {
                _Pessoas = value;
                this.NotifyPropertyChanged("Pessoas");
            }
        }
        private ICollection<Estoque> _Estoques = new List<Estoque>();
        public ICollection<Estoque> Estoques
        {
            get
            {
                return _Estoques;
            }
            set
            {
                _Estoques = value;
                this.NotifyPropertyChanged("Estoques");
            }
        }
        private ICollection<ModeloSapato> _Sapatos = new List<ModeloSapato>();
        public ICollection<ModeloSapato> Sapatos
        {
            get
            {
                return _Sapatos;
            }
            set
            {
                _Sapatos = value;
                this.NotifyPropertyChanged("Sapatos");
            }
        }

        public Boolean ModoCriacaoPedido { get; set; } = false;

        private Pedido _Pedido = new Pedido();
        public Pedido PedidoSelecionado
        {
            get
            {
                return _Pedido;
            }
            set
            {
                _Pedido = value;
                this.NotifyPropertyChanged("PedidoSelecionado");
            }
        }
        private Pessoa _Pessoa;
        public Pessoa PessoaSelecionada
        {
            get
            {
                return _Pessoa;
            }
            set
            {
                _Pessoa = value;
                this.NotifyPropertyChanged("PessoaSelecionada");
            }
        }
        private Estoque _Estoque = new Estoque();
        public Estoque EstoqueSelecionado
        {
            get
            {
                return _Estoque;
            }
            set
            {
                _Estoque = value;
                /*Quantidades.Clear();
                Quantidade = 0;
                int qt = ctx.Estoques.Where(x => x.IdModelo == EstoqueSelecionado.IdModelo && x.Tamanho == EstoqueSelecionado.Tamanho).Select(x => x.Quantidade).SingleOrDefault();
                for (int i = 0; i <= qt; i++)
                {
                    this.Quantidades.Add(i);
                }*/
                this.NotifyPropertyChanged("EstoqueSelecionado");
            }
        }
        private ModeloSapato _Sapato = new ModeloSapato();
        public ModeloSapato SapatoSelecionado
        {
            get
            {
                return _Sapato;
            }
            set
            {
                _Sapato = value;
                this.Estoques = ctx.Estoques.Where(e => e.IdModelo == SapatoSelecionado.Id).ToList();
                this.NotifyPropertyChanged("SapatoSelecionado");
            }
        }
        private int _Quantidade;
        public int Quantidade
        {
            get
            {
                return _Quantidade;
            }
            set
            {
                _Quantidade = value;
                var x = ctx.Estoques.Where(e => e.Id == EstoqueSelecionado.Id).Select(e => e.Quantidade).SingleOrDefault();
                if (value > x)
                {
                    MessageBox.Show("Valor digitado maior que o estoque");
                    _Quantidade = 0;
                }
                PedidoSelecionado.Preco = SapatoSelecionado.Preco * _Quantidade;
                this.NotifyPropertyChanged("Quantidade");
                this.NotifyPropertyChanged("PedidoSelecionado");
            }
        }

        public WindowVenda()
        {
            InitializeComponent();
            this.Pessoas = ctx.Pessoas.ToList();
            this.Sapatos = ctx.Sapatos.ToList();
            if (!ModoCriacaoPedido)
            {
                this.Pedidos = ctx.Pedidos.ToList();
                foreach(Pedido p in Pedidos)
                {
                    p.Modelo = ctx.Sapatos.Where(mod => mod.Id == p.IdModelo).SingleOrDefault();
                    p.Cliente = ctx.Pessoas.Where(cli => cli.Id == p.IdCliente).SingleOrDefault();
                }
            }
            DataContext = this;
        }

        private void NotifyPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            this.PedidoSelecionado.IdModelo = this.SapatoSelecionado.Id;
            this.PedidoSelecionado.Tamanho = this.EstoqueSelecionado.Tamanho;
            this.PedidoSelecionado.Quantidade = this.Quantidade;
            this.PedidoSelecionado.IdCliente = this.PessoaSelecionada.Id;
            this.EstoqueSelecionado.Quantidade -= this.Quantidade;
            ctx.Pedidos.Add(PedidoSelecionado);
            ctx.SaveChanges();
            this.Close();
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
