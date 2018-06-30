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
    /// Interaction logic for WindowPessoaFisica.xaml
    /// </summary>
    public partial class WindowPessoaFisica : Window, INotifyPropertyChanged
    {
        private BancoDeDadosSapato_1718218 ctx = new BancoDeDadosSapato_1718218();
        private PessoaFisica _PessoaSelecionada = new PessoaFisica();
        public PessoaFisica PessoaSelecionada
        {
            get
            {
                return _PessoaSelecionada;
            }
            set
            {
                _PessoaSelecionada = value;
                this.NotifyPropertyChanged("PessoaSelecionada");
            }
        }
        private ICollection<PessoaFisica> _PessoasFisicas = new List<PessoaFisica>();
        public ICollection<PessoaFisica> PessoasFisicas
        {
            get
            {
                return _PessoasFisicas;
            }
            set
            {
                _PessoasFisicas = value;
                this.NotifyPropertyChanged("PessoasFisicas");
            }
        }
        public Boolean ModoCriacaoPessoaFisica { get; set; } = false;
        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoPessoaFisica)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        //tela para gerenciamento de pessoa física
        public WindowPessoaFisica()
        {
            InitializeComponent();
            //Gera uma lista de pessoas
            var Pessoas = ctx.Pessoas.ToList();
            //Confere se o objeto é pessoa física e adiciona na lista para exibição na DataGrid
            foreach (Pessoa p in Pessoas)
            {
                if (p is PessoaFisica)
                {
                    this.PessoasFisicas.Add((PessoaFisica)p);
                }
            }
            DataContext = this;
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (ModoCriacaoPessoaFisica)
            {
                ctx.Pessoas.Add(PessoaSelecionada);
                ctx.SaveChanges();
            }
            else if(PessoaSelecionada != null && PessoaSelecionada.Id > 0)
            {
                ctx.SaveChanges();
            }
            //Exibi uma mensagem de confirmação ao clicar no botão salvar
            MessageBoxResult message = MessageBox.Show("Procedimento Efetuado com sucesso", "Confirmar", MessageBoxButton.OK, MessageBoxImage.None);
            this.Close();
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NotifyPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
