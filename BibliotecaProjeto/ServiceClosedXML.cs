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
        public static void CriarPlanilhaSapatosEstoque(IEnumerable<ModeloSapato> sapatos, String caminho)
        {
            BancoDeDadosSapato_1718218 ctx = new BancoDeDadosSapato_1718218();
            //Criar um Workbook. Um arquvio excel.
            var workbook = new XLWorkbook();
            foreach (ModeloSapato s in sapatos)
            {
                s.Estoques = ctx.Estoques.Where(est => est.IdModelo == s.Id).ToList();
                //Um arquivo excel pode conter várias planilhas. 
                var worksheet = workbook.Worksheets.Add(s.Id.ToString() + "-" + s.Nome);
                worksheet.Cell("A1").Value = "Nome";
                worksheet.Cell("B1").Value = s.Nome;
                worksheet.Cell("A2").Value = "Cadarço";
                if (s.Cadarco)
                {
                    worksheet.Cell("B2").Value = "Sim";
                }
                else
                {
                    worksheet.Cell("B2").Value = "Não";
                }
                worksheet.Cell("A3").Value = "Material";
                worksheet.Cell("B3").Value = s.Material;
                worksheet.Cell("A4").Value = "Cor";
                worksheet.Cell("B4").Value = s.Cor;
                worksheet.Cell("A5").Value = "Preço";
                worksheet.Cell("B5").Value = s.Preco;
                var columnTamanho = worksheet.Column("A");
                var columnQuantidade = worksheet.Column("B");
                int ListaSapatosLinhaInicio = 7;
                columnTamanho.Cell(ListaSapatosLinhaInicio).Value = "Tamanho";
                columnQuantidade.Cell(ListaSapatosLinhaInicio).Value = "Quantidade";
                worksheet.Row(ListaSapatosLinhaInicio).Style.Fill.BackgroundColor = XLColor.Gray;
                worksheet.Row(ListaSapatosLinhaInicio).Style.Font.Bold = true;
                ListaSapatosLinhaInicio++;
                foreach (Estoque e in s.Estoques)
                {
                    columnTamanho.Cell(ListaSapatosLinhaInicio).Value = e.Tamanho;
                    columnQuantidade.Cell(ListaSapatosLinhaInicio).Value = e.Quantidade;
                    ListaSapatosLinhaInicio++;
                }
            }

            workbook.ReferenceStyle = XLReferenceStyle.A1;

            workbook.CalculateMode = ClosedXML.Excel.XLCalculateMode.Auto;

            workbook.SaveAs(caminho, true, evaluateFormulae: true);
        }

        public static void CriarPlanilhaSapatosEstoque2(IEnumerable<Estoque> estoques, String caminho)
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
    }
}
