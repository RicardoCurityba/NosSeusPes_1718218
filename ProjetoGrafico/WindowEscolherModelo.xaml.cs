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
    /// Lógica interna para WindowEscolherModelo.xaml
    /// </summary>
    public partial class WindowEscolherModelo : Window, INotifyPropertyChanged
    {
        private BancoDeDadosSapato_1718218 ctx = new BancoDeDadosSapato_1718218();
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

        //Tela para seleção do modelo para realizar o pedido
        public WindowEscolherModelo()
        {
            InitializeComponent();
            this.Sapatos = ctx.Sapatos.ToList();
            DataContext = this;
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var currentRowIndex = URLGRID.Items.IndexOf(URLGRID.SelectedItem);
            {
                if (URLGRID.SelectedItem != null)
                {
                    WindowVenda wm = new WindowVenda();
                    wm.SapatoSelecionado.Id = currentRowIndex;
                    wm.ShowDialog();
                }

            }
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
