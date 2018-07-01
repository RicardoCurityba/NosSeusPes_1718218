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
    /// Lógica interna para WindowEstoque.xaml
    /// </summary>
    public partial class WindowEstoque : Window, INotifyPropertyChanged
    {
        private BancoDeDadosSapato_1718218 ctx = new BancoDeDadosSapato_1718218();
        private Estoque _Estoque = new Estoque();
        private ModeloSapato _Sapato = new ModeloSapato();
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
        public ModeloSapato SapatoSelecionado
        {
            get
            {
                return _Sapato;
            }
            set
            {
                _Sapato = value;
                this.Estoques = ctx.Estoques.Where(estoque => estoque.Modelo.Id == _Sapato.Id).ToList();
                this.NotifyPropertyChanged("SapatoSelecionado");
            }
        }
        public ICollection<Estoque> Estoques {
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
        public ICollection<ModeloSapato> Sapatos {
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
                this.Estoques = ctx.Estoques.Where(estoque => estoque.Modelo.Nome.Contains(Busca)).ToList();
                this.NotifyPropertyChanged("Busca");
            }
        }

        //Tela para gerenciar estoque
        public WindowEstoque()
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

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            ctx.SaveChanges();
            //Exibi uma mensagem de confirmação ao clicar no botão salvar
            MessageBox.Show("Procedimento Efetuado com sucesso");
            this.Close();
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EstoqueDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(Estoque estoque in e.RemovedItems)
            {
                ctx.Estoques.Remove(estoque);
            }
        }
    }
}
