namespace BibliotecaProjeto.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BancoDeDadosSapato_1718218>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BancoDeDadosSapato_1718218 context)
        {
            /*ModeloSapato m1 = new ModeloSapato() { Id = 1, Nome = "Sapato 1", Cadarco = true, Cor = "Cinza", Material = "Couro Sintético", Preco = 35.45m };
            ModeloSapato m2 = new ModeloSapato() { Id = 2, Nome = "Sapato 2", Cadarco = false, Cor = "Preto", Material = "Látex", Preco = 24.12m };
            ModeloSapato m3 = new ModeloSapato() { Id = 3, Nome = "Sapato 3", Cadarco = false, Cor = "Branco", Material = "Tecido", Preco = 32.15m };
            ModeloSapato m4 = new ModeloSapato() { Id = 4, Nome = "Sapato 4", Cadarco = true, Cor = "preto", Material = "Borracha", Preco = 28.75m };
            context.Sapatos.Add(m1);
            context.Sapatos.Add(m2);
            context.Sapatos.Add(m3);
            context.Sapatos.Add(m4);
            for (int i = 0; i < 10; i++)
            {
                Estoque e1 = new Estoque() { IdModelo = m1.Id, Tamanho = 33 + i, Quantidade = 0 };
                context.Estoques.Add(e1);
            }
            for (int i = 0; i < 10; i++)
            {
                Estoque e2 = new Estoque() { IdModelo = m2.Id, Tamanho = 33 + i, Quantidade = 0 };
                context.Estoques.Add(e2);
            }
            for (int i = 0; i < 10; i++)
            {
                Estoque e3 = new Estoque() { IdModelo = m3.Id, Tamanho = 33 + i, Quantidade = 0 };
                context.Estoques.Add(e3);
            }
            for (int i = 0; i < 10; i++)
            {
                Estoque e4 = new Estoque() { IdModelo = m4.Id, Tamanho = 33 + i, Quantidade = 0 };
                context.Estoques.Add(e4);
            }
            Endereco endereco = new Endereco() { Id = 1, Logradouro = "Rua Visconde Machado", Complemento = "Ap 3", Numero = 805, Bairro = "Centro", CEP = "00000-000", Cidade = "Curitiba", Estado = "Paraná", Pais = "Brasil" };
            Pessoa pf = new PessoaFisica() { Id = 1, Nome = "Fulano", CPF = "000.000.000-00", Nascimento = new DateTime(1985, 8, 14) };
            Pessoa pj = new PessoaJuridica() { Id = 2, Nome = "Calçados Maria", RazaoSocial = "cte calçados ltda", CNPJ = "00.000.000/0000-00", Endereco = endereco };
            context.Pessoas.Add(pf);
            context.Pessoas.Add(pj);
            context.SaveChanges();*/
        }
    }
}
