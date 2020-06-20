namespace Innoivce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnitProperityToProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnitId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "UnitId");
            AddForeignKey("dbo.Products", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UnitId", "dbo.Units");
            DropIndex("dbo.Products", new[] { "UnitId" });
            DropColumn("dbo.Products", "UnitId");
        }
    }
}
