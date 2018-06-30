namespace BibliotecaProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10_50 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ModeloSapatoes", "Cadarco", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ModeloSapatoes", "Cadarco", c => c.String());
        }
    }
}
