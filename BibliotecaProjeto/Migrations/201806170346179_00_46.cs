namespace BibliotecaProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _00_46 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedidoes", "Cliente_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Pedidoes", "Modelo_Id", "dbo.ModeloSapatoes");
            DropIndex("dbo.Pedidoes", new[] { "Cliente_Id" });
            DropIndex("dbo.Pedidoes", new[] { "Modelo_Id" });
            RenameColumn(table: "dbo.Pedidoes", name: "Cliente_Id", newName: "IdCliente");
            RenameColumn(table: "dbo.Pedidoes", name: "Modelo_Id", newName: "IdModelo");
            AlterColumn("dbo.Pedidoes", "IdCliente", c => c.Int(nullable: false));
            AlterColumn("dbo.Pedidoes", "IdModelo", c => c.Int(nullable: false));
            CreateIndex("dbo.Pedidoes", "IdModelo");
            CreateIndex("dbo.Pedidoes", "IdCliente");
            AddForeignKey("dbo.Pedidoes", "IdCliente", "dbo.Pessoas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pedidoes", "IdModelo", "dbo.ModeloSapatoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidoes", "IdModelo", "dbo.ModeloSapatoes");
            DropForeignKey("dbo.Pedidoes", "IdCliente", "dbo.Pessoas");
            DropIndex("dbo.Pedidoes", new[] { "IdCliente" });
            DropIndex("dbo.Pedidoes", new[] { "IdModelo" });
            AlterColumn("dbo.Pedidoes", "IdModelo", c => c.Int());
            AlterColumn("dbo.Pedidoes", "IdCliente", c => c.Int());
            RenameColumn(table: "dbo.Pedidoes", name: "IdModelo", newName: "Modelo_Id");
            RenameColumn(table: "dbo.Pedidoes", name: "IdCliente", newName: "Cliente_Id");
            CreateIndex("dbo.Pedidoes", "Modelo_Id");
            CreateIndex("dbo.Pedidoes", "Cliente_Id");
            AddForeignKey("dbo.Pedidoes", "Modelo_Id", "dbo.ModeloSapatoes", "Id");
            AddForeignKey("dbo.Pedidoes", "Cliente_Id", "dbo.Pessoas", "Id");
        }
    }
}
