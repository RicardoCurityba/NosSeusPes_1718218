namespace BibliotecaProjeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21_34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ModeloSapatoes", "Foto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ModeloSapatoes", "Foto");
        }
    }
}
