namespace BibliotecaProjeto
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BancoDeDadosSapato_1718218 : DbContext
    {
        // Your context has been configured to use a 'BancoDeDadosSapato_1718218' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BibliotecaProjeto.BancoDeDadosSapato_1718218' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BancoDeDadosSapato_1718218' 
        // connection string in the application configuration file.
        public BancoDeDadosSapato_1718218()
            : base("name=BancoDeDadosSapato_1718218")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<ModeloSapato> Sapatos { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Estoque> Estoques { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}