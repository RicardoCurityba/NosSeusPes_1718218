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
    /// Lógica interna para WindowEstoqueBusca.xaml
    /// </summary>
    public partial class WindowEstoqueBusca : Window, INotifyPropertyChanged
    {
        private BancoDeDadosSapato_1718218 ctx = new BancoDeDadosSapato_1718218();
        private Estoque _Estoque = new Estoque();
        private ICollection<Estoque> _Estoques = new List<Estoque>();
        private ICollection<ModeloSapato> _Sapatos = new List<ModeloSapato>();
        public Estoque EstoqueSelecionado
        {
            get
            {
                return _Estoque;
            }
            set
            {
                _Estoque = value;
                this.NotifyPropertyChanged("EstoqueSelecionado");
            }
        }
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

        private String _Busca;
        public String Busca
        {
            get
            {
                return _Busca;
            }
            set
            {
                _Busca = value;
                this.NotifyPropertyChanged("Busca");
            }
        }

        //Tela para busca por tamanho ou nome
        public WindowEstoqueBusca()
        {
            InitializeComponent();
            this.Estoques = ctx.Estoques.ToList();
            this.Sapatos = ctx.Sapatos.ToList();
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

        private void ButtonPesquisa_Click(object sender, RoutedEventArgs e)
        {
            //Gera uma variável do tipo int para comparação se for possível converter a Busca
            int tam;
            int.TryParse(Busca, out tam);
            this.Estoques = ctx.Estoques.Where(estoque => estoque.Modelo.Nome.Contains(Busca)  || estoque.Tamanho == tam).ToList();
        }
    }
}
