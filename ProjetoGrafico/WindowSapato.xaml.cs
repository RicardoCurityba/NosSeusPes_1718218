using BibliotecaProjeto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for WindowSapato.xaml
    /// </summary>
    public partial class WindowSapato : Window, INotifyPropertyChanged
    {
        public BancoDeDadosSapato_1718218 ctx = new BancoDeDadosSapato_1718218();
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
                this.NotifyPropertyChanged("SapatoSelecionado");
            }
        }
        private IList<ModeloSapato> _Sapatos = new List<ModeloSapato>();
        public IList<ModeloSapato> Sapatos
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
        private IList<String> _Modelos = new List<String>() { "Couro Sintético", "Latéx", "Tecido", "Borracha" };
        public IList<String> Modelos
        {
            get
            {
                return _Modelos;
            }
            set
            {
                _Modelos = value;
                this.NotifyPropertyChanged("Modelos");
            }
        }
        public Boolean ModoCriacaoSapato { get; set; } = false;
        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoSapato)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        //tela para gerenciamento de sapatos
        public WindowSapato()
        {
            InitializeComponent();
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
        
        private void SalvarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModoCriacaoSapato)
            {
                ctx.Sapatos.Add(SapatoSelecionado);
                for(int i = 0; i < 10; i++)
                {
                    //Gera um estoque para cada sapato criado
                    Estoque estoque = new Estoque() { IdModelo = SapatoSelecionado.Id, Quantidade = 0, Tamanho = 33+i };
                    ctx.Estoques.Add(estoque);
                }
                ctx.SaveChanges();
            }else if(SapatoSelecionado != null && SapatoSelecionado.Id > 0)
            {
                ctx.SaveChanges();
            }
            //Exibi uma mensagem de confirmação ao clicar no botão salvar
            MessageBox.Show("Procedimento Efetuado com sucesso");
            this.Close();
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SapatoDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(ModeloSapato modelo in e.RemovedItems)
            {
                ctx.Sapatos.Remove(modelo);
            }
        }

        private void BtnSelecionarFoto_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Relatorio"; // Nome padrão
            dlg.Filter = "Imagens (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                var uri = new Uri(dlg.FileName);
                var imagemFile = File.Open(dlg.FileName, FileMode.Open);
                SapatoSelecionado.Foto = new byte[imagemFile.Length];
                imagemFile.Read(SapatoSelecionado.Foto,
                    0, (int)imagemFile.Length);
                NotifyPropertyChanged("Foto");
            }
        }
    }
}
