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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetoGrafico
{
    /// <summary>
    /// Interação lógica para UserControlSapato.xam
    /// </summary>
    public partial class UserControlSapato : UserControl, INotifyPropertyChanged
    {
        private ImageSource _Imagem;
        public ImageSource Imagem
        {
            get
            {
                return _Imagem;
            }
            set
            {
                _Imagem = value;
                this.NotifyPropertyChanged("Imagem");
            }
        }
        public UserControlSapato()
        {
            InitializeComponent();
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
