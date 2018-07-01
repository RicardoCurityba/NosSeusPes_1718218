namespace BibliotecaProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10_57 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "preco");
        }
    }
}
