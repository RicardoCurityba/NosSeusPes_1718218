namespace BibliotecaProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estoques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdModelo = c.Int(nullable: false),
                        Tamanho = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModeloSapatoes", t => t.IdModelo, cascadeDelete: true)
                .Index(t => t.IdModelo);
            
            CreateTable(
                "dbo.ModeloSapatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cadarco = c.String(),
                        Material = c.String(),
                        Cor = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Tamanho = c.Int(nullable: false),
                        Cliente_Id = c.Int(),
                        Modelo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.Cliente_Id)
                .ForeignKey("dbo.ModeloSapatoes", t => t.Modelo_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Modelo_Id);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CPF = c.String(),
                        Nascimento = c.DateTime(),
                        RazaoSocial = c.String(),
                        CNPJ = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Endereco_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enderecoes", t => t.Endereco_Id)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        CEP = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        Pais = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidoes", "Modelo_Id", "dbo.ModeloSapatoes");
            DropForeignKey("dbo.Pedidoes", "Cliente_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Pessoas", "Endereco_Id", "dbo.Enderecoes");
            DropForeignKey("dbo.Estoques", "IdModelo", "dbo.ModeloSapatoes");
            DropIndex("dbo.Pessoas", new[] { "Endereco_Id" });
            DropIndex("dbo.Pedidoes", new[] { "Modelo_Id" });
            DropIndex("dbo.Pedidoes", new[] { "Cliente_Id" });
            DropIndex("dbo.Estoques", new[] { "IdModelo" });
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.ModeloSapatoes");
            DropTable("dbo.Estoques");
        }
    }
}
