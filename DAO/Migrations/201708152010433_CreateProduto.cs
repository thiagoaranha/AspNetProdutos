namespace DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produto",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DataDeCadastro = c.DateTime(nullable: false),
                    Nome = c.String(nullable: false),
                    Categoria = c.String(nullable: false),
                    Preco = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Produto");
        }
    }
}
