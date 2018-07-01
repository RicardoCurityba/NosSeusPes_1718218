namespace BibliotecaProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18_13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "DataCompra", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "DataCompra");
        }
    }
}
