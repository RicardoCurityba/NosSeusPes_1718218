namespace BibliotecaProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18_15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pessoas", "Endereco_Id", "dbo.Enderecoes");
            RenameColumn(table: "dbo.Pessoas", name: "Endereco_Id", newName: "IdEndereco");
            RenameIndex(table: "dbo.Pessoas", name: "IX_Endereco_Id", newName: "IX_IdEndereco");
            AddForeignKey("dbo.Pessoas", "IdEndereco", "dbo.Enderecoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pessoas", "IdEndereco", "dbo.Enderecoes");
            RenameIndex(table: "dbo.Pessoas", name: "IX_IdEndereco", newName: "IX_Endereco_Id");
            RenameColumn(table: "dbo.Pessoas", name: "IdEndereco", newName: "Endereco_Id");
            AddForeignKey("dbo.Pessoas", "Endereco_Id", "dbo.Enderecoes", "Id");
        }
    }
}
