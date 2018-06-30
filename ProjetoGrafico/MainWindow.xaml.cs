using BibliotecaProjeto;
using System;
using System.Collections.Generic;
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
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(sender == MenuGerenciarEstoque)
            {
                WindowEstoque estoque = new WindowEstoque();
                estoque.ShowDialog();
            }else if(sender == MenuPesquisarEstoque)
            {
                WindowEstoqueBusca estoqueBusca = new WindowEstoqueBusca();
                estoqueBusca.ShowDialog();
            }
            
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if(sender == MenuNovaPF)
            {
                WindowPessoaFisica pf = new WindowPessoaFisica();
                pf.ModoCriacaoPessoaFisica = true;
                pf.ShowDialog();
            }
            else if(sender == MenuNovaPJ)
            {
                WindowPessoaJuridica pj = new WindowPessoaJuridica();
                pj.ModoCriacaoPessoaJuridica = true;
                pj.ShowDialog();
            }
            else if(sender == MenuGerenciarPF)
            {
                WindowPessoaFisica pf = new WindowPessoaFisica();
                pf.ShowDialog();
            }
            else if(sender == MenuGerenciarPJ)
            {
                WindowPessoaJuridica pj = new WindowPessoaJuridica();
                pj.ShowDialog();
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if(sender == MenuGerenciarPedido)
            {
                WindowVenda venda = new WindowVenda();
                venda.ShowDialog();
            }
            else if(sender == MenuNovoPedido)
            {
                WindowVenda venda = new WindowVenda();
                venda.ModoCriacaoPedido = true;
                venda.ShowDialog();
                /*WindowEscolherModelo modelo = new WindowEscolherModelo();
                modelo.ShowDialog();*/
            }
            
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            if(sender == MenuNovoSapato)
            {
                WindowSapato sapato = new WindowSapato();
                sapato.ModoCriacaoSapato = true;
                sapato.ShowDialog();
            }else if(sender == MenuGerenciarSapatos)
            {
                WindowSapato sapato = new WindowSapato();
                sapato.ShowDialog();
            }
            
        }
    }
}
