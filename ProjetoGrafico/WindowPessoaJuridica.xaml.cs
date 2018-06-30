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
    /// Interaction logic for WindowPessoaJuridica.xaml
    /// </summary>
    public partial class WindowPessoaJuridica : Window, INotifyPropertyChanged
    {
        private BancoDeDadosSapato_1718218 ctx = new BancoDeDadosSapato_1718218();
        private PessoaJuridica _PessoaSelecionada = new PessoaJuridica();
        public PessoaJuridica PessoaSelecionada
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
        private ICollection<PessoaJuridica> _PessoasJuridicas = new List<PessoaJuridica>();
        public ICollection<PessoaJuridica> PessoasJuridicas
        {
            get
            {
                return _PessoasJuridicas;
            }
            set
            {
                _PessoasJuridicas = value;
                this.NotifyPropertyChanged("PessoasJuridicas");
            }
        }
        public Boolean ModoCriacaoPessoaJuridica { get; set; } = false;
        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoPessoaJuridica)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        //tela para gerenciamento de pessoa Jurídica
        public WindowPessoaJuridica()
        {
            InitializeComponent();
            //Gera uma lista de pessoas
            var Pessoas = ctx.Pessoas.ToList();
            //Confere se o objeto é pessoa jurídica e adiciona na lista para exibição na DataGrid
            foreach(Pessoa p in Pessoas)
            {
                if(p is PessoaJuridica)
                {
                    Endereco end = ctx.Enderecos.Where(e => e.Id == ((PessoaJuridica)p).IdEndereco).SingleOrDefault();
                    ((PessoaJuridica)p).Endereco = end;
                    this.PessoasJuridicas.Add((PessoaJuridica)p);
                }
            }

            DataContext = this;
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (ModoCriacaoPessoaJuridica)
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
