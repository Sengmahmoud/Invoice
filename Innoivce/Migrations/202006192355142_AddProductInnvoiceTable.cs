namespace Innoivce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductInnvoiceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductInnvoices",
                c => new
                    {
                        InnvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Net = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.InnvoiceId, t.ProductId })
                .ForeignKey("dbo.Innvoices", t => t.InnvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InnvoiceId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInnvoices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductInnvoices", "InnvoiceId", "dbo.Innvoices");
            DropIndex("dbo.ProductInnvoices", new[] { "ProductId" });
            DropIndex("dbo.ProductInnvoices", new[] { "InnvoiceId" });
            DropTable("dbo.ProductInnvoices");
        }
    }
}
