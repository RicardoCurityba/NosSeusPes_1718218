using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaProjeto
{
    public class ServiceClosedXML
    { 
        public static void CriarPlanilhaSapatosEstoque(IEnumerable<Estoque> estoques, IEnumerable<ModeloSapato> sapatos, String caminho)
        {
            //Criar um Workbook. Um arquvio excel.
            var workbook = new XLWorkbook();
            for (int i = 33; i <= 42; i++)
            {
                var est = estoques.Where(e => e.Tamanho == i).ToList();
                //Um arquivo excel pode conter várias planilhas. 
                var worksheet = workbook.Worksheets.Add(i.ToString());
                worksheet.Cell("A1").Value = "Tamanho";
                worksheet.Cell("B1").Value = i;
                var columnNome = worksheet.Column("A");
                var columnCadarco = worksheet.Column("B");
                var columnMaterial = worksheet.Column("C");
                var columnCor = worksheet.Column("D");
                var columnPreco = worksheet.Column("E");
                var columnQuantidade = worksheet.Column("F");
                int ListaSapatosLinhaInicio = 3;
                columnNome.Cell(ListaSapatosLinhaInicio).Value = "Nome";
                columnCadarco.Cell(ListaSapatosLinhaInicio).Value = "Cadarço";
                columnMaterial.Cell(ListaSapatosLinhaInicio).Value = "Material";
                columnCor.Cell(ListaSapatosLinhaInicio).Value = "Cor";
                columnPreco.Cell(ListaSapatosLinhaInicio).Value = "Preço";
                columnQuantidade.Cell(ListaSapatosLinhaInicio).Value = "Quantidade";
                worksheet.Row(ListaSapatosLinhaInicio).Style.Fill.BackgroundColor = XLColor.Gray;
                worksheet.Row(ListaSapatosLinhaInicio).Style.Font.Bold = true;
                ListaSapatosLinhaInicio++;
                foreach (Estoque e in est)
                {
                    ModeloSapato s = sapatos.Where(sap => sap.Id == e.IdModelo).SingleOrDefault();
                    e.Modelo = s;
                    columnNome.Cell(ListaSapatosLinhaInicio).Value = e.Modelo.Nome;
                    if (e.Modelo.Cadarco)
                    {
                        columnCadarco.Cell(ListaSapatosLinhaInicio).Value = "Sim";
                    }
                    else
                    {
                        columnCadarco.Cell(ListaSapatosLinhaInicio).Value = "Não";
                    }
                    columnMaterial.Cell(ListaSapatosLinhaInicio).Value = e.Modelo.Material;
                    columnCor.Cell(ListaSapatosLinhaInicio).Value = e.Modelo.Cor;
                    columnPreco.Cell(ListaSapatosLinhaInicio).Value = e.Modelo.Preco;
                    columnQuantidade.Cell(ListaSapatosLinhaInicio).Value = e.Quantidade;
                    ListaSapatosLinhaInicio++;
                }
            }

            workbook.ReferenceStyle = XLReferenceStyle.A1;

            workbook.CalculateMode = ClosedXML.Excel.XLCalculateMode.Auto;

            workbook.SaveAs(caminho, true, evaluateFormulae: true);
        }

        public static void CriarPlanilhaClientePedidos(IEnumerable<Pessoa> pessoas, IEnumerable<Pedido> pedidos, IEnumerable<Endereco> enderecos, IEnumerable<ModeloSapato> sapatos, String caminho)
        {
            //Criar um Workbook. Um arquvio excel.
            var workbook = new XLWorkbook();
            foreach (Pessoa p in pessoas)
            {
                p.Pedidos = pedidos.Where(ped => ped.IdCliente == p.Id).ToList();
                //Um arquivo excel pode conter várias planilhas. 
                var worksheet = workbook.Worksheets.Add(p.Id + "-" + p.Nome);
                worksheet.Cell("A1").Value = "Nome";
                worksheet.Cell("B1").Value = p.Nome;
                if (p is PessoaFisica)
                {
                    worksheet.Cell("A2").Value = "CPF";
                    worksheet.Cell("B2").Value = ((PessoaFisica)p).CPF;
                    worksheet.Cell("A3").Value = "Data de Nascimento";
                    worksheet.Cell("B3").Value = ((PessoaFisica)p).Nascimento.ToString("dd/MM/yyyy");
                    worksheet.Cell("A4").Value = "Idade";
                    worksheet.Cell("B4").Value = "=ARREDMULTB(FRAÇÃOANO(HOJE();B3);1)";
                }
                else
                {
                    ((PessoaJuridica)p).Endereco = enderecos.Where(end => end.Id == ((PessoaJuridica)p).IdEndereco).SingleOrDefault();
                    worksheet.Cell("A2").Value = "CNPJ";
                    worksheet.Cell("B2").Value = ((PessoaJuridica)p).CNPJ;
                    worksheet.Cell("A3").Value = "Razão Social";
                    worksheet.Cell("B3").Value = ((PessoaJuridica)p).RazaoSocial;
                    worksheet.Cell("A4").Value = "Logradouro";
                    worksheet.Cell("B4").Value = ((PessoaJuridica)p).Endereco.Logradouro;
                    worksheet.Cell("D1").Value = "Número";
                    worksheet.Cell("E1").Value = ((PessoaJuridica)p).Endereco.Numero;
                    worksheet.Cell("D2").Value = "Complemento";
                    worksheet.Cell("E2").Value = ((PessoaJuridica)p).Endereco.Complemento;
                    worksheet.Cell("D3").Value = "CEP";
                    worksheet.Cell("E3").Value = ((PessoaJuridica)p).Endereco.CEP;
                    worksheet.Cell("D4").Value = "Bairro";
                    worksheet.Cell("E4").Value = ((PessoaJuridica)p).Endereco.Bairro;
                    worksheet.Cell("G1").Value = "Cidade";
                    worksheet.Cell("H1").Value = ((PessoaJuridica)p).Endereco.Cidade;
                    worksheet.Cell("G2").Value = "Estado";
                    worksheet.Cell("H2").Value = ((PessoaJuridica)p).Endereco.Estado;
                    worksheet.Cell("G3").Value = "Pais";
                    worksheet.Cell("H3").Value = ((PessoaJuridica)p).Endereco.Pais;
                }
                int ListaSapatosLinhaInicio = 6;
                var columnNome = worksheet.Column("A");
                var columnCadarco = worksheet.Column("B");
                var columnMaterial = worksheet.Column("C");
                var columnCor = worksheet.Column("D");
                var columnPrecoUni = worksheet.Column("E");
                var columnQuantidade = worksheet.Column("F");
                var columnPrecoTot = worksheet.Column("G");
                var columnDataCompra = worksheet.Column("H");
                columnNome.Cell(ListaSapatosLinhaInicio).Value = "Sapato";
                columnCadarco.Cell(ListaSapatosLinhaInicio).Value = "Cadarço";
                columnMaterial.Cell(ListaSapatosLinhaInicio).Value = "Material";
                columnCor.Cell(ListaSapatosLinhaInicio).Value = "Cor";
                columnPrecoUni.Cell(ListaSapatosLinhaInicio).Value = "Preço Sapato";
                columnQuantidade.Cell(ListaSapatosLinhaInicio).Value = "Quantidade";
                columnPrecoTot.Cell(ListaSapatosLinhaInicio).Value = "Preço Total";
                columnDataCompra.Cell(ListaSapatosLinhaInicio).Value = "Data da Compra";
                worksheet.Row(ListaSapatosLinhaInicio).Style.Fill.BackgroundColor = XLColor.Gray;
                worksheet.Row(ListaSapatosLinhaInicio).Style.Font.Bold = true;
                ListaSapatosLinhaInicio++;
                foreach (Pedido pd in p.Pedidos)
                {
                    ModeloSapato s = sapatos.Where(sap => sap.Id == pd.IdModelo).SingleOrDefault();
                    pd.Modelo = s;
                    columnNome.Cell(ListaSapatosLinhaInicio).Value = pd.Modelo.Nome;
                    if (pd.Modelo.Cadarco)
                    {
                        columnCadarco.Cell(ListaSapatosLinhaInicio).Value = "Sim";
                    }
                    else
                    {
                        columnCadarco.Cell(ListaSapatosLinhaInicio).Value = "Não";
                    }
                    columnMaterial.Cell(ListaSapatosLinhaInicio).Value = pd.Modelo.Material;
                    columnCor.Cell(ListaSapatosLinhaInicio).Value = pd.Modelo.Cor;
                    columnPrecoUni.Cell(ListaSapatosLinhaInicio).Value = pd.Modelo.Preco;
                    columnQuantidade.Cell(ListaSapatosLinhaInicio).Value = pd.Quantidade;
                    columnPrecoTot.Cell(ListaSapatosLinhaInicio).Value = pd.Preco;
                    columnDataCompra.Cell(ListaSapatosLinhaInicio).Value = pd.DataCompra;
                    ListaSapatosLinhaInicio++;
                }
            }

            workbook.ReferenceStyle = XLReferenceStyle.A1;

            workbook.CalculateMode = ClosedXML.Excel.XLCalculateMode.Auto;

            workbook.SaveAs(caminho, true, evaluateFormulae: true);
        }
    }
}
