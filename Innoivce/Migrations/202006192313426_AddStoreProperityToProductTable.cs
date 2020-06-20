namespace Innoivce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreProperityToProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "StoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "StoreId");
            AddForeignKey("dbo.Products", "StoreId", "dbo.Stores", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "StoreId", "dbo.Stores");
            DropIndex("dbo.Products", new[] { "StoreId" });
            DropColumn("dbo.Products", "StoreId");
        }
    }
}
